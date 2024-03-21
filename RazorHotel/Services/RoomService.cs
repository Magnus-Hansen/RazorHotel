using Microsoft.Data.SqlClient;
using RazorHotel.Interfaces;
using RazorHotel.Models;
using System.Data;

namespace RazorHotel.Services
{
    public class RoomService : Connection, IRoomService
    {
        private string _getAllFromHotelString = "SELECT Room_No, Types, Price, Hotel_No FROM Room WHERE Hotel_No=@HotelId";
        private string _getAllString = "SELECT Room_No, Types, Price, Hotel_No FROM Room";
        private string _getSqlById = "SELECT * FROM Room WHERE Room_No=@RoomId AND Hotel_No=@HotelId";
        private string _insertSql = "INSERT INTO Room VALUES(@RoomId, @HotelId, @Types, @Price)";
        private string _deleteSql = "DELETE FROM Room WHERE Room_No=@RoomId AND Hotel_No=@HotelId";
        private string _updateSql = "UPDATE Room SET Room_No=@RoomId, Types=@Types, Price=@Price, Hotel_No=@HotelId WHERE Room_No=@OldRoomId AND Hotel_No=@OldHotelId";

        public bool CreateRoom(Room room)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(_insertSql, connection);
                    command.Parameters.AddWithValue("@RoomId", room.Room_No);
                    command.Parameters.AddWithValue("@Types", room.Types);
                    command.Parameters.AddWithValue("@Price", room.Price);
                    command.Parameters.AddWithValue("@HotelId", room.Hotel_No);
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

        public Room DeleteRoom(int roomNo, int hotelNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    Room room = GetRoomFromId(roomNo, hotelNo);

                    SqlCommand deleteCommand = new SqlCommand(_deleteSql, connection);
                    deleteCommand.Parameters.AddWithValue("@RoomId", roomNo);
                    deleteCommand.Parameters.AddWithValue("@HotelId", hotelNo);
                    deleteCommand.Connection.Open();
                    deleteCommand.ExecuteNonQuery();

                    return room;
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

        public List<Room> GetAllRoom(int oldHotelNo)
        {
            List<Room> rooms = new List<Room>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(_getAllFromHotelString, connection);
                    command.Parameters.AddWithValue("HotelId", oldHotelNo);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int roomNo = reader.GetInt32("Room_No");
                        char roomType = reader.GetString("Types")[0];
                        double roomPrice = reader.GetDouble("Price");
                        int hotelNo = reader.GetInt32("Hotel_No");
                        Room room = new Room(roomNo, roomType, roomPrice, hotelNo);
                        rooms.Add(room);
                    }
                    reader.Close();
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
            return rooms;
        }

        public List<Room> GetAllRoom()
        {
            List<Room> rooms = new List<Room>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(_getAllString, connection);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int roomNo = reader.GetInt32("Room_No");
                        char roomType = reader.GetString("Types")[0];
                        double roomPrice = reader.GetDouble("Price");
                        int hotelNo = reader.GetInt32("Hotel_No");
                        Room room = new Room(roomNo, roomType, roomPrice, hotelNo);
                        rooms.Add(room);
                    }
                    reader.Close();
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
            return rooms;
        }

        public Room GetRoomFromId(int oldRoomNo, int oldHotelNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(_getSqlById, connection);
                    command.Parameters.AddWithValue("@RoomId", oldRoomNo);
                    command.Parameters.AddWithValue("@HotelId", oldHotelNo);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int roomNo = reader.GetInt32("Room_No");
                        char types = reader.GetString("Types")[0];
                        double roomPrice = reader.GetDouble("Price");
                        int hotelNo = reader.GetInt32("Hotel_No");
                        Room room = new Room(roomNo, types, roomPrice, hotelNo);
                        return room;
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

        public bool UpdateRoom(Room room, int roomNo, int hotelNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(_updateSql, connection);
                    command.Parameters.AddWithValue("@OldRoomId", roomNo);
                    command.Parameters.AddWithValue("@OldHotelId", hotelNo);
                    command.Parameters.AddWithValue("@RoomId", room.Room_No);
                    command.Parameters.AddWithValue("@Types", room.Types);
                    command.Parameters.AddWithValue("@Price", room.Price);
                    command.Parameters.AddWithValue("@HotelId", room.Hotel_No);
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
