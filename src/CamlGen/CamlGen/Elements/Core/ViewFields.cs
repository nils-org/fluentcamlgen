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
    /// Create &lt;ViewFields> ... &lt;/ViewFields>
    /// </summary>
    public class ViewFields : BaseCoreElement
    {
        internal ViewFields()
            : this(null)
        {
        }

        internal ViewFields(IEnumerable<BaseElement> inner)
            : base("ViewFields", null, inner)
        {
        }

        /// <summary>
        /// Add a FieldRef
        /// </summary>
        /// <returns>Fluent <see cref="ViewFields"/></returns>
        public ViewFields AddFieldRef(string name)
        {
            return AddFieldRef(name, x => { });
        }

        /// <summary>
        /// Add a FieldRef
        /// </summary>
        /// <returns>Fluent <see cref="ViewFields"/></returns>
        public ViewFields AddFieldRef(string name, Action<FieldRef> fieldRefAction)
        {
            var fieldRef = new FieldRef(name);
            fieldRefAction(fieldRef);
            Childs.Add(fieldRef);
            return this;
        }
    }
}