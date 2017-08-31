using AjkerdealAdmin.Domain.Entities;
using System.Collections.Generic;

namespace AjkerdealAdmin.Domain.Interfaces
{
    public interface IDashboardRepository
    {
        IEnumerable<DashboardModel> GetCrmOrder(string date);
    }
}
