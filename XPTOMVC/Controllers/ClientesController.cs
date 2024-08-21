using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XPTOMVC.Models;
using XPTOMVC.Services;
using XPTOMVC.Services.Exceptions;

namespace XPTOMVC.Controllers
{
	public class ClientesController : Controller
	{
		private readonly ClienteService _clienteService;

		public ClientesController(ClienteService clienteService)
		{
			_clienteService = clienteService;
		}
        public async Task<IActionResult> Index()
        {
            var Clientes = await _clienteService.FindAllAsync();
            return View(Clientes);
        }

        public IActionResult Create() //Create - GET
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente) //Create - POST
        {

            try
            {
                if (ModelState.IsValid)
                {
                    await _clienteService.CreateAsync(cliente);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Create));
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction(nameof(Error), new { Message = ex.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Parametros vazios!" });
            }
            var req = await _clienteService.FindByCNPJAsync(id.Value);
            if (req == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Esse Cliente não está registrado!" });
            }

            var servico = req;
            return View(servico);
        }

		public async Task<IActionResult> Edit(int? id)// Edit - GET
		{
			if (id == null)
			{
				return RedirectToAction(nameof(Error), new { Message = "Parametros vazios!" });
			}
			var req = await _clienteService.FindByCNPJAsync(id.Value);
			if (req == null)
			{
				return RedirectToAction(nameof(Error), new { Message = "Esse serviço não existe!" });
			}
			var servico = req;
			return View(servico);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cliente cliente)// Edit - POST
        {
            try
            {
                await _clienteService.UpdateAsync(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { Message = ex.Message });
            }
        }

        public async Task<IActionResult> Delete(int? id)// Delete - GET
        {
            if (id == null)
            {
                return NotFound();
            }
            var req = await _clienteService.FindByCNPJAsync(id.Value);
            if (req == null)
            {
                return NotFound();
            }

            var servico = req;
            return View(servico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) //Delete - POST
        {
            try
            {
                await _clienteService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { Message = ex.Message });
            }
        }

        public IActionResult Error(string Message)
        {
            ErrorViewModel error = new ErrorViewModel() { Message = Message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(error);
        }
    }
}
