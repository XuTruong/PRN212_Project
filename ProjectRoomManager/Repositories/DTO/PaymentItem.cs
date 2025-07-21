namespace Repositories.DTO
{
    public class PaymentItem
    {
        public int BillId { get; set; }
        public string RoomName { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string Note { get; set; }
        public bool IsSelected { get; set; }
        public bool IsPaid { get; set; }
    }
}
