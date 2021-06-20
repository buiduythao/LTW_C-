using ModelEF.Model;
using ModelEF.ViewModelClone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        private BuiDuyThaoContext db;
        public ProductDao()
        {
            db = new BuiDuyThaoContext();
        }
        public List<ProductModel> ListAll(string keysearch)
        {
            var list_product = from s in db.Products
                               join a in db.Authors
                               on s.Aut_ID equals a.Aut_ID
                               join c in db.Categories
                               on s.Cat_ID equals c.Cat_ID
                               orderby s.Pro_Quantity, s.Pro_Price descending
                               select new ProductModel
                               {
                                   ProID = s.Pro_ID,
                                   CatName = c.Cat_Name,
                                   AutName = a.Aut_Name,
                                   ProName = s.Pro_Name,
                                   ProImg = s.Pro_Img,
                                   ProQuantity = s.Pro_Quantity,
                                   ProPrice = s.Pro_Price,
                                   ProStatus = s.Pro_Status,
                                   ProDescription = s.Pro_Description
                               };
            var list_product1 = from s in db.Products
                                join a in db.Authors
                                on s.Aut_ID equals a.Aut_ID
                                join c in db.Categories
                                on s.Cat_ID equals c.Cat_ID
                                where s.Pro_Name.Contains(keysearch)
                                orderby s.Pro_Quantity, s.Pro_Price descending
                                select new ProductModel
                                {
                                    ProID = s.Pro_ID,
                                    CatName = c.Cat_Name,
                                    AutName = a.Aut_Name,
                                    ProName = s.Pro_Name,
                                    ProImg = s.Pro_Img,
                                    ProQuantity = s.Pro_Quantity,
                                    ProPrice = s.Pro_Price,
                                    ProStatus = s.Pro_Status,
                                    ProDescription = s.Pro_Description
                                };
            if (!string.IsNullOrEmpty(keysearch))
                return list_product1.ToList();
            return list_product.ToList();
        }
        public Product FindId(System.Int32 product_id)
        {
            return db.Products.Find(product_id);
        }
        public bool Delete(System.Int32 product_id)
        {
            try
            {
                var product = db.Products.Find(product_id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ProductModel> Detail(int id)
        {
            var list_product = from s in db.Products
                               join a in db.Authors
                               on s.Aut_ID equals a.Aut_ID
                               join c in db.Categories
                               on s.Cat_ID equals c.Cat_ID
                               where s.Pro_ID==id
                               select new ProductModel
                               {
                                   ProID = s.Pro_ID,
                                   CatName = c.Cat_Name,
                                   AutName = a.Aut_Name,
                                   ProName = s.Pro_Name,
                                   ProImg = s.Pro_Img,
                                   ProQuantity = s.Pro_Quantity,
                                   ProPrice = s.Pro_Price,
                                   ProStatus = s.Pro_Status,
                                   ProDescription = s.Pro_Description
                               };
            return list_product.ToList();
        }
        public List<ProductModel> ListAllLimit6()
        {
            var list_product = (from s in db.Products
                               join a in db.Authors
                               on s.Aut_ID equals a.Aut_ID
                               join c in db.Categories
                               on s.Cat_ID equals c.Cat_ID
                               orderby s.Pro_ID
                               select new ProductModel
                               {
                                   ProID = s.Pro_ID,
                                   CatName = c.Cat_Name,
                                   AutName = a.Aut_Name,
                                   ProName = s.Pro_Name,
                                   ProImg = s.Pro_Img,
                                   ProQuantity = s.Pro_Quantity,
                                   ProPrice = s.Pro_Price,
                                   ProStatus = s.Pro_Status,
                                   ProDescription = s.Pro_Description
                               }).Take(6);
            return list_product.ToList();
        }
        public List<ProductModel> ListCasuaActiLimit3()
        {
            var list_product = (from s in db.Products
                                join a in db.Authors
                                on s.Aut_ID equals a.Aut_ID
                                join c in db.Categories
                                on s.Cat_ID equals c.Cat_ID
                                orderby s.Pro_Quantity descending
                                select new ProductModel
                                {
                                    ProID = s.Pro_ID,
                                    CatName = c.Cat_Name,
                                    AutName = a.Aut_Name,
                                    ProName = s.Pro_Name,
                                    ProImg = s.Pro_Img,
                                    ProQuantity = s.Pro_Quantity,
                                    ProPrice = s.Pro_Price,
                                    ProStatus = s.Pro_Status,
                                    ProDescription = s.Pro_Description
                                }).Skip(3).Take(3);
            return list_product.ToList();
        }
        public List<ProductModel> ListCasuaItem()
        {
            var list_product = (from s in db.Products
                                join a in db.Authors
                                on s.Aut_ID equals a.Aut_ID
                                join c in db.Categories
                                on s.Cat_ID equals c.Cat_ID
                                orderby s.Pro_Quantity descending
                                select new ProductModel
                                {
                                    ProID = s.Pro_ID,
                                    CatName = c.Cat_Name,
                                    AutName = a.Aut_Name,
                                    ProName = s.Pro_Name,
                                    ProImg = s.Pro_Img,
                                    ProQuantity = s.Pro_Quantity,
                                    ProPrice = s.Pro_Price,
                                    ProStatus = s.Pro_Status,
                                    ProDescription = s.Pro_Description
                                }).Take(3);
            return list_product.ToList();
        }
        public List<ProductModel> ListTabItem()
        {
            var list_product = (from s in db.Products
                                join a in db.Authors
                                on s.Aut_ID equals a.Aut_ID
                                join c in db.Categories
                                on s.Cat_ID equals c.Cat_ID
                                orderby s.Pro_Price descending
                                select new ProductModel
                                {
                                    ProID = s.Pro_ID,
                                    CatName = c.Cat_Name,
                                    AutName = a.Aut_Name,
                                    ProName = s.Pro_Name,
                                    ProImg = s.Pro_Img,
                                    ProQuantity = s.Pro_Quantity,
                                    ProPrice = s.Pro_Price,
                                    ProStatus = s.Pro_Status,
                                    ProDescription = s.Pro_Description
                                }).Take(4);
            return list_product.ToList();
        }
    }
}
