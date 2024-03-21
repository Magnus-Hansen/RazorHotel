using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using RazorHotel.Interfaces;
using RazorHotel.Models;

namespace RazorHotel.Pages.Hotels
{
    public class CreateHotelModel : PageModel
    {
        private IHotelService _hotelService;

        [BindProperty]
        public Hotel NewHotel { get; set; }

        public CreateHotelModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _hotelService.CreateHotel(NewHotel);
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
