namespace RazorHotel.Models
{
    public class Hotel : IComparable<Hotel>
    {
        public int Hotel_No { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }

        public Hotel()
        {
        }

        public Hotel(int hotelNo, string name, string address)
        {
            Hotel_No = hotelNo;
            Name = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Hotel_No)}: {Hotel_No}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Hotel)) return false;
            if (
                (((Hotel)obj).Hotel_No == this.Hotel_No) &&
                (((Hotel)obj).Name == this.Name) &&
                (((Hotel)obj).Address == this.Address)
            ) return true;
            return false;
        }
        public int CompareTo(Hotel? hotel)
        {
            return Name.CompareTo(hotel.Name);
        }
    }
}
