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
using Ploeh.AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FluentCamlGen.CamlGen.Test
{
    [TestClass]
    public class FormatTests : TestBase
    {
        private Mock<CG> _cgPartial;

        [TestInitialize]
        public void Setup()
        {
            // Partial mock 
            _cgPartial = new Mock<CG>(string.Empty)
                {
                    CallBase = true
                };
        }

        [TestMethod]
        public void ToStringWithoutParamsCallsTheRealToStringWithTwoParams()
        {
            var expected = Fixture.Create<string>();
            _cgPartial.Setup(m => m.ToString(It.IsAny<bool>(), It.IsAny<int>())).Returns(expected);

            var actual = _cgPartial.Object.ToString();

            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void ToStringWithOneParamCallsTheRealToStringWithTwoParams()
        {
            var someBool = Fixture.Create<bool>();
            var expected = Fixture.Create<string>();
            _cgPartial.Setup(m => m.ToString(It.IsAny<bool>(), It.IsAny<int>())).Returns(expected);

            var actual = _cgPartial.Object.ToString(someBool);

            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void ToStringWithoutParamsCallsToStringWithoutFormattingAndNoIndent()
        {
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
            _cgPartial.Object.ToString();
// ReSharper restore ReturnValueOfPureMethodIsNotUsed
            _cgPartial.Verify(m => m.ToString(false, 0));
        }

        [TestMethod]
        public void ToStringWithOneParamsCallsToStringWithThatParamAndNoIndent()
        {
            var someBool = Fixture.Create<bool>();

            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            _cgPartial.Object.ToString(someBool);
            // ReSharper restore ReturnValueOfPureMethodIsNotUsed

            _cgPartial.Verify(m => m.ToString(someBool, 0));
        }

    }
}
