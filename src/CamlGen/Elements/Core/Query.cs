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

namespace FluentCamlGen.CamlGen.Elements.Core
{
    /// <summary>
    /// Create &lt;Query> ... &lt;/Query>.
    /// </summary>
    public class Query : BaseCoreElement
    {
        internal Query()
            : this(null)
        {
        }

        internal Query(IEnumerable<BaseElement> inner)
            : base("Query", null, inner)
        {
        }

        /// <summary>
        /// Add a &lt;Where>-Tag.
        /// </summary>
        /// <returns><see cref="Query"/>.</returns>
        public Query Where()
        {
            return Where(x => { });
        }

        /// <summary>
        /// Add a &lt;Where>-Tag.
        /// </summary>
        /// <param name="action">Fluent configuration of the <see cref="Where"/>.</param>
        /// <returns><see cref="Query"/>.</returns>
        public Query Where(Action<Where> action)
        {
            var where = new Where();
            action(where);
            Childs.Add(where);
            return this;
        }

        /// <summary>
        /// Add a &lt;OrderBy>-Tag.
        /// </summary>
        /// <param name="action">Fluent configuration of the <see cref="Where"/>.</param>
        /// <returns><see cref="Query"/>.</returns>
        public Query OrderBy(Action<OrderBy> action)
        {
            var order = new OrderBy();
            action(order);
            Childs.Add(order);
            return this;
        }
    }
}
