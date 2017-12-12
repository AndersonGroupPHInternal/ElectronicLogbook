using ElectronicLogbookContext;
using BaseData;

namespace ElectronicLogbookData
{
    public class DEmployeeLog : DBase, IDEmployeeLog
    {
        public DEmployeeLog() : base(new Context())
        {
        }
    }
}
