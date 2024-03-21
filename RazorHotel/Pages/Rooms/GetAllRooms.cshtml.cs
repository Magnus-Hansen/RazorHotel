using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using RazorHotel.Interfaces;
using RazorHotel.Models;

namespace RazorHotel.Pages.Rooms
{
    public class GetAllRoomsModel : PageModel
    {
        private IRoomService _roomService;

        public List<Room> Rooms { get; set; }

        public GetAllRoomsModel(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public void OnGet(int hotel_No)
        {
            try
            {
                Rooms = _roomService.GetAllRoom(hotel_No);
            }
            catch (SqlException sql)
            {
                ViewData["ErrorMessage"] = sql.Message;
            }
            catch (Exception ex)
            {
                Rooms = new List<Room>();
                ViewData["ErrorMessage"] = ex.Message;
            }
        }
    }
}
