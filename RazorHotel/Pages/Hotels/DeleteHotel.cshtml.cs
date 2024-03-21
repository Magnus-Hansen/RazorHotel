using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using RazorHotel.Interfaces;
using RazorHotel.Models;

namespace RazorHotel.Pages.Hotels
{
    public class DeleteHotelModel : PageModel
    {
        private IHotelService _hotelService;
        public Hotel DeleteHotel {  get; set; }
        public DeleteHotelModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        public IActionResult OnGet(int hotel_No)
        {
            try
            {
                DeleteHotel = _hotelService.GetHotelFromId(hotel_No);
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
        }
        public IActionResult OnPost(int hotel_No)
        {
            try
            {
                _hotelService.DeleteHotel(hotel_No);
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
