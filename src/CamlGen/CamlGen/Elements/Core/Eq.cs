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
    /// &lt;Eq> ... &lt;/Eq>
    /// <seealso cref="http://msdn.microsoft.com/en-us/library/ms479601(v=office.15).aspx"/>
    /// </summary>
    public class Eq : BaseCoreElement
    {
        internal Eq()
            : base("Eq", null, (IEnumerable<BaseElement>) null)
        {
        }

        internal Eq(BaseElement lhs, BaseElement rhs)
            : this()
        {
            Childs.Add(lhs);
            Childs.Add(rhs);
        }

        public Eq AddFieldRef(string name, Action<FieldRef> action)
        {
            var fieldRef = new FieldRef(name);
            action(fieldRef);
            Childs.Add(fieldRef);
            return this;
        }

        //TODO: AddValue Fehlt !!!
    }
}