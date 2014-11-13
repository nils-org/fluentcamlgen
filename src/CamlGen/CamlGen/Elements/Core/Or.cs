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
    /// <see cref="http://msdn.microsoft.com/en-us/library/ms472196.aspx"/>
    /// </summary>
    public class Or : BaseCoreElement
    {
        internal Or()
            : this(null)
        {
        }

        internal Or(IEnumerable<BaseElement> inner)
            : base("Or", null, inner)
        {
        }

        /// <summary>
        /// Add an &lt;Eq>-Tag
        /// </summary>
        /// <returns><see cref="Or"/></returns>
        public Or Eq()
        {
            return Eq(x => { });
        }

        /// <summary>
        /// Add an &lt;Eq>-Tag
        /// </summary>
        /// <returns><see cref="Or"/></returns>
        public Or Eq(Action<Eq> action)
        {
            var eq = new Eq();
            action(eq);
            Childs.Add(eq);
            return this;
        }

        /// <summary>
        /// Add a &lt;Neq>-Tag
        /// </summary>
        /// <returns><see cref="Or"/></returns>
        public Or Neq()
        {
            return Neq(x => { });
        }

        /// <summary>
        /// Add a &lt;Neq>-Tag
        /// </summary>
        /// <returns><see cref="Or"/></returns>
        public Or Neq(Action<Neq> action)
        {
            var neq = new Neq();
            action(neq);
            Childs.Add(neq);
            return this;
        }

        /// <summary>
        /// Add a &lt;Gt>-Tag
        /// </summary>
        /// <returns><see cref="Or"/></returns>
        public Or Gt()
        {
            return Gt(x => { });
        }

        /// <summary>
        /// Add a &lt;Gt>-Tag
        /// </summary>
        /// <returns><see cref="Or"/></returns>
        public Or Gt(Action<Gt> action)
        {
            var gt = new Gt();
            action(gt);
            Childs.Add(gt);
            return this;
        }

        /// <summary>
        /// Add a &lt;Geq>-Tag
        /// </summary>
        /// <returns><see cref="Or"/></returns>
        public Or Geq()
        {
            return Geq(x => { });
        }

        /// <summary>
        /// Add a &lt;Geq>-Tag
        /// </summary>
        /// <returns><see cref="Or"/></returns>
        public Or Geq(Action<Geq> action)
        {
            var geq = new Geq();
            action(geq);
            Childs.Add(geq);
            return this;
        }

        /// <summary>
        /// Add a &lt;Lt>-Tag
        /// </summary>
        /// <returns><see cref="Or"/></returns>
        public Or Lt()
        {
            return Lt(x => { });
        }

        /// <summary>
        /// Add a &lt;Lt>-Tag
        /// </summary>
        /// <returns><see cref="Or"/></returns>
        public Or Lt(Action<Lt> action)
        {
            var lt = new Lt();
            action(lt);
            Childs.Add(lt);
            return this;
        }

        /// <summary>
        /// Add a &lt;Leq>-Tag
        /// </summary>
        /// <returns><see cref="Or"/></returns>
        public Or Leq()
        {
            return Leq(x => { });
        }

        /// <summary>
        /// Add a &lt;Leq>-Tag
        /// </summary>
        /// <returns><see cref="Or"/></returns>
        public Or Leq(Action<Leq> action)
        {
            var leq = new Leq();
            action(leq);
            Childs.Add(leq);
            return this;
        }

        /// <summary>
        /// Add an &lt;And>-Tag
        /// </summary>
        /// <returns><see cref="Or"/></returns>
        public Or And(Action<And> action)
        {
            var and = new And();
            action(and);
            Childs.Add(and);
            return this;
        }

        /// <summary>
        /// Add a nested &lt;Or>-Tag
        /// </summary>
        /// <returns><see cref="Or"/></returns>
        public Or NestedOr(Action<Or> action)
        {
            var or = new Or();
            action(or);
            Childs.Add(or);
            return this;
        }
    }
}