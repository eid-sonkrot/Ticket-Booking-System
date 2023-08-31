namespace TicketBookingSystem.Business
{
    public class UserFactory : IUserFactory
    {
        public IUser CreateUser(User user, UserRole role)
        {
            return role switch
            {
                UserRole.Manger => new Manager(user, role),
                UserRole.Passnger => new Passenger(user, role),
                _ => throw new ArgumentException("Invalid role")
            };
        }
    }
}
