using Microsoft.AspNetCore.DataProtection;

namespace RazorHotel.Services
{
    public class Connection
    {
        protected string connectionString = Secret.ConnectionString;
    }
}
