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

using NUnit.Framework;

using Ploeh.AutoFixture;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    [TestFixture]
    public class OrderByTests : TestBase
    {
        [Test]
        public void BareOrderByJoinReturnsAJoinTagWithNoAttributes()
        {
            var sut = CG.OrderBy();
            sut.ToString().Should().BeEquivalentTo(@"<OrderBy />");
        }

        [Test]
        public void OrderByWithFieldRefRetunsAnOrderByAndAFieldRef()
        {
            var name = Fixture.Create<string>();
            var sut = CG.OrderBy().AddFieldRefDescending(name);
            var expected = string.Format(@"<OrderBy><FieldRef Name=""{0}"" Ascending=""FALSE"" /></OrderBy>", name).AsXml();
            sut.ToString().AsXml().Should().BeLooselyEquivalentTo(expected);
        }

        [Test]
        public void OrderByWithFieldRefAscendingRetunsAnOrderByAndAnAscendingFieldRef()
        {
            var name = Fixture.Create<string>();
            var sut = CG.OrderBy().AddFieldRefAscending(name);
            var expected = string.Format(@"<OrderBy><FieldRef Name=""{0}"" Ascending=""TRUE"" /></OrderBy>", name).AsXml();
            sut.ToString().AsXml().Should().BeLooselyEquivalentTo(expected);
        }

        [Test]
        public void FluentOrderByWithFieldRefRetunsAnOrderByAndAFieldRef()
        {
            var name = Fixture.Create<string>();
            var sut = CG.Query().OrderBy(o => o.AddFieldRef(name, false));
            var expected = string.Format(@"<Query><OrderBy><FieldRef Name=""{0}"" Ascending=""FALSE"" /></OrderBy></Query>", name).AsXml();
            sut.ToString().AsXml().Should().BeLooselyEquivalentTo(expected);
        }
    }
}