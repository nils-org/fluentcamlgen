/*
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
*/

using System.Collections.Generic;

namespace FluentCamlGen.CamlGen.Elements.Core
{
    /// <summary>
    /// Create &lt;ProjectedFields> ... &lt;/ProjectedFields>.
    /// <seealso href="https://learn.microsoft.com/en-us/sharepoint/dev/schema/projectedfields-element-view"/>
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
        /// Add a (projected) Field.
        /// </summary>
        /// <param name="name">Name of the joined field.</param>
        /// <param name="type">As of SharePoint Foundation 2010, all joins must be based on an existing lookup relation, so Type always has the value "Lookup".</param>
        /// <param name="list">Name of the joined list.</param>
        /// <param name="showField">Internal name of the field that should be shown.</param>
        /// <returns>Fluent <see cref="ProjectedFields"/>.</returns>
        public ProjectedFields AddField(string name, string type, string list, string showField)
        {
            var field = new ProjectedField(name, type, list, showField);
            Childs.Add(field);
            return this;
        }
    }
}
