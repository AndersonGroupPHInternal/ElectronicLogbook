using ElectronicLogbookContext;
using BaseData;


namespace ElectronicLogbookData
{
    public class DInternHistory : DBase, IDInternHistory
    {
        public DInternHistory() : base(new Context())
        {
        }
    }
}
