namespace TicketBookingSystem.Business
{
    public interface IProxy
    {
        public bool UserAuthentication(UsersCredentials usersCredentials);
    }
}
