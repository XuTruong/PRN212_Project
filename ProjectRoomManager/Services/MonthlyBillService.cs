using DataAccess.Models;
using Repositories;
using Repositories.DTO;

namespace Services
{
    public class MonthlyBillService
    {
        private MonthlyBillRepo _repo;

        public MonthlyBillService()
        {
            _repo = new MonthlyBillRepo();
        }

        public List<MonthlyBillDto> GetMonthlyBills()
        {
            return _repo.GetMonthlyBills();
        }

        public void CreateBill(MonthlyBill bill)
        {
            _repo.CreateBill(bill);
        }

        public void UpdateBill(MonthlyBill bill)
        {
            _repo.UpdateBill(bill);
        }

        public List<MonthlyBillDto> GetMonthlyBillsByEx(String ex)
        {
            return _repo.GetMonthlyBillsByEx(ex);
        }

        public bool checkExistRoomMonthCurrent(int contractId, string monthYear)
        {
            return _repo.checkExistRoomMonthCurrent(contractId, monthYear);
        }

        public MonthlyBill GetMonthlyBillById(int _billId)
        {
            return _repo.GetMonthlyBillById(_billId);
        }
    }
}
