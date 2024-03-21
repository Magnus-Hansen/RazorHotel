namespace RazorHotel.Models
{
    public class Guest
    {
        public int Guest_No { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }

        public Guest(int guest_No, string name, string address)
        {
            Guest_No = guest_No;
            Name = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Guest_No)}: {Guest_No}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }
}
