namespace TicketBookingSystem.Business
{
    public class Login
    {   
        private UserFactory userFactory;

        public Login()
        {
            userFactory = new UserFactory();
        }
        public IUser GetUserControall(User user,UserRole role)
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
        public bool UserAuthentication(User user,UserRole role)
        {
            try
            {
                var proxy = new Proxy();

                return proxy.UserAuthentication(user,role);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: with Authenticat User. {ex.Message}");
                return false;
            }
        }
    }
}