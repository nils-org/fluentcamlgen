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
    
    public class QueryTests : TestBase
    {
        [Fact]
        public void BareCgQueryReturnsAQueryTagWithNoAttributes()
        {
            var sut = CG.Query();
            sut.ToString().ShouldBe(@"<Query />");
        }

        [Fact]
        public void AnEmptyQueryReturnsAQueryTagWithNoAttributes()
        {
            var sut = new Query();
            sut.ToString().ShouldBe(@"<Query />");
        }

        [Fact]
        public void WhereOnAnQueryReturnsAQueryTagWithANestedWhereTag()
        {
            var sut = new Query();
            sut.Where();
            sut.ToString().ShouldBe(@"<Query><Where /></Query>");
        }
    }
}