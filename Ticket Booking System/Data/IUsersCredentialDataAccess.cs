using TicketBookingSystem.Business;

namespace TicketBookingSystem.Data
{
    public interface IUsersCredentialDataAccess
    {
        List<UsersCredentials> ReadUsersCredentials();
        bool WriteUsersCredentials(List<UsersCredentials> usersCredentials);
    }
}
