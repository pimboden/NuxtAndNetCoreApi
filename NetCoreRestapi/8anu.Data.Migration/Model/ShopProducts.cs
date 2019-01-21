namespace _8anu.Data.Migration.Model
{
    public partial class ShopProducts
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Desc { get; set; }
        public string Text { get; set; }
        public int Categories { get; set; }
        public string Pic { get; set; }
        public int SupId { get; set; }
        public string SupProdId { get; set; }
        public string OrginalPrice { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public float Vat { get; set; }
        public int Status { get; set; }
        public int Mediate { get; set; }
        public byte NoPayment { get; set; }
    }
}
