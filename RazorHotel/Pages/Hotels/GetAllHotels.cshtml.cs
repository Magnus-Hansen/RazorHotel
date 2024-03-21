using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using RazorHotel.Helpers;
using RazorHotel.Interfaces;
using RazorHotel.Models;
using System.Data.SqlTypes;

namespace RazorHotel.Pages.Hotels
{
    public class GetAllHotelsModel : PageModel
    {
        private IHotelService _hotelService;

        public List<Hotel> Hotels { get; private set; }
        [BindProperty(SupportsGet =true)]
        public string FilterCriteria { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SortOrder { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SortOrderAscDesc { get; set; }

        public GetAllHotelsModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public void OnGet()
        {
            try
            {
                if (!String.IsNullOrEmpty(FilterCriteria))
                {
                    Hotels = _hotelService.GetHotelsByName(FilterCriteria);
                }
                else
                {
                    Hotels = _hotelService.GetAllHotel();
                }
                if (SortOrder == "Name")
                    Hotels.Sort();
                if (SortOrder == "Address")
                    Hotels.Sort(new HotelAddressCompare());
                if (SortOrderAscDesc == "Descending")
                    Hotels.Reverse();
            }
            catch (SqlException sql)
            {
                ViewData["ErrorMessage"] = sql.Message;
            }
            catch (Exception ex)
            {
                Hotels = new List<Hotel>();
                ViewData["ErrorMessage"] = ex.Message;
            }
        }
    }
}
