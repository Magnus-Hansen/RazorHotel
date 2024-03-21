using RazorHotel.Interfaces;
using RazorHotel.Models;
using RazorHotel.Services;

namespace RazorHotelTest
{
    [TestClass]
    public class HotelServiceTest
    {
        IHotelService _hotelService = new HotelService();

        [TestMethod]
        public void TestCreateHotel()
        {
            int numberBefore = _hotelService.GetAllHotel().Count();

            Hotel hotel = new Hotel(9, "test", "test2");
            _hotelService.CreateHotel(hotel);
            int numberAfter = _hotelService.GetAllHotel().Count();
            _hotelService.DeleteHotel(hotel.Hotel_No);

            Assert.AreEqual(numberBefore + 1, numberAfter);
        }

        [TestMethod]
        public void TestDeleteHotel()
        {
            Hotel hotel = new Hotel(9, "test", "test2");
            _hotelService.CreateHotel(hotel);
            int numberBefore = _hotelService.GetAllHotel().Count();

            _hotelService.DeleteHotel(hotel.Hotel_No);
            int numberAfter = _hotelService.GetAllHotel().Count();

            Assert.AreEqual(numberBefore - 1, numberAfter);
        }

        [TestMethod]
        public void TestUpdateHotel()
        {
            Hotel hotel = new Hotel(9, "test", "test2");
            _hotelService.CreateHotel(hotel);

            Hotel newHotel = new Hotel(9, "updated", "updated");
            _hotelService.UpdateHotel(newHotel, 9);
            Hotel testhotel = _hotelService.GetHotelFromId(9);
            _hotelService.DeleteHotel(9);

            Assert.AreEqual(testhotel, newHotel);
        }
    }
}