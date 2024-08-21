using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using XPTOMVC.Data;
using XPTOMVC.Models;
using XPTOMVC.Services.Exceptions;

namespace XPTOMVC.Services
{
	public class PrestadorServicoService
	{
		private readonly XPTOMVCContext _context;

		public PrestadorServicoService(XPTOMVCContext context)
		{
			_context = context;
		}

		public async Task<List<PrestadorServico>> FindAllAsync()
		{
			return await _context.PrestadorServico.ToListAsync();
		}

        public async Task<PrestadorServico> FindByCPFAsync(int id)
        {
            return await _context.PrestadorServico.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(PrestadorServico prestador)
        {
            if (await _context.PrestadorServico.AnyAsync(x => x.CPF == prestador.CPF))
            {
                throw new NotFoundException("Esse serviço já existe!");
            }

            _context.Add(prestador);
            await _context.SaveChangesAsync();
        }

		public async Task UpdateAsync(PrestadorServico prestador)
		{
			if (!await _context.PrestadorServico.AnyAsync(x => x.Id == prestador.Id))
			{
				throw new NotFoundException("Esse Serviço não existe no banco de dados!");
			}
			try
			{
				_context.Update(prestador);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				throw new DbConcurrencyException(ex.Message);
			}
		}

        public async Task RemoveAsync(int id)
        {
            try
            {
                var req = await _context.PrestadorServico.FindAsync(id);
                _context.PrestadorServico.Remove(req);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }
    }
}
