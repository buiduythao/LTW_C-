using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        private BuiDuyThaoContext db;
        public CategoryDao()
        {
            db = new BuiDuyThaoContext();
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
        public string Insert(Category entityCategory)
        {
            db.Categories.Add(entityCategory);
            db.SaveChanges();
            return entityCategory.Cat_Name;
        }
        public bool FindName(string categoryname)
        {
            return db.Categories.Any(x => x.Cat_Name == categoryname);
        }
        public Category FindId(System.Int32 category_id)
        {
            return db.Categories.Find(category_id);
        }
        public string Update(Category entityCategory)
        {
            var category = FindId(entityCategory.Cat_ID);
            if (category != null)
            {
                category.Cat_Name = entityCategory.Cat_Name;
                category.Cat_Description = entityCategory.Cat_Description;

            }
            db.SaveChanges();
            return entityCategory.Cat_Name;
        }
        public bool Delete(System.Int32 category_id)
        {
            try
            {
                var category = db.Categories.Find(category_id);
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
