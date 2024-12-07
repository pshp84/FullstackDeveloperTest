using FlightManagementSystem.DTOs;
using FlightManagementSystem.Models;
using FlightManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FlightManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepo;
        private readonly IUserRepository _userRepo;

        public NotificationsController(INotificationRepository notificationRepo, IUserRepository userRepo)
        {
            _notificationRepo = notificationRepo;
            _userRepo = userRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var notifications = await _notificationRepo.GetNotificationsAsync();
            return Ok(new CommonResponse { Status = Status.Success, Data = notifications });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotification(Guid id)
        {
            var notification = await _notificationRepo.GetNotificationByIdAsync(id);
            if (notification == null)
                return Ok(new CommonResponse { Status = Status.Error, Message = "Id is not found." });

            return Ok(new CommonResponse { Status = Status.Success, Data = notification });
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationReqDTO notification)
        {
            try
            {
                var getUser = await _userRepo.GetUserByIdAsync(notification.UserId);
                if (getUser == null)
                    return Ok(new CommonResponse { Status = Status.Error, Message = "UserId is not found." }); 

                Notification model = new()
                {
                    Id = Guid.NewGuid(),
                    UserId = notification.UserId,
                    FlightDetails = notification.FlightDetails,
                    Status = notification.Status
                };
                await _notificationRepo.AddNotificationAsync(model);  
                return Ok(new CommonResponse { Status = Status.Success, Message = "Data is saved successfully.", Data = model });
            }
            catch (Exception ex)
            {
                return Ok(new CommonResponse { Status = Status.Error, Message = ex.Message }); 
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification([Required]Guid id, [FromBody] NotificationReqDTO notification)
        {
            try
            { 
                var getData = await _notificationRepo.GetNotificationByIdAsync(id);
                if (getData == null)
                    return Ok(new CommonResponse { Status = Status.Error, Message = "Id is not found." });

                var getUser = await _userRepo.GetUserByIdAsync(notification.UserId);
                if (getUser == null)
                    return Ok(new CommonResponse { Status = Status.Error, Message = "UserId is not found." });

                getData.UserId = notification.UserId;
                getData.FlightDetails = notification.FlightDetails;
                getData.Status = notification.Status;

                await _notificationRepo.UpdateNotificationAsync(getData);
                return Ok(new CommonResponse { Status = Status.Success, Message = "Data is saved successfully.", Data = getData });
            }
            catch (Exception ex)
            {
                return Ok(new CommonResponse { Status = Status.Error, Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(Guid id)
        {
            try
            {
                await _notificationRepo.DeleteNotificationAsync(id);
                return Ok(new CommonResponse { Status = Status.Success, Message = "Data is deleted successfully." });
            }
            catch (Exception ex)
            {
                return Ok(new CommonResponse { Status = Status.Error, Message = ex.Message });
            }
        } 
    }
}
