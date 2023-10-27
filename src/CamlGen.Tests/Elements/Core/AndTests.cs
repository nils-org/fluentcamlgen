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

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    public class AndTests : TestBase
    {
        [Fact]
        public void SimpleAndReturnsEmptyAndTag()
        {
            var sut = CG.And();
            sut.ToString().ShouldBe(@"<And />");
        }

        [Fact]
        public void EqOnAndReturnsAnEqTagInAnAndTag()
        {
            var sut = new And();
            sut.Eq();

            sut.ToString().ShouldBe(@"<And><Eq /></And>");
        }

        [Fact]
        public void NeqOnAndReturnsAnNeqTagInAnAndTag()
        {
            var sut = new And();
            sut.Neq();

            sut.ToString().ShouldBe(@"<And><Neq /></And>");
        }

        [Fact]
        public void GeqOnAndReturnsAnGeqTagInAnAndTag()
        {
            var sut = new And();
            sut.Geq();

            sut.ToString().ShouldBe(@"<And><Geq /></And>");
        }

        [Fact]
        public void GtOnAndReturnsAnGtTagInAnAndTag()
        {
            var sut = new And();
            sut.Gt();

            sut.ToString().ShouldBe(@"<And><Gt /></And>");
        }

        [Fact]
        public void LeqOnAndReturnsAnLeqTagInAnAndTag()
        {
            var sut = new And();
            sut.Leq();

            sut.ToString().ShouldBe(@"<And><Leq /></And>");
        }

        [Fact]
        public void LtOnAndReturnsAnLtTagInAnAndTag()
        {
            var sut = new And();
            sut.Lt();

            sut.ToString().ShouldBe(@"<And><Lt /></And>");
        }

        [Fact]
        public void OrOnAndReturnsAnOrTagInAnAndTag()
        {
            var sut = new And();
            sut.Or(x => { });

            sut.ToString().ShouldBe(@"<And><Or /></And>");
        }

        [Fact]
        public void NestedAndOnAndReturnsAnAndTagInAnAndTag()
        {
            var sut = new And();
            sut.And(x => { });

            sut.ToString().ShouldBe(@"<And><And /></And>");
        }
    }
}
