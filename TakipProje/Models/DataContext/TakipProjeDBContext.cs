using System.Data.Entity;
using TakipProje.Models.Personel;
using TakipProje.Models.ProjeTakip;

namespace ProjeTakip.Models.DataContext
{
    public class TakipProjeDBContext : DbContext
    {
        public TakipProjeDBContext(): base("TakipProjeDB")
        {

        }

        public DbSet<PersonelBilgileri> PersonelBilgileris { get; set; }

        public DbSet<PersonelProjeleri> PersonelProjeleris { get; set; }
             
    }
}
