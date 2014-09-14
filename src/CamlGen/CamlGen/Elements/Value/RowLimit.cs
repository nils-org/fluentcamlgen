using System.Globalization;

namespace FluentCamlGen.CamlGen.Elements.Value
{
    class RowLimit : BaseValueElement
    {
        internal RowLimit(int rowLimit)
            : base("RowLimit", rowLimit.ToString(CultureInfo.InvariantCulture))
        {
        }
    }
}
