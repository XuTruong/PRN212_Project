using DataAccess.Models;
using Repositories.DTO;

namespace Repositories
{
    public class MonthlyBillRepo
    {
        private readonly RoomManagerContext _context;

        public MonthlyBillRepo()
        {
            _context = new RoomManagerContext();
        }

        public void CreateBill(MonthlyBill bill)
        {
            _context.MonthlyBills.Add(bill);
            _context.SaveChanges();
        }

        //public void UpdateBill(MonthlyBill bill)
        //{
        //    var existing = _context.MonthlyBills.Find(bill.BillId);
        //    if (existing != null)
        //    {
        //        existing.ElectricityOld = bill.ElectricityOld;
        //        existing.WaterOld = bill.WaterOld;
        //        existing.ElectricityNew = bill.ElectricityNew;
        //        existing.WaterNew = bill.WaterNew;
        //        existing.ElectricityRate = bill.ElectricityRate;
        //        existing.WaterRate = bill.WaterRate;
        //        existing.TotalAmount = bill.TotalAmount;
        //        _context.SaveChanges();
        //    }
        //}

        public void UpdateBill(MonthlyBill bill)
        {
            _context.MonthlyBills.Update(bill);
            _context.SaveChanges();
        }


        public List<MonthlyBillDto> GetMonthlyBills()
        {
            return (from b in _context.Set<MonthlyBill>()
                    join c in _context.Set<Contract>() on b.ContractId equals c.ContractId
                    join r in _context.Set<Room>() on c.RoomId equals r.RoomId
                    select new MonthlyBillDto
                    {
                        BillId = b.BillId,
                        RoomName = r.RoomName ?? "",
                        MonthYear = b.MonthYear ?? "",
                        ElectricityOld = b.ElectricityOld ?? 0,
                        ElectricityNew = b.ElectricityNew ?? 0,
                        WaterOld = b.WaterOld ?? 0,
                        WaterNew = b.WaterNew ?? 0,
                        ElectricityRate = b.ElectricityRate ?? 0,
                        WaterRate = b.WaterRate ?? 0,
                        RoomPrice = b.RoomPrice ?? 0,
                        TotalAmount = b.TotalAmount ?? 0,
                        IsPaid = b.IsPaid ?? false,
                        PaymentDate = b.PaymentDate.HasValue
              ? b.PaymentDate.Value.ToDateTime(TimeOnly.MinValue)
              : null
                    }).ToList();
        }

        public List<MonthlyBillDto> GetMonthlyBillsByEx(String ex)
        {
            return (from b in _context.Set<MonthlyBill>()
                    join c in _context.Set<Contract>() on b.ContractId equals c.ContractId
                    join r in _context.Set<Room>() on c.RoomId equals r.RoomId
                    where b.MonthYear == ex
                    select new MonthlyBillDto
                    {
                        BillId = b.BillId,
                        RoomName = r.RoomName ?? "",
                        MonthYear = b.MonthYear ?? "",
                        ElectricityOld = b.ElectricityOld ?? 0,
                        ElectricityNew = b.ElectricityNew ?? 0,
                        WaterOld = b.WaterOld ?? 0,
                        WaterNew = b.WaterNew ?? 0,
                        ElectricityRate = b.ElectricityRate ?? 0,
                        WaterRate = b.WaterRate ?? 0,
                        RoomPrice = b.RoomPrice ?? 0,
                        TotalAmount = b.TotalAmount ?? 0,
                        IsPaid = b.IsPaid ?? false,
                        PaymentDate = b.PaymentDate.HasValue
              ? b.PaymentDate.Value.ToDateTime(TimeOnly.MinValue)
              : null
                    }).ToList();
        }

        public void AddOrUpdateMonthlyBill(MonthlyBill bill)
        {
            if (bill.BillId == 0)
                _context.Set<MonthlyBill>().Add(bill);
            else
                _context.Set<MonthlyBill>().Update(bill);

            _context.SaveChanges();
        }

        public bool CheckExistRoomMonthCurrent(int contractId, string monthYear)
        {
            return _context.MonthlyBills.Any(mb => mb.ContractId == contractId && mb.MonthYear == monthYear);
        }

        public MonthlyBill? GetMonthlyBillById(int _billId)
        {
            return _context.MonthlyBills.FirstOrDefault(mb => mb.BillId == _billId);
        }
    }
}
