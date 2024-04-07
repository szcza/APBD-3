using System;

namespace LegacyApp;

public class UserCreator
{
    private ClientRepository ClientRepository;

    public UserCreator(ClientRepository clientRepository)
    {
        ClientRepository = clientRepository;
    }

    public User CreateUser(Client client,DateTime dateOfBirth,string email, string firstName, string lastName)
    {
        var user = new User
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName
        };
        return user;
    }
    
}