using System.ComponentModel.DataAnnotations;

namespace RazorHotel.Models
{
    /// <summary>
    /// En klasse der reprensentere et hotel og gør brug af ICompareble interfacet
    /// </summary>
    public class Hotel : IComparable<Hotel>
    {
        /// <summary>
        /// Hotellets primære nøgle og repræsentere hotelnummeret
        /// </summary>
        [Required(ErrorMessage = "id er påkrævet")]
        public int Hotel_No { get; set; }
        /// <summary>
        /// Hotellets Navn
        /// </summary>
        [Required(ErrorMessage = "navn er påkrævet")]
        public String Name { get; set; }
        /// <summary>
        /// Hotellets Addresse
        /// </summary>
        [Required(ErrorMessage="Adresse er påkrævet")]
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

        /// <summary>
        /// Tjekker om hotellets nummer, navn og addresse er den samme som objektet den får ind som parmeter
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true hvis objektet er et hotel med samme værdier, ellers false</returns>
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
        /// <summary>
        /// Sammenligner med hotellets navn
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>-1 hvis den kommer før parameterinput, 0 hvis samme værdi, 1 hvis den kommer efter parameter input</returns>
        public int CompareTo(Hotel? hotel)
        {
            return Name.CompareTo(hotel.Name);
        }
    }
}
