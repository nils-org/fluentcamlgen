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
using System.Text;

namespace FluentCamlGen.CamlGen.Elements.Core
{
    /// <summary>
    /// This is base Tag, that supports nesting & attributes
    /// </summary>
    public abstract class BaseCoreElement : BaseElement
    {
        internal string TagName { get; private set; }
        internal IList<BaseElement> Childs { get; private set; }
        internal IList<Tuple<string, string>> Attributes { get; private set; }

        internal BaseCoreElement(string tagName)
            : this(tagName, null, (BaseElement[])null)
        {
        }

        internal BaseCoreElement(string tagName, params Tuple<string, string>[] attributes)
            : this(tagName, attributes, null)
        {
        }

        internal BaseCoreElement(string tagName, params BaseElement[] children)
            : this(tagName, null, children)
        {
        }

        internal BaseCoreElement(string tagName, IEnumerable<Tuple<string, string>> attributes, IEnumerable<BaseElement> children)
        {
            TagName = tagName;
            Childs = new List<BaseElement>();
            Attributes = new List<Tuple<string, string>>();

            if (attributes != null)
            {
                foreach (var attribute in attributes)
                {
                    Attributes.Add(attribute);
                }
            }

            if (children == null) 
                return;

            foreach (var cg in children)
            {
                Childs.Add(cg);
            }
        }

        /// <summary>
        /// Call this to get the Caml-String
        /// </summary>
        /// <param name="formatCaml">true, if CAML should be pretty formatted</param>
        /// <param name="indent">number of spaces to insert for indentation.</param>
        /// <returns></returns>
        public override string ToString(bool formatCaml, int indent)
        {
            var newLine = formatCaml ? Environment.NewLine : string.Empty;
            var spaces = formatCaml ? new string(' ', indent) : string.Empty;
            var nextIndent = formatCaml ? indent + 2 : 0;

            var sb = new StringBuilder();
            sb.Append(string.Format("{0}<{1}", spaces, TagName));
            foreach (var attribute in Attributes)
            {
                sb.Append(string.Format(" {0}=\"{1}\"", attribute.Item1, attribute.Item2));
            }
            if (Childs.Count == 0)
            {
                sb.Append(string.Format(" />{0}", newLine));
            }
            else
            {
                sb.Append(string.Format(">{0}", newLine));
                foreach (var cg in Childs)
                {
                    sb.Append(cg.ToString(formatCaml, nextIndent));
                }
                sb.Append(string.Format("{0}</{1}>{2}", spaces, TagName, newLine));
            }

            return sb.ToString();
        }
    }
}