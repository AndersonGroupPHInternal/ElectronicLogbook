using AndersonNotificationConsumer;
using AndersonNotificationModel;
using ElectronicLogbookConsumer;
using ElectronicLogbookModel;
using ElectronicLogbookModel.Filter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicLogbookDesktop
{
    public partial class NotificationForm : Form
    {
        private IEmailNotificationApi _iEmailNotificationApi;
        private IEmployeeLogApi _iEmployeeLogApi;

        public NotificationForm()
        {
            InitializeComponent();
            _iEmailNotificationApi = new EmailNotificationApi();
            _iEmployeeLogApi = new EmployeeLogApi();
            SendUpdates();
        }

        private async void SendUpdates()
        {
            EmployeeLogFilter employeeLogFilter = new EmployeeLogFilter
            {
                LogDateFrom = DateTime.Now.AddHours(-1),
                LogDateTo = DateTime.Now
            };
            var employeeLogs = await _iEmployeeLogApi.Read(employeeLogFilter);
            var emailNotificationbody = EmployeeLogNotification(employeeLogs);

            EmailNotification emailNotification = new EmailNotification
            {
                Body = emailNotificationbody,
                To = ConfigurationManager.AppSettings["ElectronicLogbookNotificationEmail"]
            };
            emailNotification = await _iEmailNotificationApi.Create(emailNotification);
            Application.ExitThread();
        }

        private string EmployeeLogNotification(List<EmployeeLog> employeeLogs)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table> <tr>");
            stringBuilder.Append("<th>SuccesLogin</th>");
            stringBuilder.Append("<th>LogDate</th>");
            stringBuilder.Append("<th>EmployeeLogId</th>");
            stringBuilder.Append("<th>LogTypeId</th>");
            stringBuilder.Append("<th>EmployeeNumber</th>");
            stringBuilder.Append("<th>FirstName</th>");
            stringBuilder.Append("<th>LastName</th>");
            stringBuilder.Append("<th>MiddleName</th>");
            stringBuilder.Append("<th>LogType</th>");
            stringBuilder.Append("</tr>");
            foreach (var employeeLog in employeeLogs)
            {
                stringBuilder.Append("<tr>");
                stringBuilder.Append("<th>" + employeeLog.SuccesLogin + "</th>");
                stringBuilder.Append("<th>" + employeeLog.LogDate + "</th>");
                stringBuilder.Append("<th>" + employeeLog.EmployeeLogId + "</th>");
                stringBuilder.Append("<th>" + employeeLog.LogTypeId + "</th>");
                stringBuilder.Append("<th>" + employeeLog.EmployeeNumber + "</th>");
                stringBuilder.Append("<th>" + employeeLog.FirstName + "</th>");
                stringBuilder.Append("<th>" + employeeLog.LastName + "</th>");
                stringBuilder.Append("<th>" + employeeLog.MiddleName + "</th>");
                stringBuilder.Append("<th>" + employeeLog.LogType + "</th>");
                stringBuilder.Append("</tr>");
            }
            stringBuilder.Append("</table>");
            return stringBuilder.ToString();
        }
    }
}
