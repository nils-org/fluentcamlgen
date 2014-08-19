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
using FluentCamlGen.CamlGen.Elements.Core;
using NSubstitute;
using Ploeh.AutoFixture;
using NUnit.Framework;

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
    }
}