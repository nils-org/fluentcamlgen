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

using FluentCamlGen.CamlGen.Elements;

using NSubstitute;

using NUnit.Framework;

namespace FluentCamlGen.CamlGen.Test.Elements
{
    [TestFixture]
    public class BaseElementFormatTests : TestBase
    {
        private BaseElement _cgPartial;

        [SetUp]
        public void Setup()
        {
            _cgPartial = Substitute.ForPartsOf<BaseElement>();
        }

        [Test]
        public void ToStringWithoutParamsCallsTheRealToStringWithTwoParams()
        {
            var expected = Fixture.Create<string>();
            _cgPartial.ToString(Arg.Any<bool>(), Arg.Any<int>()).Returns(expected);

            var actual = _cgPartial.ToString();

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ToStringWithOneParamCallsTheRealToStringWithTwoParams()
        {
            var someBool = Fixture.Create<bool>();
            var expected = Fixture.Create<string>();
            _cgPartial.ToString(Arg.Any<bool>(), Arg.Any<int>()).Returns(expected);

            var actual = _cgPartial.ToString(someBool);

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ToStringWithoutParamsCallsToStringWithoutFormattingAndNoIndent()
        {
            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            _cgPartial.ToString();
            // ReSharper restore ReturnValueOfPureMethodIsNotUsed
            _cgPartial.Received(1).ToString(false, 0);
        }

        [Test]
        public void ToStringWithOneParamsCallsToStringWithThatParamAndNoIndent()
        {
            var someBool = Fixture.Create<bool>();

            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            _cgPartial.ToString(someBool);
            // ReSharper restore ReturnValueOfPureMethodIsNotUsed

            _cgPartial.Received(1).ToString(someBool, 0);
        }
    }
}