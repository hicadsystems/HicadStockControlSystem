using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository
{
    public class St_IssueApproveRepo : ISt_IssueApprove
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;
        private readonly ISt_RecordTable _recordTable;

        public St_IssueApproveRepo(StockControlDBContext dbContext, IUnitOfWork uow, ISt_RecordTable recordTable)
        {
            _dbContext = dbContext;
            _uow = uow;
            _recordTable = recordTable;
        }
        public async Task CreateAsync(St_IssueApprove issueApprove)
        {
            var requisitionUpdate = (from requisition in _dbContext.St_Requisitions 
                                     where requisition.RequisitionNo == issueApprove.RequisitionNo 
                                     select requisition).First();

            requisitionUpdate.Quantity = (float)issueApprove.ApprovedQty;
            requisitionUpdate.IsApproved = true;
            requisitionUpdate.ApprovedBy = "HICAD2";

            await _dbContext.St_IssueApproves.AddAsync(issueApprove);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_IssueApprove>> GetAll()
        {
            return await _dbContext.St_IssueApproves.ToListAsync();
        }

        public St_IssueApprove GetByCode(string reqNo)
        {
            return _dbContext.St_IssueApproves.Where(ia => ia.RequisitionNo == reqNo).FirstOrDefault();
        }

        public async Task UpdateAsync(St_IssueApprove issueApprove)
        {
            _dbContext.Update(issueApprove);
            await _uow.CompleteAsync();
        }

        public async Task UpdateAsync(string itemCode)
        {
            var issueApproveInDb = GetByCode(itemCode);
            _dbContext.Update(issueApproveInDb);
            await _uow.CompleteAsync();
        }

        public async Task DeleteAsync(string reqNo)
        {
            var issueApproveInDb = GetByCode(reqNo);
            _dbContext.Remove(issueApproveInDb);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_Requisition>> GetRequisitions()
        {
            return await _dbContext.St_Requisitions.Where(c => c.IsApproved == false).ToListAsync();
        }

        public async Task<IssueRequesitionApprovalVM> RequesitionApprovalVM(string reqNo)
        {
            return await (from requisition in _dbContext.St_Requisitions
                          join item in _dbContext.St_ItemMasters on requisition.ItemCode equals item.ItemCode
                          join costCenter in _dbContext.Ac_CostCentres on requisition.LocationCode equals costCenter.UnitCode
                          where requisition.RequisitionNo == reqNo && requisition.IsApproved == false
                          select new IssueRequesitionApprovalVM
                          {
                              RequisitionNo = requisition.RequisitionNo,
                              RequisitionBy = requisition.UserId,
                              //Department = requisition.LocationCode,
                              Department = costCenter.UnitDesc,
                              DateAndTime = requisition.RequisitionDate.ToString(),
                              ItemCode = item.ItemCode,
                              ItemDescription = item.ItemDesc,
                              Requested = requisition.Quantity
                          }).FirstOrDefaultAsync();
        }

        public string GenerateDocNo()
        {
            var dd = DateTime.Now.Year.ToString().Substring(2, 2);
            var docCode = "A" + dd + "00000";
            int docNo = 0;
            var genDocNo = "";

            var recordTable = _recordTable.GetByCode("CODE");
            if (recordTable.Code == "CODE" && recordTable.IssAppDocCode < 1)
            {
                var docCodeNo = recordTable.IssAppDocCode = docNo + 1;
                genDocNo = docCode + docCodeNo;
            }
            else if (recordTable.Code == "CODE" && recordTable.IssAppDocCode >= 1)
            {
                docNo = recordTable.IssAppDocCode;
                var newDocNoCode = recordTable.IssAppDocCode = docNo + 1;
                genDocNo = docCode + newDocNoCode;
            }

            return genDocNo;
        }
    }
}
