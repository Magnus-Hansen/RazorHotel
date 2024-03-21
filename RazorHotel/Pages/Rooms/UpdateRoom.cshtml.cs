using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using RazorHotel.Interfaces;
using RazorHotel.Models;
using RazorHotel.Services;

namespace RazorHotel.Pages.Rooms
{
    public class UpdateRoomModel : PageModel
    {
        private IRoomService _roomService;

        [BindProperty]
        public Room RoomToUpdate { get; set; }

        public UpdateRoomModel(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public void OnGet(int room_no, int hotel_no)
        {
            RoomToUpdate = _roomService.GetRoomFromId(room_no, hotel_no);
        }

        public IActionResult OnPostUpdate()
        {
            try
            {
                _roomService.UpdateRoom(RoomToUpdate, RoomToUpdate.Room_No, RoomToUpdate.Hotel_No);
            }
            catch (SqlException sql)
            {
                ViewData["ErrorMessage"] = sql.Message;
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return RedirectToPage("GetAllRooms", new { hotel_No = RoomToUpdate.Hotel_No });
        }

        public IActionResult OnPostDelete()
        {
            try
            {
                _roomService.DeleteRoom(RoomToUpdate.Room_No, RoomToUpdate.Hotel_No);
            }
            catch (SqlException sql)
            {
                ViewData["ErrorMessage"] = sql.Message;
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return RedirectToPage("GetAllRooms", new { hotel_No = RoomToUpdate.Hotel_No });
        }
    }
}
