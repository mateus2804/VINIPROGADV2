using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XPTOMVC.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Display(Name = "Nome do Cliente")]
        [Required]
        public string Nome { get; set; }

        [Display(Name = "CNPJ do Cliente")]
        [Required]
        [RegularExpression(@"\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}", ErrorMessage = "O CNPJ deve estar no formato 00.000.000/0000-00.")]
        public string CNPJ { get; set; }
    }
}
