using BaseConsumer;
using System.Configuration;

namespace ElectronicLogbookConsumer
{
    public abstract class ElectronicLogbookConsumerBase : Consumer
    {
        public ElectronicLogbookConsumerBase()
        {
            BaseUrl = ConfigurationManager.AppSettings["ElectronicLogbookUrl"];
            Password = ConfigurationManager.AppSettings["ElectronicLogbookPassword"];
            Username = ConfigurationManager.AppSettings["ElectronicLogbookUsername"];
        }
    }
}
