/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using System.Collections.Generic;

namespace FluentCamlGen.CamlGen.Elements.Core
{
    /// <summary>
    /// Create &lt;ProjectedFields> ... &lt;/ProjectedFields>
    /// </summary>
    public class ProjectedFields : BaseCoreElement
    {
        internal ProjectedFields()
            : this(null)
        {
        }

        internal ProjectedFields(IEnumerable<BaseElement> inner)
            : base("ProjectedFields", null, inner)
        {
        }

        /// <summary>
        /// Add a (projected) Field
        /// </summary>
        /// <returns>Fluent <see cref="ProjectedFields"/></returns>
        public ProjectedFields AddField(string name, string type, string list, string showField)
        {
            var field = new ProjectedField(name, type, list, showField);
            Childs.Add(field);
            return this;
        }
    }
}