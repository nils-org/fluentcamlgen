﻿/*
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;
using FluentCamlGen.CamlGen.Elements;
using FluentCamlGen.CamlGen.Elements.Core;
using FluentCamlGen.CamlGen.Elements.Value;

namespace FluentCamlGen.CamlGen
{
    /// <summary>
    /// A Caml Generator.
    /// See <seealso href="https://learn.microsoft.com/en-us/sharepoint/dev/schema/collaborative-application-markup-language-caml-schemas"/> for a caml reference.
    /// </summary>
    public static class CG
    {
        /// <summary>
        /// Create &lt;View> ... &lt;/View> for ViewXml.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.View"/>.</returns>
        public static View View(params BaseElement[] inner)
        {
            return new View(inner);
        }

        /// <summary>
        /// Create &lt;Query> ... &lt;/Query>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.Query"/>.</returns>
        public static Query Query(params BaseElement[] inner)
        {
            return new Query(inner);
        }

        /// <summary>
        /// Create &lt;ViewFields> ... &lt;/ViewFields>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.ViewFields"/>.</returns>
        public static ViewFields ViewFields(params BaseElement[] inner)
        {
            return new ViewFields(inner);
        }

        /// <summary>
        /// Create &lt;ProjectedFields> ... &lt;/ProjectedFields>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.ProjectedFields"/>.</returns>
        public static ProjectedFields ProjectedFields(params BaseElement[] inner)
        {
            return new ProjectedFields(inner);
        }

        /// <summary>
        /// Create &lt;Joins> ... &lt;/Joins>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.Joins"/>.</returns>
        public static Joins Joins(params BaseElement[] inner)
        {
            return new Joins(inner);
        }

        /// <summary>
        /// Create &lt;FieldRef Name="..." ... />.
        /// </summary>
        /// <param name="name">Name of the field.</param>
        /// <param name="additionalAttributes">Additional attributes.</param>
        /// <returns><see cref="Elements.Core.FieldRef"/>.</returns>
        public static FieldRef FieldRef(string name, params Tuple<string, string>[] additionalAttributes)
        {
            return new FieldRef(name, additionalAttributes);
        }

        /// <summary>
        /// Create &lt;Field Name="..." Type="..." List="..." ShowField="..." />.
        /// </summary>
        /// <param name="name">Name of the joined field.</param>
        /// <param name="type">As of SharePoint Foundation 2010, all joins must be based on an existing lookup relation, so Type always has the value "Lookup".</param>
        /// <param name="list">Name of the joined list.</param>
        /// <param name="showField">Internal name of the field that should be shown.</param>
        /// <returns><see cref="Elements.Core.ProjectedField"/>.</returns>
        public static ProjectedField ProjectedField(string name, string type, string list, string showField)
        {
            return new ProjectedField(name, type, list, showField);
        }

        /// <summary>
        /// Create &lt;Join Type="..." ListAlias="...">.
        /// </summary>
        /// <param name="listName">Name of the list to join.</param>
        /// <param name="type">A <see cref="CG.JoinType"/>.</param>
        /// <param name="lhs">The left hand side of the join.</param>
        /// <param name="rhs">The right hand side of the join.</param>
        /// <returns><see cref="Elements.Core.Join"/>.</returns>
        public static Join Join(string listName, JoinType type, BaseElement lhs, BaseElement rhs)
        {
            return new Join(listName, type, lhs, rhs);
        }

        /// <summary>
        /// Create &lt;Join Type="..." ListAlias="...">.
        /// </summary>
        /// <param name="listName">Name of the list to join.</param>
        /// <param name="type">A <see cref="CG.JoinType"/>.</param>
        /// <param name="joinField">Name of the field to join on.</param>
        /// <returns><see cref="Elements.Core.Join"/>.</returns>
        public static Join Join(string listName, JoinType type, string joinField)
        {
            return new Join(listName, type, joinField);
        }

        /// <summary>
        /// Create &lt;Join Type="INNER" ListAlias="...">.
        /// </summary>
        /// <param name="listName">Name of the list to join.</param>
        /// <param name="joinField">Name of the field to join on.</param>
        /// <returns><see cref="Elements.Core.Join"/>.</returns>
        public static Join InnerJoin(string listName, string joinField)
        {
            return Join(listName, JoinType.Inner, joinField);
        }

        /// <summary>
        /// &lt;Eq> ... &lt;/Eq>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.Eq"/>.</returns>
        public static Eq Eq(params BaseElement[] inner)
        {
            return new Eq(inner);
        }

        /// <summary>
        /// &lt;QueryOptions> ... &lt;/QueryOptions>.
        /// </summary>
        /// <param name="values">Inner elements.</param>
        /// <returns><see cref="Elements.Core.QueryOptions"/>.</returns>
        public static QueryOptions QueryOptions(params BaseValueElement[] values)
        {
            return new QueryOptions(values);
        }

        /// <summary>
        /// &lt;ExpandUserField>True|False&lt;/ExpandUserField>.
        /// </summary>
        /// <param name="value"><c>true</c> for "True".</param>
        /// <returns><see cref="Elements.Value.ExpandUserField"/>.</returns>
        public static ExpandUserField ExpandUserField(bool value)
        {
            return new ExpandUserField(value);
        }

        /// <summary>
        /// &lt;DatesInUtc>True|False&lt;/DatesInUtc>.
        /// </summary>
        /// <param name="value"><c>true</c> for "True".</param>
        /// <returns><see cref="Elements.Value.DatesInUtc"/>.</returns>
        public static DatesInUtc DatesInUtc(bool value)
        {
            return new DatesInUtc(value);
        }

        /// <summary>
        /// &lt;Where> ... &lt;/Where>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.Where"/>.</returns>
        public static Where Where(params BaseElement[] inner)
        {
            return new Where(inner);
        }

        /// <summary>
        /// &lt;And> ... &lt;/And>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.And"/>.</returns>
        public static And And(params BaseElement[] inner)
        {
            return new And(inner);
        }

        /// <summary>
        /// &lt;Value Type="..."> ... &lt;/Value>.
        /// </summary>
        /// <param name="type">A <see cref="ValueType"/>.</param>
        /// <param name="value">The value.</param>
        /// <returns><see cref="Elements.Value.Value"/>.</returns>
        public static Value Value(ValueType type, string value)
        {
            return new Value(type, value);
        }

        /// <summary>
        /// &lt;Value Type="Number"> ... &lt;/Value>.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns><see cref="Elements.Value.Value"/>.</returns>
        public static Value NumberValue(double number)
        {
            return new NumberValue(number);
        }

        /// <summary>
        /// &lt;Value Type="Boolean">0|1&lt;/Value>.
        /// </summary>
        /// <param name="val"><c>true</c> for "True".</param>
        /// <returns><see cref="Elements.Value.Value"/>.</returns>
        public static Value BooleanValue(bool val)
        {
            return new BooleanValue(val);
        }

        /// <summary>
        /// &lt;OrderBy> ... &lt;/OrderBy>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.OrderBy"/>.</returns>
        public static OrderBy OrderBy(params BaseElement[] inner)
        {
            return new OrderBy(inner);
        }

        /// <summary>
        /// &lt;Or> ... &lt;/Or>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.Or"/>.</returns>
        public static Or Or(params BaseElement[] inner)
        {
            return new Or(inner);
        }

        /// <summary>
        /// &lt;Neq> ... &lt;/Neq>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.Neq"/>.</returns>
        public static Neq Neq(params BaseElement[] inner)
        {
            return new Neq(inner);
        }

        /// <summary>
        /// &lt;Lt> ... &lt;/Lt>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.Lt"/>.</returns>
        public static Lt Lt(params BaseElement[] inner)
        {
            return new Lt(inner);
        }

        /// <summary>
        /// &lt;Leq> ... &lt;/Leq>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.Leq"/>.</returns>
        public static Leq Leq(params BaseElement[] inner)
        {
            return new Leq(inner);
        }

        /// <summary>
        /// &lt;Gt> ... &lt;/Gt>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.Gt"/>.</returns>
        public static Gt Gt(params BaseElement[] inner)
        {
            return new Gt(inner);
        }

        /// <summary>
        /// &lt;Geq> ... &lt;/Geq>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.Geq"/>.</returns>
        public static Geq Geq(params BaseElement[] inner)
        {
            return new Geq(inner);
        }

        /// <summary>
        /// &lt;Contains> ... &lt;/Contains>.
        /// </summary>
        /// <param name="inner">Inner elements.</param>
        /// <returns><see cref="Elements.Core.Contains"/>.</returns>
        public static Contains Contains(params BaseElement[] inner)
        {
            return new Contains(inner);
        }

        #region Types

        /// <summary>
        /// Baseclass fro all Types.
        /// </summary>
        public abstract class AbstractType
        {
            private readonly string _type;

            /// <summary>
            /// Initializes a new instance of the <see cref="AbstractType"/> class.
            /// </summary>
            /// <param name="type">The type.</param>
            protected AbstractType(string type)
            {
                _type = type;
            }

            /// <summary>
            /// Converts to string.
            /// </summary>
            /// <returns>
            /// A <see cref="string" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return _type;
            }
        }

        /// <summary>
        /// possible JoinTypes to add on a Join.
        /// </summary>
        public class JoinType : AbstractType
        {
            /// <summary>
            /// LEFT.
            /// </summary>
            public static readonly JoinType Inner = new JoinType("INNER");

            /// <summary>
            /// INNER.
            /// </summary>
            public static readonly JoinType Left = new JoinType("LEFT");

            private JoinType(string type)
                : base(type)
            {
            }
        }

        /// <summary>
        /// possible ValueTypes to add on a &lt;Value>-Element.
        /// </summary>
        public class ValueType : AbstractType
        {
            /// <summary>
            /// Number.
            /// </summary>
            public static readonly ValueType Number = new ValueType("Number");

            /// <summary>
            /// Text.
            /// </summary>
            public static readonly ValueType Text = new ValueType("Text");

            /// <summary>
            /// Boolean.
            /// </summary>
            public static readonly ValueType Boolean = new ValueType("Boolean");

            private ValueType(string type)
                : base(type)
            {
            }
        }

        #endregion Types
    }
}
