using TicketBookingSystem.Business;

namespace TicketBookingSystem.View
{
    public class LoginUI
    {
        private Login? Login = new Login();
        private static LoginUI? instance;

        private LoginUI() 
        { 
        }
        public IUser LoginUser()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Login UI");
            Console.Write("Select user role (1 for Passenger, 2 for Manager): ");
            var roleChoice = int.Parse(Console.ReadLine());

            Console.Write("Enter your email: ");
            var email= Console.ReadLine();

            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            var role = (UserRole)roleChoice;

            // Now you have the user's role, email, and password.
            // Implement authentication logic based on these inputs.
            // Example: Call a method to authenticate the user based on role, email, and password.
            var user = new User()
            {
                Email = email,
                HashedPassword= BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt())
            };
            var usersCredentials = new UsersCredentials
            {
                Role=role,
                User=user
            };

            return Login.GetUserControall(usersCredentials);
        }
        public static LoginUI GetLoginUI()
        {
            if(instance is null)
            {
                instance=new LoginUI();
            }
            return instance;
        }
    }
}