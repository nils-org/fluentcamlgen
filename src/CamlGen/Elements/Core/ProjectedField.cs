﻿/*
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;

namespace FluentCamlGen.CamlGen.Elements.Core
{
    /// <summary>
    /// Create &lt;Field Name="..." Type="..." List="..." ShowField="..." />.
    /// </summary>
    public class ProjectedField : BaseCoreElement
    {
        // TODO: Are Params always like this??
        internal ProjectedField(string name, string type, string list, string showField)
            : base(
                "Field",
                new[]
                {
                    new Tuple<string, string>("Name", name),
                    new Tuple<string, string>("Type", type),
                    new Tuple<string, string>("List", list),
                    new Tuple<string, string>("ShowField", showField),
                },
                null)
        {
        }
    }
}
