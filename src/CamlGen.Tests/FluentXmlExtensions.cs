/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Shouldly;

namespace FluentCamlGen.CamlGen.Test
{
    public static class FluentXmlExtensions
    {
        /// <summary>
        /// Parse the string as XML
        /// </summary>
        /// <param name="this"></param>
        /// <returns><see cref="XDocument"/></returns>
        public static XDocument AsXml(this string @this)
        {
            var doc = XDocument.Parse(@this);
            return doc;
        }

        public static void ShouldBe(this XDocument lhs, XDocument rhs)
        {
            lhs.AsComparableString().ShouldBe(rhs.AsComparableString());
        }

        private static string AsComparableString(this XDocument doc)
        {
            var root = doc.Root;
            SortXml(ref root);

            using var mem = new MemoryStream();
            using var w = XmlWriter.Create(mem, new XmlWriterSettings
            {
                Encoding = Encoding.Unicode,
                OmitXmlDeclaration = true,
                IndentChars = " ",
                Indent = true,
                CloseOutput = false,
                WriteEndDocumentOnClose = true,
                Async = false,
                CheckCharacters = false,
                ConformanceLevel = ConformanceLevel.Document,
                NamespaceHandling = NamespaceHandling.OmitDuplicates,
                DoNotEscapeUriAttributes = true,
                NewLineChars = Environment.NewLine,
                NewLineHandling = NewLineHandling.None,
                NewLineOnAttributes = false
            });
            root.WriteTo(w);
            w.Flush();
            mem.Position = 0;

            using var r = new StreamReader(mem);
            return r.ReadToEnd();
        }

        private static void SortXml(ref XElement root)
        {
            var attributes = root.Attributes().OrderBy(x => x.Name.LocalName).ToList();
            var children = root.Elements().OrderBy(x => x, new XElementComparer()).ToList();
            root.RemoveAll();
            foreach (var attribute in attributes)
            {
                root.Add(attribute);
            }

            foreach (var child in children)
            {
                var noCopy = child;
                SortXml(ref noCopy);
                root.Add(noCopy);
            }
        }
        
        private class XElementComparer: IComparer<XElement>
        {
            public int Compare(XElement x, XElement y)
            {
                if (ReferenceEquals(x, y))
                {
                    return 0;
                }

                if (ReferenceEquals(x, null))
                {
                    return -1;
                }
                
                if (ReferenceEquals(y, null))
                {
                    return 1;
                }
                
                if (x.Name.LocalName != y.Name.LocalName)
                {
                    return string.Compare(x.Name.LocalName, y.Name.LocalName, StringComparison.Ordinal);
                }

                var xAttrs = string.Join("|",
                    x
                        .Attributes()
                        .OrderBy(n => n.Name.LocalName)
                        .ThenBy(n => n.Value)
                        .Select(n => $"{n.Name}={n.Value}"));
                var yAttrs = string.Join("|",
                    y
                        .Attributes()
                        .OrderBy(n => n.Name.LocalName)
                        .ThenBy(n => n.Value)
                        .Select(n => $"{n.Name}={n.Value}"));
                
                if (xAttrs != yAttrs)
                {
                    return string.Compare(xAttrs, yAttrs, StringComparison.Ordinal);
                }
                
                var xChildren = string.Join("|",
                    x
                        .Elements()
                        .Select(n => n.Name.LocalName)
                        .OrderBy(n => n));
                var yChildren = string.Join("|",
                    y
                        .Elements()
                        .Select(n => n.Name.LocalName)
                        .OrderBy(n => n));

                return string.Compare(xChildren, yChildren, StringComparison.Ordinal);
            }
        }
    }
}