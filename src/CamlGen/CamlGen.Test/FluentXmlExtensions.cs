/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

using Microsoft.XmlDiffPatch;

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace FluentCamlGen.CamlGen.Test
{
    public static class FluentXmlExtensions
    {
        /// <summary>
        /// Parse the string as XML
        /// </summary>
        /// <param name="this"></param>
        /// <returns><see cref="XmlDocument"/></returns>
        public static XmlDocument AsXml(this string @this)
        {
            var doc = new XmlDocument();
            doc.LoadXml(@this);
            return doc;
        }

        /// <summary>
        /// Returns an <see cref="XmlDocumentAssertions"/> object that can be used to assert the
        /// current <see cref="XmlDocument"/>.
        /// </summary>
        public static XmlDocumentAssertions Should(this XmlDocument actualValue)
        {
            return new XmlDocumentAssertions(actualValue);
        }

        /// <summary>
        /// Inner Class to represent the XmlDocumentAssertions for FluentAssertions
        /// </summary>
        public class XmlDocumentAssertions : ReferenceTypeAssertions<XmlDocument, XmlDocumentAssertions>
        {
            public XmlDocumentAssertions(XmlDocument document)
            {
                Subject = document;
            }

            /// <summary>
            /// Returns the type of the subject the assertion applies on.
            /// </summary>
            protected override string Context
            {
                get { return "XmlDocument"; }
            }

            /// <summary>
            /// Diffs two XmlDoxuments.
            /// </summary>
            /// <param name="left"><see cref="XmlDocument"/></param>
            /// <param name="right"><see cref="XmlDocument"/></param>
            /// <returns>DiffGram-String, if the two are different. Otherwise returns the empty string.</returns>
            private static string LooseDiff(XmlNode left, XmlNode right)
            {
                if (right == null) throw new ArgumentNullException("right");
                var differ = new XmlDiff
                {
                    IgnoreChildOrder = true,
                    IgnoreComments = true,
                    IgnoreDtd = true,
                    IgnoreNamespaces = false,
                    IgnorePI = false,
                    IgnorePrefixes = true,
                    IgnoreWhitespace = true,
                    IgnoreXmlDecl = true
                };

                var sb = new StringBuilder();
                using (var xmlWriter = new XmlTextWriter(new StringWriter(sb)))
                {
                    var isSame = differ.Compare(left, right, xmlWriter);
                    if (isSame)
                    {
                        return String.Empty;
                    }
                }
                return sb.ToString();
            }

            /// <summary>
            /// Diffs two XML's loosely based on Microsoft XmlDiff
            /// </summary>
            /// <param name="expected"></param>
            /// <returns></returns>
            public AndConstraint<XmlDocumentAssertions> BeLooselyEquivalentTo(XmlDocument expected)
            {
                return BeLooselyEquivalentTo(expected, string.Empty);
            }

            /// <summary>
            /// Diffs two XML's loosely based on Microsoft XmlDiff
            /// </summary>
            /// <param name="expected"></param>
            /// <param name="because"></param>
            /// <param name="reasonArgs"></param>
            /// <returns></returns>
            public AndConstraint<XmlDocumentAssertions> BeLooselyEquivalentTo(XmlDocument expected, string because, params object[] reasonArgs)
            {
                var diffGram = LooseDiff(Subject, expected);

                Execute.Assertion
                    .ForCondition(HasNoDiff(diffGram))
                    .BecauseOf(because, reasonArgs)
                    .FailWith("Expected XML document to be loosely equivalent to {0}{reason}, but the first difference was {1}", GetXmlOf(expected), GetFirstDiffOf(diffGram));

                return new AndConstraint<XmlDocumentAssertions>(this);
            }

            private static bool HasNoDiff(string diffGram)
            {
                return string.IsNullOrEmpty(diffGram);
            }

            private static string GetFirstDiffOf(string diffGram)
            {
                if (HasNoDiff(diffGram))
                {
                    return "No Difference!";
                }

                const string ns = "{http://schemas.microsoft.com/xmltools/2002/xmldiff}";
                const string changeName = ns + "change";
                const string removeName = ns + "remove";
                const string addName = ns + "add";
                const SaveOptions saveOptions = SaveOptions.OmitDuplicateNamespaces | SaveOptions.DisableFormatting;

                var xmlDiffGram = XDocument.Parse(diffGram);
                var changes = xmlDiffGram.Descendants(XName.Get(changeName));
                var firstChange = changes.FirstOrDefault();
                if (firstChange != null)
                {
                    return "a change: " + firstChange.ToString(saveOptions);
                }
                var removals = xmlDiffGram.Descendants(XName.Get(removeName));
                var firstRemoval = removals.FirstOrDefault();
                if (firstRemoval != null)
                {
                    return "a removal: " + firstRemoval.ToString(saveOptions);
                }
                var additions = xmlDiffGram.Descendants(XName.Get(addName));
                var firstAddition = additions.FirstOrDefault();
                if (firstAddition != null)
                {
                    return "an addition: " + firstAddition.ToString(saveOptions);
                }

                return "an unknown diff: " + diffGram;
            }

            private static string GetXmlOf(XmlNode xmlDocument)
            {
                var sb = new StringBuilder();
                using (var xmlWriter = XmlWriter.Create(sb))
                {
                    xmlDocument.WriteTo(xmlWriter);
                }
                return sb.ToString();
            }
        }
    }
}