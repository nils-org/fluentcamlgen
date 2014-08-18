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
    /// &lt;Eq> ... &lt;/Eq>
    /// <seealso cref="http://msdn.microsoft.com/en-us/library/ms479601(v=office.15).aspx"/>
    /// </summary>
    public class CamlEq : BaseCamlTag
    {
        internal CamlEq()
            : base("Eq", null, (IEnumerable<ITag>) null)
        {
        }

        internal CamlEq(ITag lhs, ITag rhs)
            : this()
        {
            Childs.Add(lhs);
            Childs.Add(rhs);
        }

        public CamlEq AddFieldRef(string name, Action<CamlFieldRef> action)
        {
            var fieldRef = new CamlFieldRef(name);
            action(fieldRef);
            Childs.Add(fieldRef);
            return this;
        }

        //TODO: AddValue Fehlt !!!
    }
}