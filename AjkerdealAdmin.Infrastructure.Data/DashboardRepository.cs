using AjkerdealAdmin.Connection;
using AjkerdealAdmin.Domain.Entities;
using AjkerdealAdmin.Domain.Interfaces;
using AjkerdealAdmin.Services.Attributes;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace AjkerdealAdmin.Infrastructure.Data
{
    [TransientLifetime]
    public class DashboardRepository : IDashboardRepository
    {
        IConnection _connection;
        public DashboardRepository(IConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<DashboardModel> GetCrmOrder(string date)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Date", value: date, dbType: DbType.String);

            return _connection.GetConnection.Query<DashboardModel>(
                    sql: @"[Reports].[USP_GetOrder]",
                    commandType: CommandType.StoredProcedure,
                    param: parameter);

        }
    }
}
