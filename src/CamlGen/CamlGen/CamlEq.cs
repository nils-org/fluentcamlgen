/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

namespace FluentCamlGen.CamlGen
{
    /// <summary>
    /// &lt;Eq> ... &lt;/Eq>
    /// </summary>
    public class CamlEq : CG
    {
        //TODO: Is this really alwas left & right??
        public CamlEq(CG lhs, CG rhs)
            : base("Eq", null, new[] {lhs, rhs})
        {
        }
    }
}