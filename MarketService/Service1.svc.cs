using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MarketBusiness;
using MarketSurrogate;
using System.ServiceModel.Activation;

namespace MarketService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode =
            AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        Utilities utils = new Utilities();
        public bool UserRegister(TB_UserSurrogate user)
        {
            return utils.UserRegister(user);
        }
        public TB_UserSurrogate UserLogin(string userName, string password)
        {
            return utils.UserLogin(userName, password);
        }
        public List<TB_ColorSurrogate> GetColors()
        {
            return utils.GetColors();
        }
        public List<TB_CategorySurrogate> GetCategories()
        {
            return utils.GetCategories();
        }
        public List<TB_CitySurrogate> GetCities()
        {
            return utils.GetCities();
        }
        public List<TB_ProductSurrogate> GetProducts(List<int> kategoriID, List<int> colorID, List<int> cityID, decimal? minPrice, decimal? maxPrice, DateTime? minTarih, DateTime? maxTarih)
        {
            return utils.GetProducts( kategoriID, colorID, cityID,  minPrice,  maxPrice,  minTarih, maxTarih);
        }

        public bool AddCategory(TB_CategorySurrogate category)
        {
            return utils.AddCategory(category);
        }
        public bool AddProduct(TB_ProductSurrogate product)
        {
            return utils.AddProduct(product);
        }
        public bool UpdateCategory(TB_CategorySurrogate category)
        {
            return utils.UpdateCategory(category);
        }
        public bool UpdateProduct(TB_ProductSurrogate product)
        {
            return utils.UpdateProduct(product);
        }
        public bool DeleteCategory(int categoryID)
        {
            return utils.DeleteCategory(categoryID);
        }
        public bool DeleteProduct(int productID)
        {
            return utils.DeleteProduct(productID);
        }
    }
}
