using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XPTOMVC.Data;
using XPTOMVC.Models;
using XPTOMVC.Services.Exceptions;

namespace XPTOMVC.Services
{
    public class ServicoService
    {
        private readonly XPTOMVCContext _context;

        public ServicoService(XPTOMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Servico>> FindAllAsync()
        {
            return await _context.Servico.ToListAsync();
        }

        public async Task<Servico> FindByTituloAsync(int id)
        {
            return await _context.Servico.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(Servico servico)
        {
            if (await _context.Servico.AnyAsync(x => x.Titulo == servico.Titulo))
            {
                throw new NotFoundException("Esse serviço já existe!");
            }

            _context.Add(servico);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Servico servico)
        {
            if (!await _context.Servico.AnyAsync(x => x.Id == servico.Id))
            {
                throw new NotFoundException("Esse Serviço não existe no banco de dados!");
            }
            try
            {
                _context.Update(servico);
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
				var req = await _context.Servico.FindAsync(id);
				_context.Servico.Remove(req);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException ex)
			{
				throw new IntegrityException(ex.Message);
			}
		}

    }
}
