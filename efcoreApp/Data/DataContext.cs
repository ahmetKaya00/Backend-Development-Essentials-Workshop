using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Data{

    public class DataContext : DbContext{
        public DataContext(DbContextOptions<DataContext>options):base(options){}

        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();
        public DbSet<Kurs> Kurslar => Set<Kurs>();
        public DbSet<KursKayit> KursKayitlari => Set<KursKayit>();
    }
}