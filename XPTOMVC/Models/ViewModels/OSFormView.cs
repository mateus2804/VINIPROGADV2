using System.Collections.Generic;

namespace XPTOMVC.Models.ViewModels
{
    public class OSFormView
    {
        public OS OS { get; set; }

        public ICollection<Servico> Servicos { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<PrestadorServico> PrestadorServico { get; set; }
        public ICollection<OS> OSs { get; set; }
    }
}
