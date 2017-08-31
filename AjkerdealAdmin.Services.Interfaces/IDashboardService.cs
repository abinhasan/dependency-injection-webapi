using AjkerdealAdmin.Domain.Entities;
using System.Collections.Generic;

namespace AjkerdealAdmin.Services.Interfaces
{
    public interface IDashboardService
    {
        IEnumerable<CrmOrderViewModel> GetCrmOrder(string date);
    }
}
