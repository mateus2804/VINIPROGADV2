using System.ComponentModel.DataAnnotations;

namespace XPTOMVC.Models
{
    public class Servico
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Serviço")]
        [Required]
        public string Titulo { get; set; }

        [Display(Name = "Descrição do Serviço")]
        public string Descricao { get; set; }
    }
}
