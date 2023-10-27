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

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    
    public class JoinsTests : TestBase
    {
        [Fact]
        public void BareJoinsReturnsAJoinsTagWithNoAttributes()
        {
            var sut = CG.Joins();
            sut.ToString().ShouldBe(@"<Joins />");
        }

        [Fact]
        public void EmptyJoinsReturnsAJoinsTagWithNoAttributes()
        {
            var sut = new Joins();
            sut.ToString().ShouldBe(@"<Joins />");
        }

        [Fact]
        public void AddJoinReturnsAJoinsTagWithAJoinAndAnEmptyEqTag()
        {
            var list = Fixture.Create<string>();
            var sut = new Joins();
            sut.AddJoin(list, CG.JoinType.Left, x => { });
            sut.ToString().ShouldBe(string.Format(@"<Joins><Join Type=""LEFT"" ListAlias=""{0}""><Eq /></Join></Joins>", list));
        }

        [Fact]
        public void AddInnerJoinReturnsAJoinsTagWithAnInnerJoinAndAnEmptyEqTag()
        {
            var list = Fixture.Create<string>();
            var field = Fixture.Create<string>();
            var sut = new Joins();
            sut.AddInnerJoin(list, field);
            sut.ToString().ShouldBe(string.Format(@"<Joins><Join Type=""INNER"" ListAlias=""{0}""><Eq><FieldRef Name=""{1}"" RefType=""Id"" /><FieldRef Name=""ID"" List=""{0}"" /></Eq></Join></Joins>", list, field));
        }
    }
}
