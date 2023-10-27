/*
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;
using System.Collections.Generic;
using FluentCamlGen.CamlGen.Elements.Value;

namespace FluentCamlGen.CamlGen.Elements.Core
{
    /// <summary>
    /// Create &lt;View> ... &lt;/View> for ViewXml.
    /// <seealso href="https://learn.microsoft.com/en-us/sharepoint/dev/schema/view-schema"/>
    /// </summary>
    public class View : BaseCoreElement
    {
        internal View(IEnumerable<BaseElement> inner)
            : base("View", null, inner)
        {
        }

        /// <summary>
        /// Add empty Query.
        /// </summary>
        /// <returns>Fluent <see cref="View"/>.</returns>
        public View Query()
        {
            return Query(x => { });
        }

        /// <summary>
        /// Add Query.
        /// </summary>
        /// <param name="action">Fluent configuration of the <see cref="Query"/>.</param>
        /// <returns>Fluent <see cref="View"/>.</returns>
        public View Query(Action<Query> action)
        {
            var query = new Query();
            action(query);
            Childs.Add(query);
            return this;
        }

        /// <summary>
        /// Add ViewFields.
        /// </summary>
        /// <param name="action">Fluent configuration of the <see cref="ViewFields"/>.</param>
        /// <returns>Fluent <see cref="View"/>.</returns>
        public View ViewFields(Action<ViewFields> action)
        {
            var viewFields = new ViewFields();
            action(viewFields);
            Childs.Add(viewFields);
            return this;
        }

        /// <summary>
        /// Add ProjectedFields.
        /// </summary>
        /// <param name="action">Fluent configuration of the <see cref="ProjectedFields"/>.</param>
        /// <returns>Fluent <see cref="View"/>.</returns>
        public View ProjectedFields(Action<ProjectedFields> action)
        {
            var viewFields = new ProjectedFields();
            action(viewFields);
            Childs.Add(viewFields);
            return this;
        }

        /// <summary>
        /// Add Joins.
        /// </summary>
        /// <param name="action">Fluent configuration of the <see cref="Joins"/>.</param>
        /// <returns>Fluent <see cref="View"/>.</returns>
        public View Joins(Action<Joins> action)
        {
            var joins = new Joins();
            action(joins);
            Childs.Add(joins);
            return this;
        }

        /// <summary>
        /// Add QueryOptions.
        /// </summary>
        /// <param name="action">Fluent configuration of the <see cref="QueryOptions"/>.</param>
        /// <returns>Fluent <see cref="View"/>.</returns>
        public View QueryOptions(Action<QueryOptions> action)
        {
            var joins = new QueryOptions();
            action(joins);
            Childs.Add(joins);
            return this;
        }

        /// <summary>
        /// Add a RowLimit to this View.
        /// </summary>
        /// <param name="rowLimit">The RowLimit.</param>
        /// <param name="paged">a value that represents the Paged-Attribute, or null to omit it.</param>
        /// <returns>Fluent <see cref="View"/>.</returns>
        public View RowLimit(int rowLimit, bool? paged = null)
        {
            var child = new RowLimit(rowLimit, paged);
            Childs.Add(child);
            return this;
        }
    }
}
