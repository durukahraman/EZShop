using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;

namespace BLL.Services
{
    public class CategoryService : Service
    {
        public CategoryService(Db db) : base(db)
        {
            
        }

        public Service Create(Category record)
        {
            _db.Categories.Add(record);
            _db.SaveChanges();
            return Success("category is created successfully");
        }

        public Service Update(Category record)
        {
            _db.Categories.Update(record);
            _db.SaveChanges();
            return Success("category is created successfully");
            
        }

        public Service Delete(int id)
        {
            //Category category = _db.Categories.Find(id);
            Category category = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (category is null)
                return Error("category is not found");
            _db.Remove(category);
            _db.SaveChanges();
            return Success("category is deleted successfully");
        }

        public IQueryable<CategoryModel> Query()
        {
            return _db.Categories.Select(c => new CategoryModel()
            {
                Record = c
            });
        }
  
    }
}

