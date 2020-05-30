/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using AutoFixture;

using FluentAssertions;

using FluentCamlGen.CamlGen.Elements.Core;

using NUnit.Framework;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    [TestFixture]
    public class JoinTests : TestBase
    {
        [Test]
        public void BareJoinReturnsAJoinTagWithNoAttributes()
        {
            var list = Fixture.Create<string>();
            var lhs = Fixture.Create<BaseCoreElement>();
            var rhs = Fixture.Create<BaseCoreElement>();

            var sut = CG.Join(list, CG.JoinType.Inner, lhs, rhs);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<Join Type=""INNER"" ListAlias=""{0}""><Eq>{1}{2}</Eq></Join>", list, lhs, rhs));
        }

        [Test]
        public void InnerJoinProducesAJoinElementWithTheTypeOfInner()
        {
            var list = Fixture.Create<string>();
            var field = Fixture.Create<string>();

            var sut = CG.InnerJoin(list, field);
            sut.ToString(false).Should().BeEquivalentTo(string.Format(@"<Join Type=""INNER"" ListAlias=""{0}""><Eq><FieldRef Name=""{1}"" RefType=""Id"" /><FieldRef Name=""ID"" List=""{0}"" /></Eq></Join>", list, field));
        }

        [Test]
        public void JoinWithJoinTypeAndOneStringProducesAJoinElementWithTheTypeAndListAlias()
        {
            var list = Fixture.Create<string>();
            var field = Fixture.Create<string>();

            var sut = CG.Join(list, CG.JoinType.Left, field);
            sut.ToString(false).Should().BeEquivalentTo(string.Format(@"<Join Type=""LEFT"" ListAlias=""{0}""><Eq><FieldRef Name=""{1}"" RefType=""Id"" /><FieldRef Name=""ID"" List=""{0}"" /></Eq></Join>", list, field));
        }

        [Test]
        public void AddFieldRefAddsAFieldRefToTheElement()
        {
            var field = Fixture.Create<string>();
            var list = Fixture.Create<string>();
            var sut = new Join(list, CG.JoinType.Left);
            sut.AddFieldRef(field, x => { });

            sut.ToString().Should().BeEquivalentTo(string.Format(@"<Join Type=""LEFT"" ListAlias=""{0}""><Eq><FieldRef Name=""{1}"" /></Eq></Join>", list, field));
        }
    }
}