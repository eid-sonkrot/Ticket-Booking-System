namespace TicketBookingSystem.Business
{
    public class UserFactory : IUserFactory
    {
        public IUser CreateUser(User user, UserRole role)
        {
            switch (role)
            {
                case UserRole.Manger:
                    return new Manager(user, role);
                case UserRole.Passnger:
                    return new Passenger(user, role);
                default:
                    throw new ArgumentException("Invalid role");
            }
        }
    }
}
