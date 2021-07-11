namespace IRL.Bookings.Domain.Bookings.ValueObjects
{
    public class CustomerInfo
    {
        public CustomerInfo(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}