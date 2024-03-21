using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotel.Models;
using RazorHotel.Interfaces;
using Microsoft.Data.SqlClient;

namespace RazorHotel.Pages.Hotels
{
    public class UpdateHotelModel : PageModel
    {
        private IHotelService _hotelService;

        [BindProperty]
        public Hotel HotelToUpdate { get; set; }

        public UpdateHotelModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        public void OnGet(int hotel_No)
        {
            HotelToUpdate = _hotelService.GetHotelFromId(hotel_No);
        }

        public IActionResult OnPostUpdate()
        {
            try
            {
                _hotelService.UpdateHotel(HotelToUpdate, HotelToUpdate.Hotel_No);
            }
            catch (SqlException sql)
            {
                ViewData["ErrorMessage"] = sql.Message;
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return RedirectToPage("GetAllHotels");
        }

        public IActionResult OnPostDelete()
        {
            try
            {
                _hotelService.DeleteHotel(HotelToUpdate.Hotel_No);
            }
            catch (SqlException sql)
            {
                ViewData["ErrorMessage"] = sql.Message;
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return RedirectToPage("GetAllHotels");
        }
    }
}
