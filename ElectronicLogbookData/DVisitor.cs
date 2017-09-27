using ElectronicLogbookContext;
using BaseData;

namespace ElectronicLogbookData
{
    public class DVisitor : DBase, IDVisitor
    {
        public DVisitor() : base(new Context())
        {
        }
    }
}
