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

namespace FluentCamlGen.CamlGen
{
    /// <summary>
    /// Create &lt;View> ... &lt;/View> for ViewXml
    /// </summary>
    public class CamlView : CG
    {
        internal CamlView(IEnumerable<CG> inner)
            : base("View", null, inner)
        {
        }

        /// <summary>
        /// Add empty Query
        /// </summary>
        /// <returns>Fluent <see cref="CamlView"/></returns>
        public CamlView Query()
        {
            return Query(x => { });
        }

        /// <summary>
        /// Add Query
        /// </summary>
        /// <returns>Fluent <see cref="CamlView"/></returns>
        public CamlView Query(Action<CamlQuery> action)
        {
            var query = new CamlQuery();
            action(query);
            Childs.Add(query);
            return this;
        }

        /// <summary>
        /// Add ViewFields
        /// </summary>
        /// <returns>Fluent <see cref="CamlView"/></returns>
        public CamlView ViewFields(Action<CamlViewFields> action)
        {
            var viewFields = new CamlViewFields();
            action(viewFields);
            Childs.Add(viewFields);
            return this;
        }

        /// <summary>
        /// Add ViewFields
        /// </summary>
        /// <returns>Fluent <see cref="CamlView"/></returns>
        public CamlView ProjectedFields(Action<CamlProjectedFields> action)
        {
            var viewFields = new CamlProjectedFields();
            action(viewFields);
            Childs.Add(viewFields);
            return this;
        }

        /// <summary>
        /// Add Joins
        /// </summary>
        /// <returns>Fluent <see cref="CamlView"/></returns>
        public CamlView Joins(Action<CamlJoins> action)
        {
            var joins = new CamlJoins();
            action(joins);
            Childs.Add(joins);
            return this;
        }
    }
}