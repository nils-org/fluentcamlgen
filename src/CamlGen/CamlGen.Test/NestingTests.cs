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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace FluentCamlGen.CamlGen.Test
{
    // ReSharper disable InconsistentNaming
    [TestClass]
    public class NestingTests : TestBase
    {
        [TestMethod]
        public void BareCgReturnsExactlyTheTag()
        {
            var tag = Fixture.Create<string>();
            var sut = new CG(tag);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<{0} />
", tag));
        }

        [TestMethod]
        public void NestedCgReturnsTheNestedTags()
        {
            var outerTag = Fixture.Create<string>();
            var innerTag = Fixture.Create<string>();
            
            var sut = new CG(outerTag);
            sut.Childs.Add(new CG(innerTag));

            sut.ToString().Should().BeEquivalentTo(string.Format(@"<{0}>
  <{1} />
</{0}>
", outerTag, innerTag));
        }

        [TestMethod]
        public void DeepNestedCgReturnsTheDeepNestedTags()
        {
            var outerTag = Fixture.Create<string>();
            var middleTag = Fixture.Create<string>();
            var innerTag = Fixture.Create<string>();

            var outerSut = new CG(outerTag);
            var middleSut = new CG(middleTag);
            middleSut.Childs.Add(new CG(innerTag));
            outerSut.Childs.Add(middleSut);

            outerSut.ToString().Should().BeEquivalentTo(string.Format(@"<{0}>
  <{1}>
    <{2} />
  </{1}>
</{0}>
", outerTag, middleTag, innerTag));
        }
    }
    // ReSharper restore InconsistentNaming
}
