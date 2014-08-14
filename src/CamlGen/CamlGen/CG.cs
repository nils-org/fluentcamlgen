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
using System.Linq;
using System.Text;

namespace FluentCamlGen.CamlGen
{
    /// <summary>
    /// CamlGenerator
    /// </summary>
    public class CG
    {
        #region the CG-code
        internal string TagName { get; private set; }
        internal IList<CG> Childs { get; private set; }
        internal IList<Tuple<string, string>> Attributes { get; private set; }

        internal CG(string tagName)
            : this(tagName, null, (CG[])null)
        { }

        internal CG(string tagName, params Tuple<string, string>[] attributes)
            : this(tagName, attributes, null)
        { }

        internal CG(string tagName, params CG[] children)
            : this(tagName, null, children)
        { }

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
        /// </summary>
        /// <returns>CAML</returns>
        public override string ToString()
        {
            return ToString(0);
        }

        internal string ToString(int indent)
        {
            var spaces = new string(' ', indent);
            var sb = new StringBuilder();
            sb.Append(string.Format("{0}<{1}", spaces, TagName));
            foreach (var attribute in Attributes)
            {
                sb.Append(string.Format(" {0}=\"{1}\"", attribute.Item1, attribute.Item2));
            }
            if (Childs.Count == 0)
            {
                sb.AppendLine(" />");
            }
            else
            {
                sb.AppendLine(">");
                foreach (var cg in Childs)
                {
                    sb.Append(cg.ToString(indent + 2));
                }
                sb.AppendLine(string.Format("{0}</{1}>", spaces, TagName));
            }

            return sb.ToString();
        }

        #endregion

        #region Statics

        /// <summary>
        /// Create &lt;View> ... &lt;/View> for ViewXml
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CG View(params CG[] inner)
        {
            return new CG("View", inner);
        }

        /// <summary>
        /// Create &lt;Query> ... &lt;/Query>
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CG Query(params CG[] inner)
        {
            return new CG("Query", inner);
        }

        /// <summary>
        /// Create &lt;ViewFields> ... &lt;/ViewFields>
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CG ViewFields(params CG[] inner)
        {
            return new CG("ViewFields", inner);
        }

        /// <summary>
        /// Create &lt;ProjectedFields> ... &lt;/ProjectedFields>
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CG ProjectedFields(params CG[] inner)
        {
            return new CG("ProjectedFields", inner);
        }

        /// <summary>
        /// Create &lt;Joins> ... &lt;/Joins>
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CG Joins(params CG[] inner)
        {
            return new CG("Joins", inner);
        }

        /// <summary>
        /// Create &lt;FieldRef Name="..." ... />
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CG FieldRef(string name, params Tuple<string, string>[] additionalAttributes)
        {
            var attrs = new[] { new Tuple<string, string>("Name", name) }
                .Union(additionalAttributes)
                .ToArray();
            return new CG("FieldRef", attrs);
        }

        /// <summary>
        /// Create &lt;Field Name="..." Type="..." List="..." ShowField="..." />
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CG ProjectedField(string name, string type, string list, string showFileld)
        {
            //TODO: Are Params always like this??
            return new CG("Field", new[]{
                new Tuple<string, string>("Name", name),
                new Tuple<string, string>("Type", type),
                new Tuple<string, string>("List", list),
                new Tuple<string, string>("ShowField", showFileld),
            });
        }


        /// <summary>
        /// Create &lt;Join Type="INNER" ListAlias="...">
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CG Join(string listName, params CG[] inner)
        {
            //TODO: What about other Types??
            return new CG("Join", new[]{
                new Tuple<string, string>("Type", "INNER"),
                new Tuple<string, string>("ListAlias", listName)
            }, inner);
        }

        /// <summary>
        /// &lt;Eq> ... &lt;/Eq>
        /// </summary>
        /// <returns><see cref="CG"/></returns>
        public static CG Eq(CG lhs, CG rhs)
        {
            //TODO: Is this really alwas left & right??
            return new CG("Eq", lhs, rhs);
        }

        #endregion
    }
}
