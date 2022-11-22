using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modul14.Context;
using Modul14.Dto;
using Modul14.Models;

namespace Modul14.Controllers
{
    //Bunlar class seviyesinde tanımlanmış attribute lardır.
    [Route("api/[controller]")]
    [ApiController]
    //Eğer projemizde bir authorize yapısı tanımlar isek böyle bir attribute kullanarak yetkilendirme için class seviyesinde tanımlayabiliriz
    //[Authorize]
    public class CustomerController : ControllerBase
    {
        BaseContext _baseContext;
        public CustomerController(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }
        //Http verb 'lerinden biri olan httpget data çekebilmemiz için kullanılan bir verb 'dür.
        [HttpGet("ListRawData")]
        //Endpointler tanımlanırken genellikle async olarak tanımlanır. Bunun temel sebebi performanstır.
        public async Task<List<Customers>> ListRawData()
        {
            var data = _baseContext.Customers.ToList();
            return data;
        }
        //Dto içerisinde tanımladığımız bir generic model içine datamızı gömdük ve bununla beraber çekilen verileri aktardık
        [HttpGet("ListWithResponseModel")]
        public async Task<ResponseModel<List<Customers>>> ListWithResponseModel()
        {
            var data = _baseContext.Customers.ToList();

            return new ResponseModel<List<Customers>> { Data = data, Status = 200 };
        }
        [HttpGet("ListRawDataWithResponse")]
        //Aşağıdaki yöntemde ise aslında api yeteneklerini daha iyi kullanabilmemize olanak sağlar. Mevcut senaryoda bu api ya istek gönderdiğimizi düşünelim.
        //Eğer bu gönderdiğimiz istekde veri olmasa bile 200 sonucu döndürecektir
        //Bu sebepten ötürü özel bir response model yerine iactionresult tanımlaması gerçekleştirdik
        //Bu response içerisinde tanımlamış olduğumuz özel hataları da döndürebiliriz. Type yapılanması bu konuda incelenebilir.
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        //Endpointler tanımlanırken genellikle async olarak tanımlanır. Bunun temel sebebi performanstır.
        public async Task<IActionResult> ListRawDataWithResponse()
        {
            var data = _baseContext.Customers.Where(x => x.ContactTitle.Contains("sadasdasdasd")).ToList();
            //Ve kontrolleri sağlayarak nocontent veya odan datayı döndürmeyi sağladık.
            //Bu kullanımın kendi oluşturduğumuz model içerisinde tanımlayabileceğiz bir field ile kontrol ettirilip geri döndürülebilir fakat
            //Bu özellikleri kullanmak bizim için daha faydalı olur. Hataları handle edebilmemiz kolaylaşır.
            return data.Count == 0 ? NoContent() : Ok(data);
        }
        //Delete için farklı bir verb kullanıyoruz.
        [HttpDelete("Delete")]
        //Veya aşağıdaki şekilde bir route tanımlaması da yapabiliriz. Fakat delete içerisinde tanımladığımız için burada sadece tek bir tanesini kullanabiliriz.
        //[Route("Delete")]
        //Authorize tanımlamasını ister tek role istersek birden fazla rol içinde tanımlayabiliriz.
        //[HttpDelete("Delete"), Authorize(Roles = "Admin,CompanyManager,CompanySalesManager,CompanySupportTeam,DealerManager,DealerStaff")]
        public async Task<bool> Delete(string id)
        {
            var asd = id;
            Customers data = await _baseContext.Customers.Where(x => x.CustomerID == id).FirstOrDefaultAsync();
            if (data != null)
            {
                _baseContext.Customers.Remove(data);
                return _baseContext.SaveChanges() > 0;
            }
            else
            {
                return false;
            }

        }
        //Id tanımlamasını get içerisinde yaparak required olarak belirtebiliriz.
        [HttpGet("GetByIdCustomer{id}")]
        public async Task<Customers> GetByIdCustomer(string id)
        {
            var data = await _baseContext.Customers.Where(x => x.CustomerID == id).FirstOrDefaultAsync();
            if( data == null)
            {
                return null;
            }
            else
            {
                return data;
            }
        }
        //Update işlemleri için put kullanmak zorundayız.
        [HttpPut("Update")]
        public async Task<bool> UpdateCustomer(Customers data)
        {
            
                var oldData = await _baseContext.Customers.Where(x => x.CustomerID == data.CustomerID).FirstOrDefaultAsync();
            if (oldData == null) {
                return false;
            }
                oldData.CompanyName = data.CompanyName;
                return _baseContext.SaveChanges() > 0;
            
            
        }
    }
}
