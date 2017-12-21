using MarketSurrogate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MarketService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {


        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json)]
        bool UserRegister(TB_UserSurrogate user);
        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json)]
        TB_UserSurrogate UserLogin(string userName, string password);

        [OperationContract]
        [WebInvoke(Method = "POST",
           BodyStyle = WebMessageBodyStyle.Wrapped,
           ResponseFormat = WebMessageFormat.Json)]
        List<TB_ColorSurrogate> GetColors();

        [OperationContract]
        [WebInvoke(Method = "POST",
          BodyStyle = WebMessageBodyStyle.Wrapped,
          ResponseFormat = WebMessageFormat.Json)]
        List<TB_CitySurrogate> GetCities();

        [OperationContract]
        [WebInvoke(Method = "POST",
          BodyStyle = WebMessageBodyStyle.Wrapped,
          ResponseFormat = WebMessageFormat.Json)]
        List<TB_CategorySurrogate> GetCategories();

        [OperationContract]
        [WebInvoke(Method = "POST",
          BodyStyle = WebMessageBodyStyle.Wrapped,
          ResponseFormat = WebMessageFormat.Json)]
        List<TB_ProductSurrogate> GetProducts(List<int> kategoriID, List<int> colorID, List<int> cityID, decimal? minPrice, decimal? maxPrice, DateTime? minTarih, DateTime? maxTarih);

        [OperationContract]
        [WebInvoke(Method = "POST",
          BodyStyle = WebMessageBodyStyle.Wrapped,
          ResponseFormat = WebMessageFormat.Json)]
        bool AddCategory(TB_CategorySurrogate category);

        [OperationContract]
        [WebInvoke(Method = "POST",
         BodyStyle = WebMessageBodyStyle.Wrapped,
         ResponseFormat = WebMessageFormat.Json)]
        bool AddProduct(TB_ProductSurrogate product);

        [OperationContract]
        [WebInvoke(Method = "POST",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Json)]
        bool UpdateCategory(TB_CategorySurrogate category);

        [OperationContract]
        [WebInvoke(Method = "POST",
      BodyStyle = WebMessageBodyStyle.Wrapped,
      ResponseFormat = WebMessageFormat.Json)]
        bool UpdateProduct(TB_ProductSurrogate product);

        [OperationContract]
        [WebInvoke(Method = "POST",
      BodyStyle = WebMessageBodyStyle.Wrapped,
      ResponseFormat = WebMessageFormat.Json)]
        bool DeleteCategory(int categoryID);
        [OperationContract]
        [WebInvoke(Method = "POST",
      BodyStyle = WebMessageBodyStyle.Wrapped,
      ResponseFormat = WebMessageFormat.Json)]
        bool DeleteProduct(int productID);
    }
}
