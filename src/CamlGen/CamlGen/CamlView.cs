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

namespace FluentCamlGen.CamlGen
{
    /// <summary>
    /// Create &lt;View> ... &lt;/View> for ViewXml
    /// </summary>
    internal class CamlView : CG
    {
        internal CamlView(IEnumerable<CG> inner)
            : base("View", null, inner)
        {
        }
    }
}