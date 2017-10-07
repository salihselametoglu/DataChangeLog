using System;
using System.Diagnostics;
using System.Text;

namespace SP.LoggerByChangingColumn
{
    public abstract class ChangeHistoryLogger<S> : ICloneable
        where S : class
    {
        S historyObject;
        public ILogLogic LogLogic { get; set; }

        protected void SetValue(S currentObject)
        {
            if (historyObject == null)
            {
                if (currentObject is ICloneable)
                {
                    historyObject = (currentObject as ICloneable).Clone() as S;
                }
            }
        }

        public void WriteLog(S leastObject)
        {
            if (historyObject == null || LogLogic == null)
                return;

            var properties = historyObject.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);

                foreach (var attribute in attributes)
                {
                    if (attribute is IsWriteLogChangeValue)
                    {
                        var customAttribute = attribute as IsWriteLogChangeValue;

                        if (customAttribute.WriteHistoryLog)
                        {
                            var leastValue = leastObject.GetType().GetProperty(property.Name).GetValue(leastObject) ?? "";
                            var historyValue = property.GetValue(historyObject) ?? "";

                            var isEqual = leastValue.Equals(historyValue);

                            //if (!leastValue.ToString().Equals(historyValue.ToString()))
                            if (!isEqual)
                            {
                                #region Test Console Write Value
                                //Debug.WriteLine("---Log---");
                                //foreach (var item in historyObject.GetType().GetProperties())
                                //{
                                //    Debug.WriteLine(item.GetValue(historyObject));
                                //}
                                //Debug.WriteLine("------");
                                #endregion

                                LogLogic.WriteLog();

                                if (leastObject is ICloneable)
                                {
                                    var logData = new StringBuilder();

                                    foreach (var item in historyObject.GetType().GetProperties())
                                    {
                                        logData.Append("--");
                                        logData.Append(item.GetValue(historyObject));
                                    }

                                    Debug.WriteLine(logData.ToString());

                                    historyObject = (leastObject as ICloneable).Clone() as S;
                                }

                                return;
                            }                            
                        }
                    }
                }
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
