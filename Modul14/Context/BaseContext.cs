using Microsoft.EntityFrameworkCore;
using Modul14.Models;

namespace Modul14.Context
{
    public class BaseContext:DbContext
    {
        /// <summary>
        /// Context yapılandırıldı
        /// </summary>
        /// <param name="dbContextOptions"></param>
        public BaseContext(DbContextOptions<BaseContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        //Context içerisinde db tanımlandı
        public DbSet<Customers> Customers { get; set; }
    }
}
