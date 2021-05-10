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
    public class St_IssueApproveRepo :  ISt_IssueApprove
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;

        public St_IssueApproveRepo(StockControlDBContext dbContext, IUnitOfWork uow)
        {
            _dbContext = dbContext;
            _uow = uow;
        }
        public async Task CreateAsync(St_IssueApprove issueApprove)
        {
            var requisitionUpdate = (from requisition in _dbContext.St_Requisitions where requisition.ItemCode == issueApprove.ItemCode select requisition).First();

            requisitionUpdate.Quantity = (float)issueApprove.ApprovedQty;
            requisitionUpdate.ApprovedBy = "HICAD2";

            await _dbContext.St_IssueApproves.AddAsync(issueApprove);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_IssueApprove>> GetAll()
        {
            return await _dbContext.St_IssueApproves.ToListAsync();
        }

        public St_IssueApprove GetByCode(string itemCode)
        {
            return _dbContext.St_IssueApproves.Where(ia => ia.ItemCode == itemCode).FirstOrDefault();
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

        public async Task DeleteAsync(string itemCode)
        {
            var issueApproveInDb = GetByCode(itemCode);
            _dbContext.Remove(issueApproveInDb);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_Requisition>> GetRequisitions()
        {
            return await _dbContext.St_Requisitions.ToListAsync();
        }

        public async Task<IssueRequesitionApprovalVM> RequesitionApprovalVM(string itemCode)
        {
            return await (from item in _dbContext.St_ItemMasters
                          join requisition in _dbContext.St_Requisitions on item.ItemCode equals requisition.ItemCode
                          join costCenter in _dbContext.Ac_CostCentres on requisition.LocationCode equals costCenter.UnitCode
                          where item.ItemCode == itemCode
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

        public Ac_CostCentre GetDepartmentName(string locationCode)
        {
            return _dbContext.Ac_CostCentres.Where(c=>c.UnitCode==locationCode).Select(c => new Ac_CostCentre
            {
                UnitDesc = c.UnitDesc
            }).FirstOrDefault();
        }

    
    }
}
