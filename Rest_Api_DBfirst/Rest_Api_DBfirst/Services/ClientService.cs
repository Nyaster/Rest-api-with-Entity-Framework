using Rest_Api_DBfirst.Errors;
using Rest_Api_DBfirst.Repositories;

namespace Rest_Api_DBfirst.Services;

public class ClientService
{
    private ClientRepository _clientRepository;

    public ClientService(ClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task DeleteClient(int id)
    {
        var client = await _clientRepository.GetClient(id);
        if (client.ClientTrips.Count > 0)
        {
            throw new ClientTripsException();
        }

        await _clientRepository.DeleteClient(client);
    }
}