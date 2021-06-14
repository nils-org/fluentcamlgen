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
using AutoFixture.Kernel;

using FluentCamlGen.CamlGen.Elements;
using FluentCamlGen.CamlGen.Elements.Core;
using Moq;

namespace FluentCamlGen.CamlGen.Test
{
    internal class TestCgCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register(() => GetBaseElement(fixture));
            fixture.Register(() => GetCoreElement(fixture));
        }

        private static BaseElement GetBaseElement(ISpecimenBuilder fixture)
        {
            var fake = new Mock<BaseElement>();
            fake.Setup(f => 
                f.ToString(It.IsAny<bool>(), It.IsAny<int>()))
                .Returns(fixture.Create<string>());
            return fake.Object;
        }

        private static BaseCoreElement GetCoreElement(ISpecimenBuilder fixture)
        {
            var fake = new Mock<BaseCoreElement>(fixture.Create<string>());
            return fake.Object;
        }
    }
}