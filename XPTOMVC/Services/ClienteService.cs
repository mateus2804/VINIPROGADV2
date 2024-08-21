using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using XPTOMVC.Data;
using XPTOMVC.Models;
using XPTOMVC.Services.Exceptions;

namespace XPTOMVC.Services
{
	public class ClienteService
	{
        private readonly XPTOMVCContext _context;

        public ClienteService(XPTOMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> FindAllAsync()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente> FindByCNPJAsync(int id)
        {
            return await _context.Cliente.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(Cliente cliente)
        {
            if (await _context.Cliente.AnyAsync(x => x.CNPJ == cliente.CNPJ))
            {
                throw new NotFoundException("Esse cliente já está registrado!");
            }

            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            if (!await _context.Cliente.AnyAsync(x => x.Id == cliente.Id))
            {
                throw new NotFoundException("Esse Cliente não está registrado no banco de dados!");
            }
            try
            {
                _context.Update(cliente);
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
                var req = await _context.Cliente.FindAsync(id);
                _context.Cliente.Remove(req);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }

    }
}
