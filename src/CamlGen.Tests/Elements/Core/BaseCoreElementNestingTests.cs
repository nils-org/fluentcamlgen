/*
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
*/

using AutoFixture;

using Shouldly;

using FluentCamlGen.CamlGen.Elements.Core;
using Moq;

using Xunit;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    
    public class BaseCoreElementNestingTests : TestBase
    {
        [Fact]
        public void NestedElementsReturnsTheNestedTags()
        {
            var outerTag = Fixture.Create<string>();
            var innerTag = Fixture.Create<string>();

            var sut = new Mock<BaseCoreElement>(outerTag) {CallBase = true}.Object;
            sut.Childs.Add(new Mock<BaseCoreElement>(innerTag) {CallBase = true}.Object);

            sut.ToString().ShouldBe(string.Format(@"<{0}><{1} /></{0}>", outerTag, innerTag));
        }

        [Fact]
        public void DeepNestedElementsReturnsTheDeepNestedTags()
        {
            var outerTag = Fixture.Create<string>();
            var middleTag = Fixture.Create<string>();
            var innerTag = Fixture.Create<string>();

            var outerSut = new Mock<BaseCoreElement>(outerTag){CallBase = true}.Object;
            var middleSut = new Mock<BaseCoreElement>(middleTag){CallBase = true}.Object;
            middleSut.Childs.Add(new Mock<BaseCoreElement>(innerTag){CallBase = true}.Object);
            outerSut.Childs.Add(middleSut);

            outerSut.ToString().ShouldBe(string.Format(@"<{0}><{1}><{2} /></{1}></{0}>", outerTag, middleTag, innerTag));
        }
    }
}
