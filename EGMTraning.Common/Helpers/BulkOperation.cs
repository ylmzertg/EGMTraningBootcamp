using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EGMTraning.Common.Helpers
{
    public static class BulkOperation
    {
        public static void Insert<T>(T[] data)
        {
            //var tableName = typeof(T).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(T).Name;
            //DataTable table = new DataTable(tableName);
            //var properties = typeof(T).GetProperties().Where(x => x.GetCustomAttribute<InversePropertyAttribute>() == null)
            //    .ToArray();
            //foreach (var item in properties)
            //{
            //    var columnName = item.GetCustomAttribute<ColumnAttribute>()?.Name ?? item.Name;
            //    table.Columns.Add(new DataColumn(columnName, item.PropertyType));
            //}

            //// note: if "id_state" is defined as an identity column in your DB,
            //// row values for that column will be ignored during the bulk copy
            //foreach (var row in data)
            //{
            //    var rowData = properties.Select(x => x.GetValue(row)).ToArray();
            //    table.Rows.Add(rowData);
            //}
            //using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnectionStrings.Development))
            //{
            //    bulkCopy.BulkCopyTimeout = 600; // in seconds
            //    bulkCopy.DestinationTableName = tableName;
            //    foreach (var column in table.Columns)
            //    {
            //        bulkCopy.ColumnMappings.Add(column.ToString(), column.ToString());
            //    }
            //    bulkCopy.WriteToServer(table);
            //}
        }
    }
}
