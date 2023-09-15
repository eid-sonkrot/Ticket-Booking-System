namespace TicketBookingSystem.Business
{
    public class Login
    {   
        private UserFactory userFactory;
        private IProxy proxy=new Proxy(); 

        public Login()
        {
            userFactory = new UserFactory();
        }
        public void SetProxy(IProxy proxy)
        {
            this.proxy=proxy;
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