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

namespace FluentCamlGen.CamlGen
{
    /// <summary>
    /// This is base Tag, that supports nesting & attributes
    /// </summary>
    public class BaseCamlTag : ITag
    {
        internal string TagName { get; private set; }
        internal IList<ITag> Childs { get; private set; }
        internal IList<Tuple<string, string>> Attributes { get; private set; }

        internal BaseCamlTag(string tagName)
            : this(tagName, null, (ITag[])null)
        {
        }

        internal BaseCamlTag(string tagName, params Tuple<string, string>[] attributes)
            : this(tagName, attributes, null)
        {
        }

        internal BaseCamlTag(string tagName, params ITag[] children)
            : this(tagName, null, children)
        {
        }

        internal BaseCamlTag(string tagName, IEnumerable<Tuple<string, string>> attributes, IEnumerable<ITag> children)
        {
            TagName = tagName;
            Childs = new List<ITag>();
            Attributes = new List<Tuple<string, string>>();

            if (attributes != null)
            {
                foreach (var attribute in attributes)
                {
                    Attributes.Add(attribute);
                }
            }

            if (children != null)
            {
                foreach (var cg in children)
                {
                    Childs.Add(cg);
                }
            }
        }

        /// <summary>
        /// Call this to get the Caml-String
        /// <seealso cref="ToString(bool)"/>
        /// </summary>
        /// <returns>CAML</returns>
        public override string ToString()
        {
            return ToString(false, 0);
        }

        /// <summary>
        /// Call this to get the Caml-String
        /// </summary>
        /// <param name="formatCaml">true, if CAML should be pretty formatted</param>
        /// <returns></returns>
        public string ToString(bool formatCaml)
        {
            return ToString(formatCaml, 0);
        }

        public virtual string ToString(bool formatCaml, int indent)
        {
            var newLine = formatCaml ? "\\n" : string.Empty;
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