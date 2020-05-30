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

using NUnit.Framework;

using System;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    [TestFixture]
    public class BaseCoreElementFormatTests : TestBase
    {
        [Test]
        public void TwoNestedTagWithoutFormattingReturnAStringWithoutFormatting()
        {
            var one = Substitute.ForPartsOf<BaseCoreElement>("One");
            var two = Substitute.ForPartsOf<BaseCoreElement>("Two");
            one.Childs.Add(two);

            var actual = one.ToString(false);
            actual.Should().BeEquivalentTo("<One><Two /></One>");
        }

        [Test]
        public void TwoNestedTagWithFormattingReturnAStringWithFormatting()
        {
            var one = Substitute.ForPartsOf<BaseCoreElement>("One");
            var two = Substitute.ForPartsOf<BaseCoreElement>("Two");
            one.Childs.Add(two);

            var actual = one.ToString(true);
            actual.Should().BeEquivalentTo(string.Format("<One>{0}  <Two />{0}</One>{0}", Environment.NewLine));
        }
    }
}