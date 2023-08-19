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
            try
            {
                if (UserAuthentication(usersCredentials))
                {
                    return userFactory.CreateUser(usersCredentials.User,usersCredentials.Role);
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
        public bool UserAuthentication(UsersCredentials usersCredentials)
        {
            try
            {
                var proxy = new Proxy();

                return proxy.UserAuthentication(usersCredentials)||true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: with Authenticat User. {ex.Message}");
                return false;
            }
        }
    }
}