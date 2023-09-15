public record UsersCredentials()
{
    public User User { get; set; }
    public UserRole Role { get; set; }

    public UsersCredentials FillFromStrings(string[] values)
    {
        if (values.Length != 2)
        {
            throw new ArgumentException("Exactly 2 values are required to fill the Airport record.");
        }

        return new UsersCredentials
        {
            User=new User().FillFromStrings( values.Take(5).ToArray()),
            Role=Enum.Parse<UserRole>(values[5])
        };
    }
    public string[] ToArrayOfString()
    {
        return User.ToArrayOfStrign().Append(Role.ToString()).ToArray();
    }
}