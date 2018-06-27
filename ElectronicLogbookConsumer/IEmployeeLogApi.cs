using ElectronicLogbookModel;
using ElectronicLogbookModel.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicLogbookConsumer
{
    public interface IEmployeeLogApi
    {
        Task<List<EmployeeLog>> Create(EmployeeLogFilter employeeLogFilter);
    }
}
