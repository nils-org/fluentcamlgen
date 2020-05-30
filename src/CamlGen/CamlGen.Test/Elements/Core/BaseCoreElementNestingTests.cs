/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using FluentAssertions;

using FluentCamlGen.CamlGen.Elements.Core;

using NSubstitute;

using NUnit.Framework;

using Ploeh.AutoFixture;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    [TestFixture]
    public class BaseCoreElementNestingTests : TestBase
    {
        [Test]
        public void NestedElementsReturnsTheNestedTags()
        {
            var outerTag = Fixture.Create<string>();
            var innerTag = Fixture.Create<string>();

            var sut = Substitute.ForPartsOf<BaseCoreElement>(outerTag);
            sut.Childs.Add(Substitute.ForPartsOf<BaseCoreElement>(innerTag));

            sut.ToString().Should().BeEquivalentTo(string.Format(@"<{0}><{1} /></{0}>", outerTag, innerTag));
        }

        [Test]
        public void DeepNestedElementsReturnsTheDeepNestedTags()
        {
            var outerTag = Fixture.Create<string>();
            var middleTag = Fixture.Create<string>();
            var innerTag = Fixture.Create<string>();

            var outerSut = Substitute.ForPartsOf<BaseCoreElement>(outerTag);
            var middleSut = Substitute.ForPartsOf<BaseCoreElement>(middleTag);
            middleSut.Childs.Add(Substitute.ForPartsOf<BaseCoreElement>(innerTag));
            outerSut.Childs.Add(middleSut);

            outerSut.ToString().Should().BeEquivalentTo(string.Format(@"<{0}><{1}><{2} /></{1}></{0}>", outerTag, middleTag, innerTag));
        }
    }
}