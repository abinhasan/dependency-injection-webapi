using AjkerdealAdmin.Domain.Entities;
using AjkerdealAdmin.Domain.Interfaces;
using AjkerdealAdmin.Services.Attributes;
using AjkerdealAdmin.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AjkerdealAdmin.Services
{
    [TransientLifetime]
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public IEnumerable<CrmOrderViewModel> GetCrmOrder(string date)
        {
            var data = _dashboardRepository.GetCrmOrder(date);

            var app = new string[] { "App", "Android" };
            var mobile = new string[] { "Mobile Site", "Mobile Lite Site", "0" };

            var isNotValidStatus = new string[] { "2", "4", "6", "8", "44", "190", "290" };

            var isValidStatus = new string[] { "1", "7", "9", "10", "11", "13", "15", "16", "17", "18", "19", "20", "23", "24", "28", "29", "30", "31", "32", "33", "34", "35", "41", "42", "43", "55", "100", "101", "102", "103", "104", "105", "109", "110", "111", "117", "124", "125", "126", "127", "128", "129", "130", "131", "132", "133", "134", "135", "136", "137", "151", "152", "153", "154", "155", "161", "162", "163", "171", "172", "173", "174", "175", "176", "177", "180", "181", "201", "202", "204", "205", "210", "213", "224", "230", "231", "232", "233", "234", "235", "236", "237", "238", "239", "241", "242", "255", "261", "262", "263", "273", "279", "280", "291", "292", "293", "294", "304", "324", "325", "404" };


            var query =
                from crm in data
                orderby crm.PostedOn
                group crm by crm.PostedOn into crmGroup

                select new CrmOrderViewModel
                {
                    Date = crmGroup.Key.ToShortDateString(),
                    PlaceOrder = crmGroup.Count(),

                    AppPlaceOrder = (from crm2 in crmGroup
                                     where app.Contains(crm2.OrderFrom)
                                     select crm2.CouponId).Count(),

                    MobilePlaceOrder =
                                    (from crm2 in crmGroup
                                     where mobile.Contains(crm2.OrderFrom)
                                     select crm2.CouponId).Count(),

                    DesktopPlaceOrder =
                                    (from crm2 in crmGroup
                                     where crm2.OrderFrom.Contains("Main Site")
                                     select crm2.CouponId).Count(),
                    PlacedUniqueCustomer =
                                    (from crm2 in crmGroup
                                     select crm2.CustomerId).Distinct().Count(),


                    AppPlacedUniqueCustomer = (from crm2 in crmGroup
                                               where app.Contains(crm2.OrderFrom)
                                               select crm2.CustomerId).Count(),

                    MobilePlacedUniqueCustomer =
                                    (from crm2 in crmGroup
                                     where mobile.Contains(crm2.OrderFrom)
                                     select crm2.CustomerId).Count(),

                    DesktopPlacedUniqueCustomer =
                                    (from crm2 in crmGroup
                                     where crm2.OrderFrom.Contains("Main Site")
                                     select crm2.CustomerId).Count(),

                    UniqueDealId =
                                    (from crm2 in crmGroup
                                     where isValidStatus.Contains(crm2.IsDone)
                                     select crm2.DealId).Distinct().Count(),

                    UniqueMerchantId =
                                    (from crm2 in crmGroup
                                     where isValidStatus.Contains(crm2.IsDone)
                                     select crm2.MerchantId).Distinct().Count(),

                    ProcessedOrder =
                                    (from crm2 in crmGroup
                                     where isValidStatus.Contains(crm2.IsDone)
                                     select crm2.CouponId).Distinct().Count(),

                    AppProcessedOrder =
                                    (from crm2 in crmGroup
                                     where isValidStatus.Contains(crm2.IsDone)
                                     && app.Contains(crm2.OrderFrom)
                                     select crm2.CouponId).Distinct().Count(),

                    MobileProcessedOrder =
                                    (from crm2 in crmGroup
                                     where isValidStatus.Contains(crm2.IsDone)
                                     && mobile.Contains(crm2.OrderFrom)
                                     select crm2.CouponId).Distinct().Count(),

                    DesktopProcessedOrder =
                                    (from crm2 in crmGroup
                                     where isValidStatus.Contains(crm2.IsDone)
                                     && crm2.OrderFrom.Contains("Main Site")
                                     select crm2.CouponId).Distinct().Count(),

                    ProcessedUniqueCustomer =
                                    (from crm2 in crmGroup
                                     where isValidStatus.Contains(crm2.IsDone)
                                     select crm2.CustomerId).Distinct().Count(),

                    AppProcessedUniqueCustomer =
                                    (from crm2 in crmGroup
                                     where isValidStatus.Contains(crm2.IsDone)
                                     && app.Contains(crm2.OrderFrom)
                                     select crm2.CustomerId).Distinct().Count(),

                    MobileProcessedUniqueCustomer =
                                    (from crm2 in crmGroup
                                     where isValidStatus.Contains(crm2.IsDone)
                                     && mobile.Contains(crm2.OrderFrom)
                                     select crm2.CustomerId).Distinct().Count(),

                    DesktopProcessedUniqueCustomer =
                                    (from crm2 in crmGroup
                                     where isValidStatus.Contains(crm2.IsDone)
                                     && crm2.OrderFrom.Contains("Main Site")
                                     select crm2.CustomerId).Distinct().Count(),


                    PlacedCartOrder = (from temp in
                                        (from crm2 in crmGroup
                                         group crm2 by new { crm2.ShopCartId } into cartGroup
                                         where cartGroup.Count() > 1
                                         select cartGroup.Key)
                                       select temp.ShopCartId
                                     ).Count()

                };

            return query.ToList();



        }
    }
}
