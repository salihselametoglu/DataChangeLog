using System;

namespace SP.LoggerByChangingColumn
{
    [AttributeUsage(validOn: AttributeTargets.Property, Inherited = false)]
    public class IsWriteLogChangeValue : Attribute
    {
        public bool WriteHistoryLog { get; set; }

        public IsWriteLogChangeValue(bool writeHistoryLog = true) => WriteHistoryLog = writeHistoryLog;
    }
}
