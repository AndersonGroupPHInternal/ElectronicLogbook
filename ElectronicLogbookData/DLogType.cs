using ElectronicLogbookContext;
using BaseData;

namespace ElectronicLogbookData
{
    public class DLogType : DBase, IDLogType
    {
        public DLogType() : base(new Context())
        {
        }
    }
}
