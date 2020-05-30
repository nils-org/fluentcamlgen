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

using NUnit.Framework;

using System;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    [TestFixture]
    public class FieldRefTests : TestBase
    {
        [Test]
        public void BareFieldRefReturnsAFieldRefTagWithANameAttributes()
        {
            var name = Fixture.Create<string>();
            var sut = CG.FieldRef(name);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<FieldRef Name=""{0}"" />", name));
        }

        [Test]
        public void BareFieldRefWithAdditionalAttributesReturnsAFieldRefTagWithANameAndAdditionalAttributes()
        {
            var name = Fixture.Create<string>();
            var additionalName = Fixture.Create<string>();
            var additionalValue = Fixture.Create<string>();
            var sut = CG.FieldRef(name, new Tuple<string, string>(additionalName, additionalValue));
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<FieldRef Name=""{0}"" {1}=""{2}"" />", name, additionalName, additionalValue));
        }
    }
}