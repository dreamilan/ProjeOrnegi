using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketSurrogate;
using MarketEntity;

namespace MarketBusiness
{
    public class Utilities
    {
        public bool UserRegister(TB_UserSurrogate user)
        {
            using(MarketDBEntities db=new MarketDBEntities())
            {
                TB_User u = new TB_User();
                if(db.TB_User.FirstOrDefault(q=>q.Username==user.Username)==null)
                {
                    u.Email = user.Email;
                    u.Name = user.Name;
                    u.Password = user.Password;
                    u.Surname = user.Surname;
                    u.Username = user.Username;
                    db.TB_User.Add(u);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public TB_UserSurrogate UserLogin(string userName, string password)
        {
            using (MarketDBEntities db = new MarketDBEntities())
            {
                TB_UserSurrogate result = new TB_UserSurrogate();
                TB_User user = db.TB_User.FirstOrDefault(q => q.Username == userName && q.Password == password);
                if ( user!=null)
                {
                    result.Email = user.Email;
                    result.Name = user.Name;
                    result.Password = user.Password;
                    result.Surname = user.Surname;
                    result.Username = user.Username;
                    result.UserID = user.UserID;
                    return result;
                }
            }
            return null;
        }
        public List<TB_ColorSurrogate> GetColors()
        {
            using (MarketDBEntities db = new MarketDBEntities())
            {
                return (from q in db.TB_Color
                        select new TB_ColorSurrogate
                        {
                            ColoID = q.ColoID,
                            ColorCode = q.ColorCode,
                            ColorName = q.ColorName
                        }).ToList();
            }
        }
        public List<TB_CitySurrogate> GetCities()
        {
            using (MarketDBEntities db = new MarketDBEntities())
            {
                return (from q in db.TB_City
                        select new TB_CitySurrogate
                        {
                            CityID = q.CityID,
                            CityName = q.CityName
                        }).ToList();
            }
        }
        public List<TB_CategorySurrogate> GetCategories()
        {
            using (MarketDBEntities db = new MarketDBEntities())
            {
                return (from q in db.TB_Category
                        select new TB_CategorySurrogate
                        {
                            CategoryID = q.CategoryID,
                            CategoryName = q.CategoryName
                        }).ToList();
            }
        }
        public List<TB_ProductSurrogate> GetProducts(List<int> kategoriID, List<int> colorID, List<int> cityID, decimal? minPrice, decimal? maxPrice, DateTime? minTarih, DateTime? maxTarih)
        {
            List <TB_CategorySurrogate> categoriesList = GetCategories();
            List<TB_ColorSurrogate> colorsList = GetColors();
            List<TB_CitySurrogate> citiesList = GetCities();
            List<TB_ProductSurrogate> sonuc = new List<TB_ProductSurrogate>();
            using (MarketDBEntities db = new MarketDBEntities())
            {
                sonuc = (from q in db.TB_Product
                         select new TB_ProductSurrogate
                         {
                             DateAdded = q.DateAdded ?? DateTime.MinValue,
                             Price = q.Price ?? 0,
                             ProductID = q.ProductID,
                             Title = q.Title,
                             Category = new TB_CategorySurrogate() { CategoryID = q.CategoryID??0 },
                            City = new TB_CitySurrogate() { CityID = q.CityID ?? 0 },
                             Color = new TB_ColorSurrogate() { ColoID = q.ColorID ?? 0 },

                         }).ToList();


            }
            if (kategoriID != null)
                if (kategoriID.Count > 0)
                    sonuc = sonuc.Where(q => kategoriID.Contains(q.Category.CategoryID)).Select(q => q).ToList();
            if (colorID != null)
                if (colorID.Count > 0)
                    sonuc = sonuc.Where(q => colorID.Contains(q.Color.ColoID)).Select(q => q).ToList();
            if (cityID != null)
                if (cityID.Count > 0)
                    sonuc = sonuc.Where(q => cityID.Contains(q.City.CityID)).Select(q => q).ToList();
            if (minPrice != null)
                sonuc = sonuc.Where(q => q.Price >= minPrice).Select(q => q).ToList();
            if (maxPrice != null)
                sonuc = sonuc.Where(q => q.Price <= maxPrice).Select(q => q).ToList();
            if (minTarih != null)
                sonuc = sonuc.Where(q => q.DateAdded >= minTarih).Select(q => q).ToList();
            if (maxTarih != null)
                sonuc = sonuc.Where(q => q.DateAdded <= maxTarih).Select(q => q).ToList();
            return sonuc;
        }
        public bool AddCategory(TB_CategorySurrogate category)
        {
            using (MarketDBEntities db = new MarketDBEntities())
            {
                TB_Category c = new TB_Category();
                if (db.TB_Category.FirstOrDefault(q => q.CategoryName == category.CategoryName) == null)
                {
                    c.CategoryName = category.CategoryName;
                    db.TB_Category.Add(c);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public bool AddProduct(TB_ProductSurrogate product)
        {
            using (MarketDBEntities db = new MarketDBEntities())
            {
                TB_Product p = new TB_Product();
                p.CategoryID = product.Category.CategoryID;
                p.CityID = product.City.CityID;
                p.ColorID = product.Color.ColoID;
                p.DateAdded = DateTime.Now;
                p.Price = product.Price;
                p.Title = product.Title;
                db.TB_Product.Add(p);
                db.SaveChanges();
                return true;
            }
        }
        public bool UpdateCategory(TB_CategorySurrogate category)
        {
            using (MarketDBEntities db = new MarketDBEntities())
            {
                TB_Category c = db.TB_Category.FirstOrDefault(q => q.CategoryID == category.CategoryID);
                if ( c!= null)
                {
                    c.CategoryName = category.CategoryName;
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public bool UpdateProduct(TB_ProductSurrogate product)
        {
            using (MarketDBEntities db = new MarketDBEntities())
            {
                TB_Product p =  db.TB_Product.FirstOrDefault(q => q.ProductID == product.ProductID);
                if (p != null)
                {
                    p.CategoryID = product.Category.CategoryID;
                    p.CityID = product.City.CityID;
                    p.ColorID = product.Color.ColoID;
                    p.DateAdded = DateTime.Now;
                    p.Price = product.Price;
                    p.Title = product.Title;
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
        }
        public bool DeleteCategory(int categoryID)
        {
            using (MarketDBEntities db = new MarketDBEntities())
            {
                TB_Category c = db.TB_Category.FirstOrDefault(q => q.CategoryID == categoryID);
                if (c != null)
                {
                    db.TB_Category.Remove(c);
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
            
        }
        public bool DeleteProduct(int productID)
        {
            using (MarketDBEntities db = new MarketDBEntities())
            {
                TB_Product p = db.TB_Product.FirstOrDefault(q => q.ProductID == productID);
                if (p != null)
                {
                    db.TB_Product.Remove(p);
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }

        }
    }
}
