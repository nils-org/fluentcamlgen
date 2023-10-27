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
    
    public class EqTests : TestBase
    {
        [Fact]
        public void BareEqReturnsAnEqTagWithNoAttributes()
        {
            var lhs = Fixture.Create<BaseCoreElement>();
            var rhs = Fixture.Create<BaseCoreElement>();
            var sut = CG.Eq(lhs, rhs);
            sut.ToString().ShouldBe(string.Format(@"<Eq>{0}{1}</Eq>", lhs, rhs));
        }

        [Fact]
        public void AddFieldRefAddsAFieldRefToTheElement()
        {
            var field = Fixture.Create<string>();
            var sut = new Eq();
            sut.AddFieldRef(field);

            sut.ToString().ShouldBe(string.Format(@"<Eq><FieldRef Name=""{0}"" /></Eq>", field));
        }

        [Fact]
        public void AddValueAddsAValueToTheElement()
        {
            var val = Fixture.Create<string>();
            var sut = new Eq();
            sut.AddValue(CG.ValueType.Number, val);

            sut.ToString().ShouldBe(string.Format(@"<Eq><Value Type=""Number"">{0}</Value></Eq>", val));
        }

        [Fact]
        public void AddNumberValueAddsANumerValueToTheElement()
        {
            var val = Fixture.Create<double>();
            var sut = new Eq();
            sut.AddNumberValue(val);

            sut.ToString().ShouldBe(string.Format(@"<Eq><Value Type=""Number"">{0}</Value></Eq>", val));
        }
    }
}
