using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotel.Interfaces;
using RazorHotel.Models;

namespace RazorHotel.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private IHotelService _hotelService;

        public List<Hotel> AllHotels { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHotelService hotelService)
        {
            _logger = logger;
            _hotelService = hotelService;
        }

        public void OnGet()
        {
            AllHotels = _hotelService.GetAllHotel();
        }
    }
}
