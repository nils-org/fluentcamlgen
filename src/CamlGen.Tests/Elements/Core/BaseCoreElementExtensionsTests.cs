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

using System.Globalization;
using Moq;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    
    public class BaseCoreElementExtensionsTests : TestBase
    {
        [Fact]
        public void AddAttributeExtensionAddsTheAttribute()
        {
            var name = Fixture.Create<string>();
            var value = Fixture.Create<string>();
            var sut = new Mock<BaseCoreElement>(string.Empty){CallBase = true}.Object;
            sut.Attributes.ShouldBeEmpty("Simply asserting the test setup");

            sut.AddAttribute(name, value);

            sut.Attributes.Count.ShouldBe(1);
            var actual = sut.Attributes[0];
            actual.Item1.ShouldBe(name);
            actual.Item2.ShouldBe(value);
        }

        [Fact]
        public void BooleanValueAddAttributeExtensionAddsTheAttribute()
        {
            var value = Fixture.Create<bool>();
            var sut = new Mock<Eq>().Object;
            sut.Childs.ShouldBeEmpty("Simply asserting the test setup");

            sut.AddBooleanValue(value);

            sut.Childs.Count.ShouldBe(1);
            var actual = sut.Childs[0];
            var expected = string.Format(CultureInfo.InvariantCulture, "<Value Type=\"Boolean\">{0}</Value>", (value ? "1" : "0"));
            actual.ToString().ShouldBe(expected);
        }
    }
}
