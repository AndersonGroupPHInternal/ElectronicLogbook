using ElectronicLogbookContext;
using BaseData;

namespace ElectronicLogbookData
{
    public class DVisitorHistory : DBase, IDVisitorHistory
    {
        public DVisitorHistory() : base(new Context())
        {
        }
    }
}
