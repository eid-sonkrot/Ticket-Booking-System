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
            try
            {
                if (UserAuthentication(user, role))
                {
                    return userFactory.CreateUser(user, role);
                }else
                {
                    Console.WriteLine("Authentication failed.");
                    return null;
                }
            }catch(Exception ex)
            {
                Console.WriteLine($"Error: with Creat User. {ex.Message}");
                return null;
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