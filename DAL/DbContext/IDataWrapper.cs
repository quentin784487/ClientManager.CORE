using DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.DbContext
{
    public interface IDataWrapper
    {
        object ExecuteNonQuery(string storedProcedureName, Dictionary<string, object> parametersList);
        PageResult ExecuteDataReader<T>(string storedProcedureName, Dictionary<string, object> parametersList, Type typeOfT);
        List<T> ExecuteSQLDataReader<T>(string sql, Dictionary<string, object> parametersList, Type typeOfT);
    }
}
