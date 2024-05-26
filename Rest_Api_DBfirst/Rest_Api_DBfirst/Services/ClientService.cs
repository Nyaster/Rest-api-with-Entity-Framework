using Rest_Api_DBfirst.Repositories;

namespace Rest_Api_DBfirst.Services;

public class ClientService
{
    private ClientRepository _clientRepository;

    public ClientService(ClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public void DeleteClient(int id)
    {
        throw new NotImplementedException();
    }
}