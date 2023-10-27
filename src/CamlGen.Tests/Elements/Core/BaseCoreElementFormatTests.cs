/*
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
*/

using Shouldly;

using FluentCamlGen.CamlGen.Elements.Core;

using Xunit;

using System;
using Moq;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    
    public class BaseCoreElementFormatTests : TestBase
    {
        [Fact]
        public void TwoNestedTagWithoutFormattingReturnAStringWithoutFormatting()
        {
            var one = new Mock<BaseCoreElement>("One"){CallBase = true}.Object;
            var two = new Mock<BaseCoreElement>("Two"){CallBase = true}.Object;
            one.Childs.Add(two);

            var actual = one.ToString(false);
            actual.ShouldBe("<One><Two /></One>");
        }

        [Fact]
        public void TwoNestedTagWithFormattingReturnAStringWithFormatting()
        {
            var one = new Mock<BaseCoreElement>("One"){CallBase = true}.Object;
            var two = new Mock<BaseCoreElement>("Two"){CallBase = true}.Object;
            one.Childs.Add(two);

            var actual = one.ToString(true);
            actual.ShouldBe(string.Format("<One>{0}  <Two />{0}</One>{0}", Environment.NewLine));
        }
    }
}
