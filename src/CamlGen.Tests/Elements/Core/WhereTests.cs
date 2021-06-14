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
    
    public class WhereTests : TestBase
    {
        [Fact]
        public void CgWhereReturnsAnEmptyWhereTag()
        {
            var sut = CG.Where();
            sut.ToString().ShouldBe(@"<Where />");
        }

        [Fact]
        public void WhereCanAddAnd()
        {
            var sut = new Where();
            sut.And();

            sut.ToString().ShouldBe(@"<Where><And /></Where>");
        }

        [Fact]
        public void WhereCanAddOr()
        {
            var sut = new Where();
            sut.Or(x => { });

            sut.ToString().ShouldBe(@"<Where><Or /></Where>");
        }

        [Fact]
        public void WhereCanAddEq()
        {
            var sut = new Where().Eq(x => { });
            sut.ToString().ShouldBe(@"<Where><Eq /></Where>");
        }

        [Fact]
        public void WhereCanAddNeq()
        {
            var sut = new Where().Neq(x => { });
            sut.ToString().ShouldBe(@"<Where><Neq /></Where>");
        }

        [Fact]
        public void WhereCanAddGt()
        {
            var sut = new Where().Gt(x => { });
            sut.ToString().ShouldBe(@"<Where><Gt /></Where>");
        }

        [Fact]
        public void WhereCanAddGeq()
        {
            var sut = new Where().Geq(x => { });
            sut.ToString().ShouldBe(@"<Where><Geq /></Where>");
        }

        [Fact]
        public void WhereCanAddLt()
        {
            var sut = new Where().Lt(x => { });
            sut.ToString().ShouldBe(@"<Where><Lt /></Where>");
        }

        [Fact]
        public void WhereCanAddLeq()
        {
            var sut = new Where().Leq(x => { });
            sut.ToString().ShouldBe(@"<Where><Leq /></Where>");
        }
    }
}