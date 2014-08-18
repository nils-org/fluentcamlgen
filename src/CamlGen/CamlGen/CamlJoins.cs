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
    /// Create &lt;Joins> ... &lt;/Joins>
    /// </summary>
    public class CamlJoins : BaseCamlTag
    {
        internal CamlJoins()
            : this(null)
        {
        }

        internal CamlJoins(IEnumerable<ITag> inner)
            : base("Joins", null, inner)
        {
        }

        /// <summary>
        /// Add Join
        /// </summary>
        /// <returns>Fluent <see cref="CamlJoins"/></returns>
        public CamlJoins AddJoin(string listName, CamlJoin.JoinType type, Action<CamlJoin> action)
        {
            var join = new CamlJoin(listName, type);
            action(join);
            Childs.Add(join);
            return this;
        }

        /// <summary>
        /// Add Inner-Join
        /// </summary>
        /// <returns>Fluent <see cref="CamlJoins"/></returns>
        public CamlJoins AddInnerJoin(string listName, string fieldname)
        {
            return AddInnerJoin(listName, fieldname, x => { });
        }

        /// <summary>
        /// Add Inner-Join
        /// </summary>
        /// <returns>Fluent <see cref="CamlJoins"/></returns>
        public CamlJoins AddInnerJoin(string listName, string fieldname, Action<CamlJoin> action)
        {
            var join = new CamlJoin(listName, CamlJoin.JoinType.Inner, fieldname);
            action(join);
            Childs.Add(join);
            return this;
        }
    }
}