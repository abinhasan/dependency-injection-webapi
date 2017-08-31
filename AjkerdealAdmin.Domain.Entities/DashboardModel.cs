using System;

namespace AjkerdealAdmin.Domain.Entities
{
    public class DashboardModel
    {
        public string CouponId { get; set; }
        public string MerchantId { get; set; }
        public int CustomerId { get; set; }
        public int DealId { get; set; }
        public string OrderFrom { get; set; }
        public int ShopCartId { get; set; }
        public DateTime PostedOn { get; set; }
        public string IsDone { get; set; }
    }
}
