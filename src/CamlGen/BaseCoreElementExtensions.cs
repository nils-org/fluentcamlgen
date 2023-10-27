/*
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;
using FluentCamlGen.CamlGen.Elements.Core;

namespace FluentCamlGen.CamlGen
{
    /// <summary>
    /// Extensions on all BaseCoreElements.
    /// </summary>
    public static class BaseCoreElementExtensions
    {
        /// <summary>
        /// Add An Attribute.
        /// </summary>
        /// <param name="this">The extended <see cref="BaseCoreElement"/>.</param>
        /// <param name="name">Attribute Name.</param>
        /// <param name="value">Attribute Value.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns>The extended <see cref="BaseCoreElement"/>, for fluent re-use.</returns>
        public static T AddAttribute<T>(this T @this, string name, string value)
            where T : BaseCoreElement
        {
            @this.Attributes.Add(new Tuple<string, string>(name, value));
            return @this;
        }
    }
}
