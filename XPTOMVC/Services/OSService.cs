using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPTOMVC.Data;
using XPTOMVC.Models;
using XPTOMVC.Services.Exceptions;

namespace XPTOMVC.Services
{
    public class OSService
    {
        private readonly XPTOMVCContext _context;

        public OSService(XPTOMVCContext context)
        {
            _context = context;
        }

        public async Task<List<OS>> FindAllAsync()
        {
            return await _context.OS.Include(x => x.Servico).
									 Include(x => x.Cliente).
									 Include(x => x.PrestadorServico).ToListAsync();
        }

        public async Task<OS> FindByNumeroAsync(int numero)
        {
            return await _context.OS.Include(x => x.Servico).
                                     Include(x => x.Cliente).
                                     Include(x => x.PrestadorServico).
                                     FirstOrDefaultAsync(x => x.Id == numero);
        }

        public async Task CreateAsync(OS os)
        {
            _context.Add(os);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OS os)
        {
            if (!await _context.OS.AnyAsync(x => x.Id == os.Id))
            {
                throw new NotFoundException("Essa OS não está registrado no banco de dados!");
            }
            try
            {
                _context.Update(os);
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
                var req = await _context.OS.FindAsync(id);
                _context.OS.Remove(req);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }

        public async Task<List<OS>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.OS select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.DataExecucao >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.DataExecucao <= maxDate.Value);
            }
            return await result
                .Include(x => x.Cliente)
                .Include(x => x.Servico)
                .Include(x => x.PrestadorServico)
                .OrderByDescending(x => x.DataExecucao)
                .ToListAsync();
        }


    }
}
