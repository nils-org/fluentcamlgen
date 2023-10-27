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

using Val = FluentCamlGen.CamlGen.Elements.Value;

namespace FluentCamlGen.CamlGen.Test.Elements.Value
{
    public class ValueTests : TestBase
    {
        [Fact]
        public void SimpleValueReturnsTag()
        {
            var val = Fixture.Create<string>();
            var expected = string.Format(@"<Value Type=""Number"">{0}</Value>", val).AsXml();
            var sut = new Val.Value(CG.ValueType.Number, val);

            sut.ToString().AsXml().ShouldBe(expected);
        }

        [Fact]
        public void NumberValueReturnsAValueTagWithTypeNumber()
        {
            var val = Fixture.Create<double>();
            var expected = string.Format(@"<Value Type=""Number"">{0}</Value>", val).AsXml();
            var sut = new Val.NumberValue(val);

            sut.ToString().AsXml().ShouldBe(expected);
        }

        [Fact]
        public void NumberValueUsingTheStringCtorReturnsAValueTagWithTypeNumber()
        {
            var val = Fixture.Create<string>();
            var expected = string.Format(@"<Value Type=""Number"">{0}</Value>", val).AsXml();
            var sut = new Val.NumberValue(val);

            sut.ToString().AsXml().ShouldBe(expected);
        }

        [Fact]
        public void NumberValueOnCgReturnsAValueTagWithTypeNumber()
        {
            var val = Fixture.Create<double>();
            var expected = string.Format(@"<Value Type=""Number"">{0}</Value>", val).AsXml();
            var sut = CG.NumberValue(val);

            sut.ToString().AsXml().ShouldBe(expected);
        }

        [Fact]
        public void ValueOnCgReturnsAValueTag()
        {
            var val = Fixture.Create<string>();
            var expected = string.Format(@"<Value Type=""Number"">{0}</Value>", val).AsXml();
            var sut = CG.Value(CG.ValueType.Number, val);

            sut.ToString().AsXml().ShouldBe(expected);
        }

        [Fact]
        public void BoolValueTrueReturnsAValueOfOne()
        {
            var expected = @"<Value Type=""Boolean"">1</Value>".AsXml();
            var sut = CG.BooleanValue(true);

            sut.ToString().AsXml().ShouldBe(expected);
        }

        [Fact]
        public void BoolValueFalseReturnsAValueOfZero()
        {
            var expected = @"<Value Type=""Boolean"">0</Value>".AsXml();
            var sut = CG.BooleanValue(false);

            sut.ToString().AsXml().ShouldBe(expected);
        }
    }
}
