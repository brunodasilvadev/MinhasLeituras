using BS.MinhasLeituras.Domain.Entities;
using BS.MinhasLeituras.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BS.MinhasLeituras.Infra.Data.Context
{
    public class MinhasLeiturasContext : DbContext
    {
        public MinhasLeiturasContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Leitura> Leituras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                    .Where(p => p.Name == p.ReflectedType.Name + "Id")
                    .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new LeituraConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}