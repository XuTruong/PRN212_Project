using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repositories;
using Repositories.DTO;

namespace Services
{
    public class ContractService
    {
        ContractRepo _repo;

        public ContractService()
        {
            _repo = new ContractRepo();
        }

        public List<ContractDisplayDto> GetAllContracts()
        {
            return _repo.GetAllContracts();
        }


        public List<ContractDisplayDto> SearchContract(string key)
        {
            return _repo.searchContract(key);
        }

        public List<ContractDisplayDto> GetAllActiveContracts()
        {
            return _repo.GetAllActiveContracts();
        }

        public List<ContractDisplayDto> GetAllExpiredContracts()
        {
            return _repo.GetAllExpiredContracts();
        }

        public void Addcontract(Contract contract, int roomId)
        {
            _repo.createContract(contract, roomId);
        }

        public void AddRoomTenant(RoomTenant roomTenant)
        {
            _repo.AddRoomTenant(roomTenant);
        }

        public void RemoveRoomate(List<int> tenantId)
        {
            _repo.RemoveRoomate(tenantId);
        }

        public void EndContract(int contractId, string roomName)
        {
            _repo.EndContract(contractId, roomName);
        }

        public int ChangeRoomIdToContractId(int roomId)
        {
            return _repo.ChangeRoomIdToContractId(roomId);
        }
    }
}
