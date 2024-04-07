namespace LegacyApp;

public class UserCreditLimits
{
    private Client Client { get; set; }
    private User User { get; set; }

    public UserCreditLimits(Client client, User user)
    {
        Client = client;
        User = user;
    }

    public void SetCreditLimit()
    {
        if (Client.Type == "VeryImportantClient")
            User.HasCreditLimit = false;
        else
        {
            using (var userCreditService = new UserCreditService())
            {
                int creditLimit = userCreditService.GetCreditLimit(User.LastName, User.DateOfBirth);
                if (Client.Type == "ImportantClient")
                {
                    creditLimit *= 2;
                }

                User.HasCreditLimit = true;
                User.CreditLimit = creditLimit;
            }
        }
    }

    public bool isRich()
    {
        if (User.HasCreditLimit && User.CreditLimit < 500) return false;
        return true;
    }
}