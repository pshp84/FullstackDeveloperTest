using FlightManagementSystem.DTOs;
using Google.Apis.Auth.OAuth2;
using Google.Apis.FirebaseCloudMessaging.v1;
using Google.Apis.FirebaseCloudMessaging.v1.Data;
using Google.Apis.Services;

namespace FlightManagementSystem.Services
{
    public class NotificationService
    {
        private readonly string _msgApiKey;
        GoogleCredential credential;
        FirebaseCloudMessagingService fcmService;
        public NotificationService(IConfiguration configuration)
        {
            _msgApiKey = configuration.GetSection("Firebase:MessageApiKey").Value;

            // Authenticate using the service account key
            using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "Service", "myapp-firebase-admin.json"), FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped("https://www.googleapis.com/auth/firebase.messaging");
            }

            // Initialize the Firebase Cloud Messaging client
            fcmService = new FirebaseCloudMessagingService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "MyApp",
            });
        }

        public async Task<FirebaseMsgApiRes> SendMessage(SendMessageRequest req)
        {
            try
            {
                //*** Start:
                //*** Below code use to send the notification to mobile phones where you can pass mobile token which will send notificaiton to mobile phones 

                var message = new Message
                {
                    Token = "mobiletoken",  // Need to pass the actual mobile token 
                    Notification = new Google.Apis.FirebaseCloudMessaging.v1.Data.Notification
                    {
                        Title = "Notification",
                        Body = "message you want to send",
                    },
                };

                SendMessageRequest apiReq = new()
                {
                    Message = message
                };

                var request = fcmService.Projects.Messages.Send(new SendMessageRequest { Message = req.Message }, "projects/myapp-df257");
                var response = await request.ExecuteAsync();

                var resobj = new FirebaseMsgApiRes()
                {
                    success = true,
                    name = response.Name.ToString(),
                };
                return resobj;

                //** End comment 
            } 
            catch (Exception ex)
            {
                var resobj = new FirebaseMsgApiRes()
                {
                    success = false,
                    name = ex.Message.ToString(),
                };
                return resobj;
            }
        }
    }
}
