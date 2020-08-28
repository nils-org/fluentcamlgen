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

using FluentCamlGen.CamlGen.Elements.Core;
using FluentCamlGen.CamlGen.Elements.Value;

using NSubstitute;

using NUnit.Framework;

using System.Globalization;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    [TestFixture]
    public class BaseCoreElementExtensionsTests : TestBase
    {
        [Test]
        public void AddAttributeExtensionAddsTheAttribute()
        {
            var name = Fixture.Create<string>();
            var value = Fixture.Create<string>();
            var sut = Substitute.ForPartsOf<BaseCoreElement>(string.Empty);
            sut.Attributes.Should().BeEmpty("Simply asserting the test setup");

            sut.AddAttribute(name, value);

            sut.Attributes.Count.Should().Be(1);
            var actual = sut.Attributes[0];
            actual.Item1.Should().Be(name);
            actual.Item2.Should().Be(value);
        }

        [Test]
        public void BooleanValueAddAttributeExtensionAddsTheAttribute()
        {
            var value = Fixture.Create<bool>();
            var sut = Substitute.ForPartsOf<Eq>();
            sut.Childs.Should().BeEmpty("Simply asserting the test setup");

            sut.AddBooleanValue(value);

            sut.Childs.Count.Should().Be(1);
            var actual = sut.Childs[0];
            var expected = string.Format(CultureInfo.InvariantCulture, "<Value Type=\"Boolean\">{0}</Value>", (value ? "1" : "0"));
            actual.ToString().Should().BeEquivalentTo(expected);
        }
    }
}