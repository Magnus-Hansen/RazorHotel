using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RazorHotel.Models
{
    public class Room
    {
        public int Room_No { get; set; }
        public char Types { get; set; }
        public double Price { get; set; }
        public int Hotel_No { get; set; }

        public Room()
        {

        }
        public Room(int roomNo, char types, double price)
        {
            Room_No = roomNo;
            Types = types;
            Price = price;
        }

        public Room(int nr, char types, double pris, int hotelNo) : this(nr, types, pris)
        {
            Hotel_No = hotelNo;
        }

        public override string ToString()
        {
            return $"Room = {Room_No}, Types = {Types}, Pris = {Price}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Room)) return false;
            if (
                (((Room)obj).Room_No == this.Room_No) &&
                (((Room)obj).Types == this.Types) &&
                (((Room)obj).Price == this.Price) &&
                (((Room)obj).Hotel_No == this.Hotel_No)
            ) return true;
            return false;
        }
    }
}
