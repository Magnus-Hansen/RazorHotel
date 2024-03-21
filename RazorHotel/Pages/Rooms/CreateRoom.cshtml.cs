using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using RazorHotel.Interfaces;
using RazorHotel.Models;

namespace RazorHotel.Pages.Rooms
{
    public class CreateRoomModel : PageModel
    {
        private IRoomService _roomService;

        [BindProperty]
        public Room NewRoom { get; set; }

        public CreateRoomModel(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public void OnGet(int hotel_No)
        {
        }

        public IActionResult OnPost(int hotel_No)
        {
            NewRoom.Hotel_No = hotel_No;
            try
            {
                _roomService.CreateRoom(NewRoom);
            }
            catch (SqlException sql)
            {
                ViewData["ErrorMessage"] = sql.Message;
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return RedirectToPage("GetallRooms", new { hotel_No = hotel_No });
        }
    }
}
