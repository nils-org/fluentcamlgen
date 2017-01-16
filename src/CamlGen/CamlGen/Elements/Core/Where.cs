/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

namespace FluentCamlGen.CamlGen.Elements.Core
{
    /// <summary>
    /// &lt;Where> ... &lt;/Where>
    /// </summary>
    public class Where : BaseCoreComparingGroupElement<Where>
    {
        internal Where(params BaseElement[] inner)
            : base("Where", inner)
        {
        }

    }
}