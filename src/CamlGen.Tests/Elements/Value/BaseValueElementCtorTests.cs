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

using FluentCamlGen.CamlGen.Elements.Value;
using Moq;
using Xunit;

namespace FluentCamlGen.CamlGen.Test.Elements.Value
{
    
    public class BaseValueElementCtorTests : TestBase
    {
        [Fact]
        public void AnEmptyTagoutReturnsTheBareTag()
        {
            var tag = Fixture.Create<string>();
            var sut = new Mock<BaseValueElement>(tag, string.Empty)
            {
                CallBase = true
            };
            var actual = sut.Object.ToString(false, 0);
            actual.ShouldBe(string.Format(@"<{0}></{0}>", tag));
        }

        [Fact]
        public void CamlTagAttributeReturnsTheTagAndTheAttribute()
        {
            var tag = Fixture.Create<string>();
            var value = Fixture.Create<string>();

            var sut = new Mock<BaseValueElement>(tag, value)
            {
                CallBase = true
            };
            sut.Object.ToString().ShouldBe(string.Format(@"<{0}>{1}</{0}>", tag, value));
        }
    }
}
