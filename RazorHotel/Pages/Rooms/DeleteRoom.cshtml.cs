using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using RazorHotel.Interfaces;
using RazorHotel.Models;

namespace RazorHotel.Pages.Rooms
{
    public class DeleteRoomModel : PageModel
    {
        private IRoomService _roomService;
        public Room DeleteRoom { get; set; }
        public DeleteRoomModel(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public IActionResult OnGet(int room_No, int hotel_No)
        {
            try
            {
                DeleteRoom = _roomService.GetRoomFromId(room_No, hotel_No);
            }
            catch (SqlException sql)
            {
                ViewData["ErrorMessage"] = sql.Message;
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return Page();
            //return RedirectToPage("GetAllRooms", new { hotel_No = hotel_No });
        }
        public IActionResult OnPostDelete(int room_No, int hotel_No)
        {
            try
            {
                _roomService.DeleteRoom(room_No, hotel_No);
            }
            catch (SqlException sql)
            {
                ViewData["ErrorMessage"] = sql.Message;
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return RedirectToPage("GetAllRooms", new { hotel_No = hotel_No });
        }
    }
}
