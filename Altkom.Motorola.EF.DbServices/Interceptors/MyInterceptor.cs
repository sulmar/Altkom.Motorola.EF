using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.EF.DbServices.Interceptors
{
    internal class MyInterceptor : IDbCommandInterceptor
    {
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            throw new NotImplementedException();
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            throw new NotImplementedException();
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            if (command.CommandText.Contains("FROM [dbo].[Devices]"))
            {
                command.CommandText = command.CommandText + " WHERE Color='Black'";
            }

        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
        }
    }
}
