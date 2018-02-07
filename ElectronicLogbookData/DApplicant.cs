using ElectronicLogbookContext;
using BaseData;

namespace ElectronicLogbookData
{
    public class DApplicant : DBase, IDApplicant
    {
        public DApplicant() : base(new Context())
        {
        }
    }
}
