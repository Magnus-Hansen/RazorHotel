using RazorHotel.Models;

namespace RazorHotel.Helpers
{
    public class HotelAddressCompare : IComparer<Hotel>
    {
        public int Compare(Hotel other, Hotel hotel)
        {
            if (other == null || hotel == null)
                return 0;
            else if (other == null) 
                return -1;
            else if (hotel == null) 
                return 1;

            return string.Compare(other.Address, hotel.Address);
        }
    }
}
