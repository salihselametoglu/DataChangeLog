using SP.LoggerByChangingColumn;
using System.Diagnostics;

namespace DataChangeLog
{
    public class WriteFileLog : ILogLogic
    {
        public void WriteLog()
        {
            Debug.WriteLine("File Logger");
        }
    }

    public class WriteDBLog : ILogLogic
    {
        public void WriteLog()
        {
            Debug.WriteLine("DB Logger");
        }
    }

    public class ChangeHistoryLoggerByFile : ChangeHistoryLogger<Person>
    {
        public ChangeHistoryLoggerByFile() => LogLogic = new WriteFileLog();
    }

    public class ChangeHistoryLoggerByDB<T> : ChangeHistoryLogger<T>
        where T : class
    {
        public ChangeHistoryLoggerByDB() => LogLogic = new WriteDBLog();
    }
}
