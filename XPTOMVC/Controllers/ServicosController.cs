using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using XPTOMVC.Models;
using XPTOMVC.Services;
using XPTOMVC.Services.Exceptions;

namespace XPTOMVC.Controllers
{
	public class ServicosController : Controller
	{
		private readonly ServicoService _servicoService;

		public ServicosController(ServicoService servicoService)
		{
			_servicoService = servicoService;
		}
		public async Task<IActionResult> Index()
		{
			var Servicos = await _servicoService.FindAllAsync();
			return View(Servicos);
		}

		public IActionResult Create() //Create - GET
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Servico Servico) //Create - POST
		{

			try
			{
                if (ModelState.IsValid)
                {
                    await _servicoService.CreateAsync(Servico);
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
			var req = await _servicoService.FindByTituloAsync(id.Value);
			if (req == null)
			{
				return RedirectToAction(nameof(Error), new { Message = "Esse serviço não existe!" });
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
			var req = await _servicoService.FindByTituloAsync(id.Value);
			if (req == null)
			{
				return RedirectToAction(nameof(Error), new { Message = "Esse serviço não existe!" });
			}
			var servico = req;
			return View(servico);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Servico servico)// Edit - POST
		{
            try
            {
                await _servicoService.UpdateAsync(servico);
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
			var req = await _servicoService.FindByTituloAsync(id.Value);
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
				await _servicoService.RemoveAsync(id);
				return RedirectToAction(nameof(Index));
			}
			catch (IntegrityException ex)
			{
				return RedirectToAction(nameof(Error), new {Message = ex.Message });
			}
		}

		public IActionResult Error(string Message)
		{
			ErrorViewModel error = new ErrorViewModel() { Message = Message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
			return View(error);
		}

	}
}
