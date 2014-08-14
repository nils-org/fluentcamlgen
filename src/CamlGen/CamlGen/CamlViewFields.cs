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
    /// Create &lt;ViewFields> ... &lt;/ViewFields>
    /// </summary>
    public class CamlViewFields : CG
    {
        internal CamlViewFields()
            : this(null)
        {
        }

        internal CamlViewFields(IEnumerable<CG> inner)
            : base("ViewFields", null, inner)
        {
        }

        /// <summary>
        /// Add a FieldRef
        /// </summary>
        /// <returns>Fluent <see cref="CamlViewFields"/></returns>
        public CamlViewFields AddFieldRef(string name)
        {
            return AddFieldRef(name, x => { });
        }

        /// <summary>
        /// Add a FieldRef
        /// </summary>
        /// <returns>Fluent <see cref="CamlViewFields"/></returns>
        public CamlViewFields AddFieldRef(string name, Action<CamlFieldRef> fieldRefAction)
        {
            var fieldRef = new CamlFieldRef(name);
            fieldRefAction(fieldRef);
            Childs.Add(fieldRef);
            return this;
        }
    }
}