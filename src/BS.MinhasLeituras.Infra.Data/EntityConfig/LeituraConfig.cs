using BS.MinhasLeituras.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace BS.MinhasLeituras.Infra.Data.EntityConfig
{
    public class LeituraConfig : EntityTypeConfiguration<Leitura>
    {
        public LeituraConfig()
        {
            HasKey(l => l.LeituraId);

            Property(l => l.TituloLivro)
                .IsRequired()
                .HasMaxLength(150);

            Property(l => l.AutorLivro)
                .IsRequired()
                .HasMaxLength(150);

            Property(l => l.QuantidadePaginas)
                .IsRequired();

            Property(l => l.QuantidadePaginasMeta)
                .IsRequired();

            Property(l => l.DataInicioLeitura)
                .IsRequired();

            Property(l => l.Status)
                .IsRequired()
                .HasMaxLength(1)
                .IsFixedLength();

            //Caso aja validações tratar o trecho abaixo
            //Ignore(l => l.ValidationResult);
            //Instalar DomainValidation na Infra.Data
            //Caso aja validações tratar o trecho acima

            ToTable("Leituras");
        }
    }
}