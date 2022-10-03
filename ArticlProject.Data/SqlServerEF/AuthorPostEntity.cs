using ArticlProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArticlProject.Data.SqlServerEF
{
    public class AuthorPostEntity : IDataHelper<AuthorPost>
    {
        private DBContext db;
        private AuthorPost _table;
        public AuthorPostEntity()
        {
            db = new DBContext();
        }
        public int Add(AuthorPost table)
        {
            if (db.Database.CanConnect())
            {
                db.AuthorPost.Add(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Delete(int Id)
        {
            if (db.Database.CanConnect())
            {
                _table = Find(Id);
                db.AuthorPost.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, AuthorPost table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.AuthorPost.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public AuthorPost Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.AuthorPost.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<AuthorPost> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.AuthorPost.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<AuthorPost> GetDataByUser(string UserId)
        {
            if (db.Database.CanConnect())
            {
                return db.AuthorPost.Where(x=>x.UserId==UserId).ToList();
            }
            else
            {
                return null;
            }
        }

        public List<AuthorPost> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.AuthorPost.Where(x =>
                x.FullName.Contains(SerachItem)
                ||x.UserId.Contains(SerachItem)
                ||x.UserName.Contains(SerachItem)
                ||x.PostTitle.Contains(SerachItem)
                ||x.PostDescription.Contains(SerachItem)
                ||x.PostImageUrl.Contains(SerachItem)
                ||x.AuthorId.ToString().Contains(SerachItem)
                ||x.CategoryId.ToString().Contains(SerachItem)
                ||x.AddedDate.ToString().Contains(SerachItem)
                || x.Id.ToString().Contains(SerachItem))
                .ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
