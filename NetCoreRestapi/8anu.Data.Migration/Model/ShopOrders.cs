using System;

namespace _8anu.Data.Migration.Model
{
    public partial class ShopOrders
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public string CustInfo { get; set; }
        public string OrderInfo { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int DibstransactId { get; set; }
        public string OrderId { get; set; }
        public int Month { get; set; }
        public float Total { get; set; }
        public float Vat { get; set; }
        public float TotalVat { get; set; }
        public int Year { get; set; }
        public string Currency { get; set; }
        public int PaymentWindow { get; set; }
    }
}
