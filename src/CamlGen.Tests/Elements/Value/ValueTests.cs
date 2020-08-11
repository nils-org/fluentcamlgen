﻿/***
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

using NUnit.Framework;

using Val = FluentCamlGen.CamlGen.Elements.Value;

namespace FluentCamlGen.CamlGen.Test.Elements.Value
{
    [TestFixture]
    public class ValueTests : TestBase
    {
        [Test]
        public void SimpleValueReturnsTag()
        {
            var val = Fixture.Create<string>();
            var expected = string.Format(@"<Value Type=""Number"">{0}</Value>", val).AsXml();
            var sut = new Val.Value(CG.ValueType.Number, val);

            sut.ToString().AsXml().Should().BeEquivalentTo(expected);
        }

        [Test]
        public void NumberValueReturnsAValueTagWithTypeNumber()
        {
            var val = Fixture.Create<double>();
            var expected = string.Format(@"<Value Type=""Number"">{0}</Value>", val).AsXml();
            var sut = new Val.NumberValue(val);

            sut.ToString().AsXml().Should().BeEquivalentTo(expected);
        }

        [Test]
        public void NumberValueUsingTheStringCtorReturnsAValueTagWithTypeNumber()
        {
            var val = Fixture.Create<string>();
            var expected = string.Format(@"<Value Type=""Number"">{0}</Value>", val).AsXml();
            var sut = new Val.NumberValue(val);

            sut.ToString().AsXml().Should().BeEquivalentTo(expected);
        }

        [Test]
        public void NumberValueOnCgReturnsAValueTagWithTypeNumber()
        {
            var val = Fixture.Create<double>();
            var expected = string.Format(@"<Value Type=""Number"">{0}</Value>", val).AsXml();
            var sut = CG.NumberValue(val);

            sut.ToString().AsXml().Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ValueOnCgReturnsAValueTag()
        {
            var val = Fixture.Create<string>();
            var expected = string.Format(@"<Value Type=""Number"">{0}</Value>", val).AsXml();
            var sut = CG.Value(CG.ValueType.Number, val);

            sut.ToString().AsXml().Should().BeEquivalentTo(expected);
        }

        [Test]
        public void BoolValueTrueReturnsAValueOfOne()
        {
            var expected = @"<Value Type=""Boolean"">1</Value>".AsXml();
            var sut = CG.BooleanValue(true);

            sut.ToString().AsXml().Should().BeEquivalentTo(expected);
        }

        [Test]
        public void BoolValueFalseReturnsAValueOfZero()
        {
            var expected = @"<Value Type=""Boolean"">0</Value>".AsXml();
            var sut = CG.BooleanValue(false);

            sut.ToString().AsXml().Should().BeEquivalentTo(expected);
        }
    }
}