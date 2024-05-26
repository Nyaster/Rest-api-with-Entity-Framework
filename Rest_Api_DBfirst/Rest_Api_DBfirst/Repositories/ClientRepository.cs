using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;
using Rest_Api_DBfirst.Context;
using Rest_Api_DBfirst.Models;

namespace Rest_Api_DBfirst.Repositories;

public class ClientRepository
{
    private ApbdContext _context;

    public ClientRepository(ApbdContext context)
    {
        _context = context;
    }

    public async Task<Client> GetClient(int id)
    {
        var client = await _context.Clients.Where(x => x.IdClient == id).Include(x => x.ClientTrips).SingleAsync();
        return client;
    }

    public async Task DeleteClient(Client client)
    {
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
    }
}