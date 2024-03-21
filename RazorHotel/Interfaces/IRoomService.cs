using RazorHotel.Models;

namespace RazorHotel.Interfaces
{
    public interface IRoomService
    {
        /// <summary>
        /// henter alle værelser til et hotel fra databasen
        /// </summary>
        /// <param name="hotelNo">Nummeret på hotellet</param>
        /// <returns>Liste af værelser</returns>
        List<Room> GetAllRoom(int hotelNo);

        /// <summary>
        /// Henter et specifik værelse fra database 
        /// </summary>
        /// <param name="roomNo">Udpeger det værelse der ønskes fra databasen</param>
        /// <param name="hotelNo">Nummeret på hotellet</param>
        /// <returns>Den fundne værelse eller null hvis værelset ikke findes</returns>
        Room GetRoomFromId(int roomNo, int hotelNo);

        /// <summary>
        /// Indsætter et ny værelse i databasen
        /// </summary>
        /// <param name="room">Værelset der skal indsættes</param>
        /// <param name="hotelNo">Nummeret på hotellet</param>
        /// <returns>Sand hvis der er gået godt ellers falsk</returns>
        bool CreateRoom(Room room);

        /// <summary>
        /// Opdaterer en værelset i databasen
        /// </summary>
        /// <param name="room">De nye værdier til værelset</param>
        /// <param name="roomNo">Nummer på det værelse der skal opdateres</param>
        /// <param name="hotelNo">Nummeret på hotellet</param>
        /// <returns>Sand hvis der er gået godt ellers falsk</returns>
        bool UpdateRoom(Room room, int roomNo, int hotelNo);

        /// <summary>
        /// Sletter et værelse fra databasen
        /// </summary>
        /// <param name="roomNr">Nummer på det værelse der skal slettes</param>
        /// <param name="hotelNr">Nummeret på hotellet</param>
        /// <returns>Det værelse der er slettet fra databasen, returnere null hvis værelset ikke findes</returns>
        Room DeleteRoom(int roomNr, int hotelNr);

    }
}
