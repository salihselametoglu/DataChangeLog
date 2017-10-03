using SP.LoggerByChangingColumn;

namespace DataChangeLog.DBOperation
{
    public class DBOperation<T> where T : class
    {
        public int Update(T entity)
        {
            //MUST DO to write log
            if (entity is ChangeHistoryLogger<T>)
            {
                var changeHistoryLogger = entity as ChangeHistoryLogger<T>;
                changeHistoryLogger.WriteLog(entity);
            }

            //update DB operation

            return 1;
        }
    }
}
