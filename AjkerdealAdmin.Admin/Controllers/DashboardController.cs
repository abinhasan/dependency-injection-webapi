using AjkerdealAdmin.Services.Interfaces;
using System.Web.Http;

namespace AjkerdealAdmin.Admin.Controllers
{
    [RoutePrefix("api/dashboard")]
    public class DashboardController : ApiController
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        [Route("GetCrmOrder/{date}")]
        public IHttpActionResult GetCrmOrder(string date)
        {
            return Ok(_dashboardService.GetCrmOrder(date));
        }
    }
}
