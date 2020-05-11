#region Using ...
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    public class SalesBillService : ISalesBillService
    {
        #region DataMember
        private readonly IJournalPostingsService _journalPostingsService;
        private readonly ISalesBillRepository _salesBillRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="journalPostingsService"></param>
        /// <param name="salesBillRepository"></param>
        /// <param name="languageService"></param>
        /// <param name="unitOfWork"></param>
        public SalesBillService(
            IJournalPostingsService journalPostingsService,
            ISalesBillRepository salesBillRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._journalPostingsService = journalPostingsService;
            this._salesBillRepository = salesBillRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region validation
        //public void CodeValidation(string code)
        //{
        //    if (code == "")
        //    {
        //        throw new NullReferenceException("Code Cannot Be Null");
        //    }
        //    else (code == "")
        //    {
        //        throw new NullReferenceException("Code Cannot Be Null");
        //    }
        //}
      
        public void DateValidation(SalesBillViewModel model)
        {
            if (model.Date == null)
            {
                throw new NullReferenceException("Date Time Cannot be Null");
            }
        }
        public void CostCenterIdsValidation(SalesBillViewModel model)
        {
            if (model.CostCenterId.Count <= 0)
            {
                throw new NullReferenceException();
            }
        }
        public void DelegateManValidation(SalesBillViewModel model)
        {
            if (model.DelegateManId==0)
            {
                throw new NullReferenceException("Delegate Man Cannot be null");
            }
        }
        public void SalesBillTypeValidation(SalesBillViewModel model)
        {
            if (model.SalesBillTypeId == 0)
            {
                throw new NullReferenceException("SalesBillType Man Cannot be null");
            }
        }
        public void InventoryIdValidation(SalesBillViewModel model)
        {
            if (model.InventoryId == 0)
            {
                throw new NullReferenceException("Inventory Man Cannot be null");
            }
        }
        public void DonatorIdValidation(SalesBillViewModel model)
        {
            if (model.DonatorId == 0)
            {
                throw new NullReferenceException("SalesBillType Man Cannot be null");
            }
        }
        public void ProductsAndCostValidation(SalesBillViewModel model)
        {
            if (model.SalesBillProducts.Count == 0)
            {
                throw new NullReferenceException("Products Man Cannot be null");
            }
            else {
                decimal sum = model.SalesBillProducts.Sum(p => p.Price);
                
                decimal? discount =model.Discount!=null?model.Discount:null;
                decimal? ExtraExpenses = model.ExtraExpenses != null ? model.ExtraExpenses : null;
                if (discount != null&& discount!=0)
                {
                    if (model.HasPercentage == true)
                    {
                        sum = sum - sum * ((decimal)discount / 100);
                    }
                    else {
                        sum = sum - (decimal)discount;
                    }
                }
                if (ExtraExpenses != null&& ExtraExpenses!=0)
                {
                    sum = sum + (decimal)ExtraExpenses; 
                }
                if (model.BillPrice != sum)
                    throw new Exception("Error In Callculating Sumation Right Sum= "+sum+ 
        "but Sumation Sended with object is "+model.BillPrice );
            }
        }
        #endregion

        #region Methods
        public void ThrowValidationException(SalesBillViewModel model)
        {
            DateValidation(model);
            CostCenterIdsValidation(model);
            CostCenterIdsValidation(model);
            DelegateManValidation(model);
            SalesBillTypeValidation(model);
            InventoryIdValidation(model);
            DonatorIdValidation(model);
            ProductsAndCostValidation(model);
        }


        //public void ThrowExceptionIfExist(SalesBill model)
        //{
        //    ConditionFilter<SalesBill, long> condition = new ConditionFilter<SalesBill, long>
        //    {
        //        Query = (entity =>
        //            //entity.Code == model.Code &&
        //            entity.Id == model.Id)
        //    };
        //    var existEntity = this._salesBillRepository.Get(condition).FirstOrDefault();

        //    if (existEntity != null)
        //        throw new ItemAlreadyExistException("Recrored Already Exsist");
        //}
        public SalesBillViewModel Add(SalesBillViewModel model)
        {
            
            //this.ThrowValidationException(model);
            
            var entity = model.ToEntity();
            DateTime now = DateTime.Now;
            entity.CreationDate = now;
            //generating code for sales bell
            Random random = new Random();
            entity.Code = random.Next(3000, 100000).ToString() + "-" + now.Ticks;


            List<CostCenterBill> CostCentersBills=new List<CostCenterBill>();
            foreach (var item in model.CostCenterId)
            {
                var CostBill = new CostCenterBill();
                CostBill.CostCeneterId = item;
                CostCentersBills.Add(CostBill);
            }
            entity.CostCenterBills=CostCentersBills;
            List<SalesBillProduct> SalesBillsProducts = new List<SalesBillProduct>();
            foreach (var item in model.SalesBillProducts)
            {
                SalesBillProduct SalesBillProduct = new SalesBillProduct();
                SalesBillProduct.ProductId = item.ProductId;
                SalesBillProduct.Price = item.Price;
                SalesBillProduct.Quantity = item.Quantity;
                SalesBillsProducts.Add(SalesBillProduct);
            }
            entity.SalesBillProducts = SalesBillsProducts;
            this._salesBillRepository.Add(entity);
            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            this._journalPostingsService.TryPostAutomatic(entity.Id, MovementType.SalesInvoice);

            model = entity.ToModel();
            return model;
        }
        #endregion
    }
}
