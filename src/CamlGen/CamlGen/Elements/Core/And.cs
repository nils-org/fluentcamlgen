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
    /// &lt;And> ... &lt;/And>
    /// </summary>
    public class And : BaseCoreElement
    {
        internal And()
            : this(null)
        {
        }

        internal And(IEnumerable<BaseElement> inner)
            : base("And", null, inner)
        {
        }

        /// <summary>
        /// Add an &lt;Eq>-Tag
        /// </summary>
        /// <returns><see cref="And"/></returns>
        public And Eq()
        {
            return Eq(x => { });
        }

        /// <summary>
        /// Add an &lt;Eq>-Tag
        /// </summary>
        /// <returns><see cref="And"/></returns>
        public And Eq(Action<Eq> action)
        {
            var eq = new Eq();
            action(eq);
            Childs.Add(eq);
            return this;
        }
    }
}