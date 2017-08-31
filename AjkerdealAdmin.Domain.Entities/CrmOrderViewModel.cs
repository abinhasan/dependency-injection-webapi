namespace AjkerdealAdmin.Domain.Entities
{
    public class CrmOrderViewModel
    {
        public string Date { get; set; }

        public int UniqueDealId { get; set; }
        public int UniqueMerchantId { get; set; }

        public int PlaceOrder { get; set; }
        public int AppPlaceOrder { get; set; }
        public int MobilePlaceOrder { get; set; }
        public int DesktopPlaceOrder { get; set; }

        public int PlacedUniqueCustomer { get; set; }
        public int AppPlacedUniqueCustomer { get; set; }
        public int MobilePlacedUniqueCustomer { get; set; }
        public int DesktopPlacedUniqueCustomer { get; set; }

        public int ProcessedOrder { get; set; }
        public int AppProcessedOrder { get; set; }
        public int MobileProcessedOrder { get; set; }
        public int DesktopProcessedOrder { get; set; }

        public int ProcessedUniqueCustomer { get; set; }
        public int AppProcessedUniqueCustomer { get; set; }
        public int MobileProcessedUniqueCustomer { get; set; }
        public int DesktopProcessedUniqueCustomer { get; set; }

        public int PlacedCartOrder { get; set; }
    }
}
