using ElectronicLogbookModel;
using ElectronicLogbookModel.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicLogbookConsumer
{
    public class EmployeeLogApi : ElectronicLogbookConsumerBase, IEmployeeLogApi
    {
        public EmployeeLogApi()
        {
        }

        public async Task<List<EmployeeLog>> Create(EmployeeLogFilter employeeLogFilter)
        {
            DestinationUrl = "/api/EmployeeLogApi/Read";
            return await PostWithAuthentication<List<EmployeeLog>, EmployeeLogFilter>(employeeLogFilter);
        }
    }
}
