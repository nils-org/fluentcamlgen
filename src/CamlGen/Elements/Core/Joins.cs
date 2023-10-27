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
    /// Create &lt;Joins> ... &lt;/Joins>.
    /// <seealso href="https://learn.microsoft.com/en-us/sharepoint/dev/schema/joins-element-view"/>
    /// </summary>
    public class Joins : BaseCoreElement
    {
        internal Joins()
            : this(null)
        {
        }

        internal Joins(IEnumerable<BaseElement> inner)
            : base("Joins", null, inner)
        {
        }

        /// <summary>
        /// Add Join.
        /// </summary>
        /// <param name="listName">Name of the list to join.</param>
        /// <param name="type">A <see cref="CG.JoinType"/>.</param>
        /// <param name="action">Fluent configuration of the <see cref="Join"/>.</param>
        /// <returns>Fluent <see cref="Joins"/>.</returns>
        public Joins AddJoin(string listName, CG.JoinType type, Action<Join> action)
        {
            var join = new Join(listName, type);
            action(join);
            Childs.Add(join);
            return this;
        }

        /// <summary>
        /// Add Inner-Join.
        /// </summary>
        /// <param name="listName">Name of the list to join.</param>
        /// <param name="fieldName">Name of the field to join on.</param>
        /// <returns>Fluent <see cref="Joins"/>.</returns>
        public Joins AddInnerJoin(string listName, string fieldName)
        {
            return AddInnerJoin(listName, fieldName, x => { });
        }

        /// <summary>
        /// Add Inner-Join.
        /// </summary>
        /// <param name="listName">Name of the list to join.</param>
        /// <param name="fieldName">Name of the field to join on.</param>
        /// <param name="action">Fluent configuration of the <see cref="Join"/>.</param>
        /// <returns>Fluent <see cref="Joins"/>.</returns>
        public Joins AddInnerJoin(string listName, string fieldName, Action<Join> action)
        {
            var join = new Join(listName, CG.JoinType.Inner, fieldName);
            action(join);
            Childs.Add(join);
            return this;
        }
    }
}
