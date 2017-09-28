using ElectronicLogbookContext;
using BaseData;

namespace ElectronicLogbookData
{
    public class DIntern : DBase, IDIntern
    {
        public DIntern() : base(new Context())
        {
        }
    }
}
