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
        public Where And(Action<And> action)
        {
            var and = new And();
            action(and);
            Childs.Add(and);
            return this;
        }

        /// <summary>
        /// Add an &lt;Or>-Tag
        /// </summary>
        /// <returns><see cref="Where"/></returns>
        public Where Or(Action<Or> action)
        {
            var or = new Or();
            action(or);
            Childs.Add(or);
            return this;
        }

        /// <summary>
        /// Add an &lt;Eq>-Tag
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Where Eq(Action<Eq> action)
        {
            var eq = new Eq();
            action(eq);
            Childs.Add(eq);
            return this;
        }

        /// <summary>
        /// Add an &lt;Neq>-Tag
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Where Neq(Action<Neq> action)
        {
            var neq = new Neq();
            action(neq);
            Childs.Add(neq);
            return this;
        }

        /// <summary>
        /// Add an &lt;Gt>-Tag
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Where Gt(Action<Gt> action)
        {
            var gt = new Gt();
            action(gt);
            Childs.Add(gt);
            return this;
        }

        /// <summary>
        /// Add an &lt;Geq>-Tag
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Where Geq(Action<Geq> action)
        {
            var geq = new Geq();
            action(geq);
            Childs.Add(geq);
            return this;
        }

        /// <summary>
        /// Add an &lt;Lt>-Tag
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Where Lt(Action<Lt> action)
        {
            var lt = new Lt();
            action(lt);
            Childs.Add(lt);
            return this;
        }

        /// <summary>
        /// Add an &lt;Leq>-Tag
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Where Leq(Action<Leq> action)
        {
            var leq = new Leq();
            action(leq);
            Childs.Add(leq);
            return this;
        }
    }
}