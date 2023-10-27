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
using Xunit;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    
    public class OrderByTests : TestBase
    {
        [Fact]
        public void BareOrderByJoinReturnsAJoinTagWithNoAttributes()
        {
            var sut = CG.OrderBy();
            sut.ToString().ShouldBe(@"<OrderBy />");
        }

        [Fact]
        public void OrderByWithFieldRefReturnsAnOrderByAndAFieldRef()
        {
            var name = Fixture.Create<string>();
            var sut = CG.OrderBy().AddFieldRefDescending(name);
            var expected = string.Format(@"<OrderBy><FieldRef Name=""{0}"" Ascending=""FALSE"" /></OrderBy>", name).AsXml();
            sut.ToString().AsXml().ShouldBe(expected);
        }

        [Fact]
        public void OrderByWithFieldRefAscendingReturnsAnOrderByAndAnAscendingFieldRef()
        {
            var name = Fixture.Create<string>();
            var sut = CG.OrderBy().AddFieldRefAscending(name);
            var expected = string.Format(@"<OrderBy><FieldRef Name=""{0}"" Ascending=""TRUE"" /></OrderBy>", name).AsXml();
            sut.ToString().AsXml().ShouldBe(expected);
        }

        [Fact]
        public void FluentOrderByWithFieldRefReturnsAnOrderByAndAFieldRef()
        {
            var name = Fixture.Create<string>();
            var sut = CG.Query().OrderBy(o => o.AddFieldRef(name, false));
            var expected = string.Format(@"<Query><OrderBy><FieldRef Name=""{0}"" Ascending=""FALSE"" /></OrderBy></Query>", name).AsXml();
            sut.ToString().AsXml().ShouldBe(expected);
        }
    }
}
