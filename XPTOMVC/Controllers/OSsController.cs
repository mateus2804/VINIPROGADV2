using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XPTOMVC.Models;
using XPTOMVC.Models.ViewModels;
using XPTOMVC.Services;
using XPTOMVC.Services.Exceptions;

namespace XPTOMVC.Controllers
{
	public class OSsController : Controller
	{
        private readonly OSService _osservice;
        private readonly ClienteService _clienteService;
        private readonly PrestadorServicoService _prestadorServicoService;
        private readonly ServicoService _servicoService;

        public OSsController(OSService os, ClienteService clienteService, PrestadorServicoService prestadorServicoService, ServicoService servicoService)
        {
            _osservice = os;
            _clienteService = clienteService;
            _prestadorServicoService = prestadorServicoService;
            _servicoService = servicoService;
        }
        public async Task<IActionResult> Index()
        {
            var Clientes = await _osservice.FindAllAsync();
            return View(Clientes);
        }

        public async Task<IActionResult> Create() //Create - GET
        {
            var clientes = await _clienteService.FindAllAsync();
            var prestadores = await _prestadorServicoService.FindAllAsync();
            var servicos = await _servicoService.FindAllAsync();

            var viewmodel = new OSFormView() { Clientes = clientes, PrestadorServico = prestadores, Servicos = servicos };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OS os) //Create - POST
        {
            if (ModelState.IsValid)
            {
                await _osservice.CreateAsync(os);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Parametros vazios!" });
            }
            var req = await _osservice.FindByNumeroAsync(id.Value);
            if (req == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Essa ordem de serviço não está registrada!" });
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
			var req = await _osservice.FindByNumeroAsync(id.Value);
			if (req == null)
			{
				return RedirectToAction(nameof(Error), new { Message = "Essa ordem de serviço não está registrada!" });
			}
			var servico = req;
            var clientes = await _clienteService.FindAllAsync();
            var prestadores = await _prestadorServicoService.FindAllAsync();
            var servicos = await _servicoService.FindAllAsync();
            var viewmodel = new OSFormView() { Clientes = clientes, PrestadorServico = prestadores, Servicos = servicos, OS = servico };

            return View(viewmodel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(OS os)// Edit - POST
		{
			try
			{
				await _osservice.UpdateAsync(os);
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
            var req = await _osservice.FindByNumeroAsync(id.Value);
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
                await _osservice.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { Message = ex.Message });
            }
        }

        public async Task<IActionResult> Filter(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _osservice.FindByDateAsync(minDate, maxDate);
            return View(result);
        }


        public IActionResult Error(string Message)
        {
            ErrorViewModel error = new ErrorViewModel() { Message = Message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(error);
        }
    }
}
