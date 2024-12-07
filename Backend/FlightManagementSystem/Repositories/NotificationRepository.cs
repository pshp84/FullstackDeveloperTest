using FlightManagementSystem.Data;
using FlightManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementSystem.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDBContext _context;

        public NotificationRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Notification>> GetNotificationsAsync()
            => await _context.Notifications.ToListAsync();

        public async Task<Notification> GetNotificationByIdAsync(Guid id)
        {
            return await _context.Notifications.FindAsync(id);
        } 

        public async Task AddNotificationAsync(Notification notification)
        { 
            bool exists = await _context.Notifications.AnyAsync(n =>
                n.FlightDetails == notification.FlightDetails &&
                n.UserId == notification.UserId &&
                n.Status == notification.Status);

            if (exists)
            {
                throw new InvalidOperationException("A similar notification already exists.");
            }

            notification.CreatedOn = DateTime.UtcNow;
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNotificationAsync(Notification notification)
        { 
            bool exists = await _context.Notifications.AnyAsync(n =>
                n.FlightDetails == notification.FlightDetails &&
                n.UserId == notification.UserId &&
                n.Status == notification.Status &&
                n.Id != notification.Id);

            if (exists)
            {
                throw new InvalidOperationException("A similar notification already exists.");
            }

            notification.UpdatedOn = DateTime.UtcNow;
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNotificationAsync(Guid id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }
    }
}