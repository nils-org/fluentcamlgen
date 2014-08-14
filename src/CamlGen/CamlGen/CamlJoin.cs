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
    /// Create &lt;Join Type="INNER" ListAlias="...">
    /// </summary>
    public class CamlJoin : CG
    {
        //TODO: What about other Join-Types??
        public CamlJoin(string listName, IEnumerable<CG> inner)
            : base("Join", new[]
                {
                    new Tuple<string, string>("Type", "INNER"),
                    new Tuple<string, string>("ListAlias", listName)
                }, inner)
        {
        }
    }
}