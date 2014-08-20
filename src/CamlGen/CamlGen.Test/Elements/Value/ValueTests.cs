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
            var sut = new Val.Value(CG.ValueType.Number, val);

            sut.ToString().Should().Be(string.Format(@"<Value Type=""Number"">{0}</Value>", val));
        }

        [Test]
        public void NumberValueReturnsAValueTagWithTypeNumber()
        {
            var val = Fixture.Create<double>();
            var sut = new Val.NumberValue(val);

            sut.ToString().Should().Be(string.Format(@"<Value Type=""Number"">{0}</Value>", val));
        }

        [Test]
        public void NumberValueUsingTheStringCtorReturnsAValueTagWithTypeNumber()
        {
            var val = Fixture.Create<string>();
            var sut = new Val.NumberValue(val);

            sut.ToString().Should().Be(string.Format(@"<Value Type=""Number"">{0}</Value>", val));
        }

        [Test]
        public void NumberValueOnCgReturnsAValueTagWithTypeNumber()
        {
            var val = Fixture.Create<double>();
            var sut = CG.NumberValue(val);

            sut.ToString().Should().Be(string.Format(@"<Value Type=""Number"">{0}</Value>", val));
        }

        [Test]
        public void ValueOnCgReturnsAValueTag()
        {
            var val = Fixture.Create<string>();
            var sut = CG.Value(CG.ValueType.Number, val);

            sut.ToString().Should().Be(string.Format(@"<Value Type=""Number"">{0}</Value>", val));
        }
    }
}