/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using FluentCamlGen.CamlGen.Elements;
using FluentCamlGen.CamlGen.Elements.Core;
using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;

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
            var fake = Substitute.For<BaseElement>();
            fake.ToString(Arg.Any<bool>(), Arg.Any<int>()).Returns(fixture.Create<string>());
            return fake;
        }

        private static BaseCoreElement GetCoreElement(ISpecimenBuilder fixture)
        {
            var fake = Substitute.For<BaseCoreElement>(fixture.Create<string>());
            return fake;
        }
    }
}
