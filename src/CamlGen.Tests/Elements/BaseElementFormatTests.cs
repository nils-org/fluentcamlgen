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

using FluentCamlGen.CamlGen.Elements;
using Moq;

using Xunit;

namespace FluentCamlGen.CamlGen.Test.Elements
{
    
    public class BaseElementFormatTests : TestBase
    {
        private BaseElement _cgPartial;
        private Mock<BaseElement> _cgPartialMock;

        public BaseElementFormatTests()
        {
            _cgPartialMock = new Mock<BaseElement>
            {
                CallBase = true
            };
            _cgPartial = _cgPartialMock.Object;
        }

        [Fact]
        public void ToStringWithoutParamsCallsTheRealToStringWithTwoParams()
        {
            var expected = Fixture.Create<string>();
            _cgPartialMock.Setup(x => 
                x.ToString(It.IsAny<bool>(), It.IsAny<int>()))
                .Returns(expected);

            var actual = _cgPartial.ToString();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void ToStringWithOneParamCallsTheRealToStringWithTwoParams()
        {
            var someBool = Fixture.Create<bool>();
            var expected = Fixture.Create<string>();
            _cgPartialMock.Setup(x => 
                x.ToString(It.IsAny<bool>(), It.IsAny<int>()))
                .Returns(expected);

            var actual = _cgPartial.ToString(someBool);

            actual.ShouldBe(expected);
        }

        [Fact]
        public void ToStringWithoutParamsCallsToStringWithoutFormattingAndNoIndent()
        {
            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            _cgPartial.ToString();
            // ReSharper restore ReturnValueOfPureMethodIsNotUsed
            _cgPartialMock.Verify(x => x.ToString(false, 0), Times.Once);
        }

        [Fact]
        public void ToStringWithOneParamsCallsToStringWithThatParamAndNoIndent()
        {
            var someBool = Fixture.Create<bool>();

            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            _cgPartial.ToString(someBool);
            // ReSharper restore ReturnValueOfPureMethodIsNotUsed

            _cgPartialMock.Verify(x => x.ToString(someBool, 0), Times.Once);
        }
    }
}
