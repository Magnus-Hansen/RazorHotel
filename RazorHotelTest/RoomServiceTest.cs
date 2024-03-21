using RazorHotel.Interfaces;
using RazorHotel.Models;
using RazorHotel.Services;

namespace RazorHotelTest
{
    [TestClass]
    public class RoomServiceTest
    {
        IRoomService _roomService = new RoomService();

        [TestMethod]
        public void TestCreateHotel()
        {
            int numberBefore = _roomService.GetAllRoom(1).Count();

            Room room = new Room(50, 'S', 500, 1);
            _roomService.CreateRoom(room);
            int numberAfter = _roomService.GetAllRoom(1).Count();
            _roomService.DeleteRoom(room.Room_No, 1);

            Assert.AreEqual(numberBefore + 1, numberAfter);
        }

        [TestMethod]
        public void TestDeleteHotel()
        {
            Room room = new Room(60, 'D', 600, 1);
            _roomService.CreateRoom(room);
            int numberBefore = _roomService.GetAllRoom(1).Count();

            _roomService.DeleteRoom(room.Room_No, 1);
            int numberAfter = _roomService.GetAllRoom(1).Count();

            Assert.AreEqual(numberBefore - 1, numberAfter);
        }

        [TestMethod]
        public void TestUpdateRoom()
        {
            Room room = new Room(70, 'S', 500, 1);
            _roomService.CreateRoom(room);

            Room newRoom = new Room(80, 'D', 600, 1);
            _roomService.UpdateRoom(newRoom, 70, 1);
            Room testRoom = _roomService.GetRoomFromId(80, 1);
            _roomService.DeleteRoom(80, 1);

            Assert.AreEqual(testRoom, newRoom);
        }
    }
}