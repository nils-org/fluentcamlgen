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

namespace FluentCamlGen.CamlGen
{
    /// <summary>
    /// CamlGenerator
    /// See <seealso cref="http://msdn.microsoft.com/en-us/library/ms462365(v=office.15).aspx"/> for a caml reference
    /// </summary>
    public class CG
    {

        /// <summary>
        /// Create &lt;View> ... &lt;/View> for ViewXml
        /// </summary>
        /// <returns><see cref="ITag"/></returns>
        public static CamlView View(params ITag[] inner)
        {
            return new CamlView(inner);
        }

        /// <summary>
        /// Create &lt;Query> ... &lt;/Query>
        /// </summary>
        /// <returns><see cref="ITag"/></returns>
        public static CamlQuery Query(params ITag[] inner)
        {
            return new CamlQuery(inner);
        }

        /// <summary>
        /// Create &lt;ViewFields> ... &lt;/ViewFields>
        /// </summary>
        /// <returns><see cref="ITag"/></returns>
        public static CamlViewFields ViewFields(params ITag[] inner)
        {
            return new CamlViewFields(inner);
        }

        /// <summary>
        /// Create &lt;ProjectedFields> ... &lt;/ProjectedFields>
        /// </summary>
        /// <returns><see cref="ITag"/></returns>
        public static CamlProjectedFields ProjectedFields(params ITag[] inner)
        {
            return new CamlProjectedFields(inner);
        }

        /// <summary>
        /// Create &lt;Joins> ... &lt;/Joins>
        /// </summary>
        /// <returns><see cref="ITag"/></returns>
        public static CamlJoins Joins(params ITag[] inner)
        {
            return new CamlJoins(inner);
        }

        /// <summary>
        /// Create &lt;FieldRef Name="..." ... />
        /// </summary>
        /// <returns><see cref="ITag"/></returns>
        public static CamlFieldRef FieldRef(string name, params Tuple<string, string>[] additionalAttributes)
        {
            return new CamlFieldRef(name, additionalAttributes);
        }

        /// <summary>
        /// Create &lt;Field Name="..." Type="..." List="..." ShowField="..." />
        /// </summary>
        /// <returns><see cref="ITag"/></returns>
        public static CamlProjectedField ProjectedField(string name, string type, string list, string showFileld)
        {
            return new CamlProjectedField(name, type, list, showFileld);
        }


        /// <summary>
        /// Create &lt;Join Type="..." ListAlias="...">
        /// </summary>
        /// <returns><see cref="ITag"/></returns>
        public static CamlJoin Join(string listName, CamlJoin.JoinType type, ITag lhs, ITag rhs)
        {
            return new CamlJoin(listName, type, lhs, rhs);
        }

        /// <summary>
        /// Create &lt;Join Type="..." ListAlias="...">
        /// </summary>
        /// <returns><see cref="ITag"/></returns>
        public static CamlJoin Join(string listName, CamlJoin.JoinType type, string joinField)
        {
            return new CamlJoin(listName, type, joinField);
        }

        /// <summary>
        /// Create &lt;Join Type="INNER" ListAlias="...">
        /// </summary>
        /// <returns><see cref="ITag"/></returns>
        public static CamlJoin InnerJoin(string listName, string joinField)
        {
            return Join(listName, CamlJoin.JoinType.Inner, joinField);
        }

        /// <summary>
        /// &lt;Eq> ... &lt;/Eq>
        /// </summary>
        /// <returns><see cref="ITag"/></returns>
        public static CamlEq Eq(ITag lhs, ITag rhs)
        {
            return new CamlEq(lhs, rhs);
        }

        /// <summary>
        /// &lt;QueryOptions> ... &lt;/QueryOptions>
        /// </summary>
        /// <param name="values"></param>
        /// <returns><see cref="ITag"/></returns>
        public static CamlQueryOptions QueryOptions(params BaseValueTag[] values)
        {
            return new CamlQueryOptions(values);
        }

        /// <summary>
        /// &lt;ExpandUserField>True|False&lt;/ExpandUserField>
        /// </summary>
        /// <param name="value"></param>
        /// <returns><see cref="ITag"/></returns>
        public static CamlValueExpandUserField ExpandUserField(bool value)
        {
            return new CamlValueExpandUserField(value);
        }

        /// <summary>
        /// &lt;DatesInUtc>True|False&lt;/DatesInUtc>
        /// </summary>
        /// <param name="value"></param>
        /// <returns><see cref="ITag"/></returns>
        public static CamlValueDatesInUtc DatesInUtc(bool value)
        {
            return new CamlValueDatesInUtc(value);
        }
    }
}