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
    /// &lt;Where> ... &lt;/Where>
    /// </summary>
    public class Where : BaseCoreElement
    {
        internal Where()
            : this(null)
        {
        }

        internal Where(IEnumerable<BaseElement> inner)
            : base("Where", null, inner)
        {
        }

        /// <summary>
        /// Add an &lt;And>-Tag
        /// </summary>
        /// <returns><see cref="Where"/></returns>
        public Where And()
        {
            return And(x => { });
        }

        /// <summary>
        /// Add an &lt;And>-Tag
        /// </summary>
        /// <returns><see cref="Where"/></returns>
        public Where And(Action<And> action)
        {
            var and = new And();
            action(and);
            Childs.Add(and);
            return this;
        }
    }
}