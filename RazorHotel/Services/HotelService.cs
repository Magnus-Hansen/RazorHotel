using Microsoft.Data.SqlClient;
using RazorHotel.Interfaces;
using RazorHotel.Models;
using System.Data;

namespace RazorHotel.Services
{
    public class HotelService : Connection, IHotelService
    {
        private string queryString = "SELECT Hotel_No, Name, Address FROM Hotel";
        private string insertSql = "INSERT INTO Hotel VALUES(@Id, @Name, @Address)";
        private string _getSqlById = "SELECT * FROM Hotel WHERE Hotel_No=@Id";
        private string _getSqlByName = "SELECT * FROM Hotel WHERE Name LIKE @Name";
        private string _deleteSql = "DELETE FROM Hotel WHERE Hotel_No=@Id";
        private string _updateSql = "UPDATE Hotel SET Hotel_No=@Id, Name=@Name, Address=@Address WHERE Hotel_No=@OldId";
        public bool CreateHotel(Hotel hotel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(insertSql, connection);
                    command.Parameters.AddWithValue("@Id", hotel.Hotel_No);
                    command.Parameters.AddWithValue("@Name", hotel.Name);
                    command.Parameters.AddWithValue("@Address", hotel.Address);
                    command.Connection.Open();
                    int noOfRows = command.ExecuteNonQuery();
                    return noOfRows == 1;
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("Database error: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General fejl: " + ex.Message);
                }
                finally
                {

                }
            }
            return false;
        }

        public Hotel DeleteHotel(int hotelNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    Hotel hotel = GetHotelFromId(hotelNo);

                    SqlCommand deleteCommand = new SqlCommand(_deleteSql, connection);
                    deleteCommand.Parameters.AddWithValue("@Id", hotelNo);
                    deleteCommand.Connection.Open();
                    deleteCommand.ExecuteNonQuery();

                    return hotel;
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("Database error: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General fejl: " + ex.Message);
                }
                finally
                {

                }
            }
            return null;
        }

        public List<Hotel> GetAllHotel()
        {
            List<Hotel> hotels = new List<Hotel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int hotelNo = reader.GetInt32("Hotel_No");
                        string hotelName = reader.GetString("Name");
                        string hotelAddress = reader.GetString("Address");
                        Hotel hotel = new Hotel(hotelNo, hotelName, hotelAddress);
                        hotels.Add(hotel);
                    }
                    reader.Close();
            }
                catch (SqlException sqlEx)
                {
                Console.WriteLine("Database error: " + sqlEx.Message);
                throw sqlEx;
            }
                catch (Exception ex)
                {
                Console.WriteLine("General fejl: " + ex.Message);
                throw ex;
            }
                finally
                {

            }
        }
            return hotels;
        }

        public Hotel GetHotelFromId(int oldHotelNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(_getSqlById, connection);
                    command.Parameters.AddWithValue("@Id", oldHotelNo);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int hotelNo = reader.GetInt32("Hotel_No");
                        string hotelName = reader.GetString("Name");
                        string hotelAddress = reader.GetString("Address");
                        Hotel hotel = new Hotel(hotelNo, hotelName, hotelAddress);
                        return hotel;
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("Database error: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General fejl: " + ex.Message);
                }
                finally
                {

                }
            }
            return null;
        }

        public List<Hotel> GetHotelsByName(string name)
        {
            List<Hotel> hotels = new List<Hotel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(_getSqlByName, connection);
                    command.Parameters.AddWithValue("@Name", "%"+name+"%");
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int hotelNo = reader.GetInt32("Hotel_No");
                        string hotelName = reader.GetString("Name");
                        string hotelAddress = reader.GetString("Address");
                        Hotel hotel = new Hotel(hotelNo, hotelName, hotelAddress);
                        hotels.Add(hotel);
                    }
                    reader.Close();

                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("Database error: " + sqlEx.Message);
                    throw sqlEx;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General fejl: " + ex.Message);
                    throw ex;
                }
                finally
                {

                }
            }
            return hotels;
        }

        public bool UpdateHotel(Hotel hotel, int oldHotelNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(_updateSql, connection);
                    command.Parameters.AddWithValue("@OldId", oldHotelNo);
                    command.Parameters.AddWithValue("@Id", hotel.Hotel_No);
                    command.Parameters.AddWithValue("@Name", hotel.Name);
                    command.Parameters.AddWithValue("@Address", hotel.Address);
                    command.Connection.Open();
                    int noOfRows = command.ExecuteNonQuery();
                    return noOfRows == 1;
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("Database error: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General fejl: " + ex.Message);
                }
                finally
                {

                }
            }
            return false;
        }
    }
}
