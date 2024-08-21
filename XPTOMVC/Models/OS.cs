using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XPTOMVC.Models
{
    public class OS
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        [Display(Name = "Tipo de Serviço")]
        [Required]
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }

        [Display(Name = "Nome do Cliente")]
        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Display(Name = "Nome do Prestador de Serviço")]
        [Required]
        public int PrestadorServicoId { get; set; }
        public PrestadorServico PrestadorServico { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Execução")]
        [Required]
        public DateTime DataExecucao { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Valor do Serviço")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor do serviço deve ser maior do que zero.")]
        public double ValorServico { get; set; }
    }
}
