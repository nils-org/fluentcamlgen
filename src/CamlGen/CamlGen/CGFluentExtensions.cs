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

namespace FluentCamlGen.CamlGen
{
    public static class CGFluentExtensions
    {
        public static T AddAttribute<T>(this T @this, string name, string value)
            where T : CG
        {
            @this.Attributes.Add(new Tuple<string, string>(name, value));
            return @this;
        }
    }
}