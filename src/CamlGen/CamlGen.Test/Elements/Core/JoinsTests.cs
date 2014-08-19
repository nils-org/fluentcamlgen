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
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    [TestFixture]
    public class JoinsTests : TestBase
    {
        [Test]
        public void BareJoinsReturnsAJoinsTagWithNoAttributes()
        {
            var sut = CG.Joins();
            sut.ToString().Should().BeEquivalentTo(@"<Joins />");
        }

        [Test]
        public void EmptyJoinsReturnsAJoinsTagWithNoAttributes()
        {
            var sut = new Joins();
            sut.ToString().Should().BeEquivalentTo(@"<Joins />");
        }

        [Test]
        public void AddJoinReturnsAJoinsTagWithAJoinAndAnEmptyEqTag()
        {
            var list = Fixture.Create<string>();
            var sut = new Joins();
            sut.AddJoin(list, Join.JoinType.Left, x => { });
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<Joins><Join Type=""LEFT"" ListAlias=""{0}""><Eq /></Join></Joins>", list));
        }

        [Test]
        public void AddInnerJoinReturnsAJoinsTagWithAnInnerJoinAndAnEmptyEqTag()
        {
            var list = Fixture.Create<string>();
            var field = Fixture.Create<string>();
            var sut = new Joins();
            sut.AddInnerJoin(list, field);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<Joins><Join Type=""INNER"" ListAlias=""{0}""><Eq><FieldRef Name=""{1}"" RefType=""Id"" /><FieldRef Name=""ID"" List=""{0}"" /></Eq></Join></Joins>", list, field));
        }
    }
}