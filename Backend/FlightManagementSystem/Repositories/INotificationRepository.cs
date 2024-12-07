using FlightManagementSystem.Models;

namespace FlightManagementSystem.Repositories
{
    public interface INotificationRepository
    {
        Task<List<Notification>> GetNotificationsAsync();
        Task<Notification> GetNotificationByIdAsync(Guid id);
        Task AddNotificationAsync(Notification notification);
        Task UpdateNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(Guid id);
    }
}
