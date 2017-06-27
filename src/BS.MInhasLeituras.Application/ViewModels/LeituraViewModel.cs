using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BS.MinhasLeituras.Application.ViewModels
{
    public class LeituraViewModel
    {
        public LeituraViewModel()
        {
            LeituraId = Guid.NewGuid();
        }

        [Key]
        public Guid LeituraId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Título do Livro")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Título do Livro")]
        public string TituloLivro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Autor do Livro")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Autor do Livro")]
        public string AutorLivro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Qauntidade de Páginas")]
        [DisplayName("Quantidade de Páginas")]
        public int QuantidadePaginas { get; set; }

        [Required(ErrorMessage = "Preencha o campo Qauntidade de Páginas da Meta")]
        [DisplayName("Quantidade de Páginas da Meta")]
        public int QuantidadePaginasMeta { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data Início de Leitura")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Data Início da Leitura")]
        public DateTime DataInicioLeitura { get; set; }

        [Editable(false)]
        [DisplayName("Data Final da Leitura")]
        public DateTime DataFimLeitura { get; set; }

        [Editable(false)]
        [DisplayName("Status")]
        public string Status { get; set; }
    }
}
