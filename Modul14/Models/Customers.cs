using System.ComponentModel.DataAnnotations;

namespace Modul14.Models
{
    /// <summary>
    /// Northwind tablosunda customers tablosu üzerinden veri çekebilmek için model tanımlandı. 
    /// Verilerin eksik olması herhangi bir sorun oluşturmaz
    /// </summary>
    public class Customers
    {
        [Key]
        [Required]
        public string CustomerID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
