/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using Shouldly;

using FluentCamlGen.CamlGen.Elements.Core;

using Xunit;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    
    public class OrTests : TestBase
    {
        [Fact]
        public void SimpleOrReturnsEmptyOrTag()
        {
            var sut = CG.Or();
            sut.ToString().ShouldBe(@"<Or />");
        }

        [Fact]
        public void EqOnOrReturnsAnEqTagInAnOrTag()
        {
            var sut = new Or();
            sut.Eq();

            sut.ToString().ShouldBe(@"<Or><Eq /></Or>");
        }

        [Fact]
        public void NeqOnOrReturnsAnNeqTagInAnOrTag()
        {
            var sut = new Or();
            sut.Neq();

            sut.ToString().ShouldBe(@"<Or><Neq /></Or>");
        }

        [Fact]
        public void GeqOnOrReturnsAnGeqTagInAnOrTag()
        {
            var sut = new Or();
            sut.Geq();

            sut.ToString().ShouldBe(@"<Or><Geq /></Or>");
        }

        [Fact]
        public void GtOnOrReturnsAnGtTagInAnOrTag()
        {
            var sut = new Or();
            sut.Gt();

            sut.ToString().ShouldBe(@"<Or><Gt /></Or>");
        }

        [Fact]
        public void LeqOnOrReturnsAnLeqTagInAnOrTag()
        {
            var sut = new Or();
            sut.Leq();

            sut.ToString().ShouldBe(@"<Or><Leq /></Or>");
        }

        [Fact]
        public void LtOnOrReturnsAnLtTagInAnOrTag()
        {
            var sut = new Or();
            sut.Lt();

            sut.ToString().ShouldBe(@"<Or><Lt /></Or>");
        }

        [Fact]
        public void NestedOrOnOrReturnsAnOrTagInAnOrTag()
        {
            var sut = new Or();
            sut.Or(x => { });

            sut.ToString().ShouldBe(@"<Or><Or /></Or>");
        }

        [Fact]
        public void AndOnOrReturnsAnAndTagInAnOrTag()
        {
            var sut = new Or();
            sut.And(x => { });

            sut.ToString().ShouldBe(@"<Or><And /></Or>");
        }
    }
}