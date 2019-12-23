using TripLog.Models;

namespace TripLog.Services
{
    public interface IGeoLocation
    {
        Coordinates GetCoordinates();
    }
}
