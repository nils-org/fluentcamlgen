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

namespace FluentCamlGen.CamlGen.Elements.Core
{
    /// <summary>
    /// Create &lt;View> ... &lt;/View> for ViewXml
    /// </summary>
    public class View : BaseCoreElement
    {
        internal View(IEnumerable<BaseElement> inner)
            : base("View", null, inner)
        {
        }

        /// <summary>
        /// Add empty Query
        /// </summary>
        /// <returns>Fluent <see cref="View"/></returns>
        public View Query()
        {
            return Query(x => { });
        }

        /// <summary>
        /// Add Query
        /// </summary>
        /// <returns>Fluent <see cref="View"/></returns>
        public View Query(Action<Query> action)
        {
            var query = new Query();
            action(query);
            Childs.Add(query);
            return this;
        }

        /// <summary>
        /// Add ViewFields
        /// </summary>
        /// <returns>Fluent <see cref="View"/></returns>
        public View ViewFields(Action<ViewFields> action)
        {
            var viewFields = new ViewFields();
            action(viewFields);
            Childs.Add(viewFields);
            return this;
        }

        /// <summary>
        /// Add ViewFields
        /// </summary>
        /// <returns>Fluent <see cref="View"/></returns>
        public View ProjectedFields(Action<ProjectedFields> action)
        {
            var viewFields = new ProjectedFields();
            action(viewFields);
            Childs.Add(viewFields);
            return this;
        }

        /// <summary>
        /// Add Joins
        /// </summary>
        /// <returns>Fluent <see cref="View"/></returns>
        public View Joins(Action<Joins> action)
        {
            var joins = new Joins();
            action(joins);
            Childs.Add(joins);
            return this;
        }

        /// <summary>
        /// Add QueryOptions
        /// </summary>
        /// <returns>Fluent <see cref="View"/></returns>
        public View QueryOptions(Action<QueryOptions> action)
        {
            var joins = new QueryOptions();
            action(joins);
            Childs.Add(joins);
            return this;
        }
    }
}