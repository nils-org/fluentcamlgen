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

using Xunit;

using System;
using Moq;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    
    public class BaseCoreElementCtorTests : TestBase
    {
        [Fact]
        public void ATagWithoutAdditionalParamsReturnsTheBareTag()
        {
            var tag = Fixture.Create<string>();
            var sut = new Mock<BaseCoreElement>(tag){CallBase = true}.Object;
            var actual = sut.ToString(false, 0);
            actual.ShouldBe($@"<{tag} />");
        }

        [Fact]
        public void ATagWithAnAttributeReturnsTheTagAndTheAttribute()
        {
            var tag = Fixture.Create<string>();
            var attrName = Fixture.Create<string>();
            var attrVal = Fixture.Create<string>();

            var sut = new Mock<BaseCoreElement>(tag, new Tuple<string, string>(attrName, attrVal)){CallBase = true}.Object;
            sut.ToString().ShouldBe($@"<{tag} {attrName}=""{attrVal}"" />");
        }

        [Fact]
        public void ATagWithAnInnerTagReturnsTheTagAndTheNested()
        {
            var tag = Fixture.Create<string>();
            var inner = Fixture.Create<BaseCoreElement>();

            var sut = new Mock<BaseCoreElement>(tag, inner){CallBase = true}.Object;
            sut.ToString().ShouldBe(string.Format(@"<{0}>{1}</{0}>", tag, inner));
        }

        [Fact]
        public void CamlTagAttributeAndInnerCgReturnsTheTagWithAttributeAndTheNestedCg()
        {
            var tag = Fixture.Create<string>();
            var attrName = Fixture.Create<string>();
            var attrVal = Fixture.Create<string>();
            var inner = Fixture.Create<BaseCoreElement>();
            var attrs = new[] { new Tuple<string, string>(attrName, attrVal) };
            var inners = new[] { inner };

            var sut = new Mock<BaseCoreElement>(tag, attrs, inners){CallBase = true}.Object;
            sut.ToString().ShouldBe(string.Format(@"<{0} {1}=""{2}"">{3}</{0}>", tag, attrName, attrVal, inner));
        }
    }
}
