using SLHDotNetTrainingBatch2.Project1.Database.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch2.Project1.Domain.Features
{
    public class SaleService
    {
        public TblProduct FindProduct(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            return item;
        }

        public int Sale(List<TblSaleDetail> products)
        {
            AppDbContext db = new AppDbContext();

            #region Generate Sale Summary and Create Sale Summary

            TblSale sale = new TblSale()
            {
                DeleteFlag = false,
                SaleDate = DateTime.Now,
                TotalAmount = products.Sum(x => (x.Price * x.Quantity)),
                VoucherNo = Guid.NewGuid().ToString(),
            };
            db.TblSales.Add(sale);
            db.SaveChanges();

            #endregion

            #region Modify Sale Detail and Create Sale Detail

            foreach (var product in products)
            {
                product.SaleId = sale.SaleId;
            }

            db.TblSaleDetails.AddRange(products);
            var result = db.SaveChanges();

            #endregion

            return result;
        }
    }
}
