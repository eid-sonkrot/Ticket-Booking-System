namespace TicketBookingSystem.Business
{
    public class Login
    {   
        private UserFactory userFactory;

        public Login()
        {
            userFactory = new UserFactory();
        }
        public IUser GetUserControall(UsersCredentials usersCredentials)
        {
            if (UserAuthentication(user, role))
            {
                return userFactory.CreateUser(user, role);
            }
            else
            {
                throw new Exception("Authentication failed");
            }
        }
        public bool UserAuthentication(UsersCredentials usersCredentials)
        {
            try
            {
                var proxy = new Proxy();

                return proxy.UserAuthentication(usersCredentials);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: with Authenticat User. {ex.Message}");
                return false;
            }
        }
    }
}