using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class AuthorDao
    {
        private BuiDuyThaoContext db;
        public AuthorDao()
        {
            db = new BuiDuyThaoContext();
        }
        public List<Author> ListAll()
        {
            return db.Authors.ToList();
        }
        public string Insert(Author entityAuthor)
        {

            db.Authors.Add(entityAuthor);
            db.SaveChanges();
            return entityAuthor.Aut_Name;
        }
        public bool FindName(string authorname)
        {
            return db.Authors.Any(x => x.Aut_Name == authorname);
        }
        public Author FindId(System.Int32 author_id)
        {
            return db.Authors.Find(author_id);
        }
        public string Update(Author entityAuthor)
        {
            var author = FindId(entityAuthor.Aut_ID);
            if (author != null)
            {
                author.Aut_Name = entityAuthor.Aut_Name;

            }
            db.SaveChanges();
            return entityAuthor.Aut_Name;
        }
        public bool Delete(System.Int32 author_id)
        {
            try
            {
                var author = db.Authors.Find(author_id);
                db.Authors.Remove(author);
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
