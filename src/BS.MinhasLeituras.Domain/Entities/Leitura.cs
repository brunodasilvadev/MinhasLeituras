using DomainValidation.Validation;
using System;

namespace BS.MinhasLeituras.Domain.Entities
{
    public class Leitura
    {
        public Leitura()
        {
            LeituraId = Guid.NewGuid();
        }
        public Guid LeituraId { get; set; }
        public string TituloLivro { get; set; }
        public string AutorLivro { get; set; }
        public int QuantidadePaginas { get; set; }
        public int QuantidadePaginasMeta { get; set; }
        public DateTime DataInicioLeitura { get; set; }
        public DateTime DataFimLeitura { get; set; }
        public string Status { get; set; }

        //se houver validação tratar esse código abaixo
        //public ValidationResult ValidationResult { get; set; }

        //public bool IsValid()
        //{
        //    ValidationResult = new LeituraEstaConsistenteValidation().Validate(this);
        //    return ValidationResult.IsValid;
        //}
        //se houver validação tratar esse código acima
    }
}