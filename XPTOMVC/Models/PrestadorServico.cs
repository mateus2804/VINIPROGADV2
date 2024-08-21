using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XPTOMVC.Models
{
    public class PrestadorServico 
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Prestador de Serviço")]
        [Required]
        public string Nome { get; set; }

        [Display(Name = "CPF do Prestador de Serviço")]
        [Required]
		//[RegularExpression(@"\d{3}\.\d{3}\.\d{3}-\d{2}", ErrorMessage = "O CNPJ deve estar no formato 000.000.000-00.")]
		public string CPF { get; set; }
        List<OS> OSs { get; set; }
    }
}
