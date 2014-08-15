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
    /// CamlGenerator
    /// See <seealso cref="http://msdn.microsoft.com/en-us/library/ms462365(v=office.15).aspx"/> for a caml reference
    /// </summary>
    public class CG
    {
        #region the CG-code

        internal string TagName { get; private set; }
        internal IList<CG> Childs { get; private set; }
        internal IList<Tuple<string, string>> Attributes { get; private set; }

        internal CG(string tagName)
            : this(tagName, null, (CG[]) null)
        {
        }

        internal CG(string tagName, params Tuple<string, string>[] attributes)
            : this(tagName, attributes, null)
        {
        }

        internal CG(string tagName, params CG[] children)
            : this(tagName, null, children)
        {
        }

        internal CG(string tagName, IEnumerable<Tuple<string, string>> attributes, IEnumerable<CG> children)
        {
            TagName = tagName;
            Childs = new List<CG>();
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

        internal virtual string ToString(bool formatCaml, int indent)
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

        #endregion

        #region Static-Generators

        /// <summary>
        /// Create &lt;View> ... &lt;/View> for ViewXml
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CamlView View(params CG[] inner)
        {
            return new CamlView(inner);
        }

        /// <summary>
        /// Create &lt;Query> ... &lt;/Query>
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CamlQuery Query(params CG[] inner)
        {
            return new CamlQuery(inner);
        }

        /// <summary>
        /// Create &lt;ViewFields> ... &lt;/ViewFields>
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CamlViewFields ViewFields(params CG[] inner)
        {
            return new CamlViewFields(inner);
        }

        /// <summary>
        /// Create &lt;ProjectedFields> ... &lt;/ProjectedFields>
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CamlProjectedFields ProjectedFields(params CG[] inner)
        {
            return new CamlProjectedFields(inner);
        }

        /// <summary>
        /// Create &lt;Joins> ... &lt;/Joins>
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CamlJoins Joins(params CG[] inner)
        {
            return new CamlJoins(inner);
        }

        /// <summary>
        /// Create &lt;FieldRef Name="..." ... />
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CamlFieldRef FieldRef(string name, params Tuple<string, string>[] additionalAttributes)
        {
            return new CamlFieldRef(name, additionalAttributes);
        }

        /// <summary>
        /// Create &lt;Field Name="..." Type="..." List="..." ShowField="..." />
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CamlProjectedField ProjectedField(string name, string type, string list, string showFileld)
        {
            return new CamlProjectedField(name, type, list, showFileld);
        }


        /// <summary>
        /// Create &lt;Join Type="..." ListAlias="...">
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CamlJoin Join(string listName, CamlJoin.JoinType type, CG lhs, CG rhs)
        {
            return new CamlJoin(listName, type, lhs, rhs);
        }

        /// <summary>
        /// Create &lt;Join Type="..." ListAlias="...">
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CamlJoin Join(string listName, CamlJoin.JoinType type, string joinField)
        {
            return new CamlJoin(listName, type, joinField);
        }

        /// <summary>
        /// Create &lt;Join Type="INNER" ListAlias="...">
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CamlJoin InnerJoin(string listName, string joinField)
        {
            return Join(listName, CamlJoin.JoinType.Inner, joinField);
        }

        /// <summary>
        /// &lt;Eq> ... &lt;/Eq>
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CamlEq Eq(CG lhs, CG rhs)
        {
            return new CamlEq(lhs, rhs);
        }

        #endregion
    }
}