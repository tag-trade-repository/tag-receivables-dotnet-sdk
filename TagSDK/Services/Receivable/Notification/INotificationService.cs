using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TagSDK.Models.Enums;
using TagSDK.Models.Receivable.Notification;

namespace TagSDK.Services.Receivable.Notification
{
    public interface INotificationService
    {
        Task<List<NotificationDefaultResponse<NotificationSettlement>>> GetSettlementNotification(DateTime date, Profile profile);
        Task<List<NotificationDefaultResponse<NotificationSettlementReject>>> GetSettlementRejectNotification(DateTime date, Profile profile);
        Task<List<NotificationDefaultResponse<NotificationAdvancement>>> GetAdvancementNotification(DateTime date, Profile profile);
        Task<List<NotificationDefaultResponse<NotificationContract>>> GetContractNotification(DateTime date, Profile profile);
        Task<List<NotificationDefaultResponse<NotificationConsentWrapper>>> GetConsentNotification(DateTime date, Profile profile);
        Task<List<NotificationDefaultResponse<NotificationContract>>> GetNotificationProcessKey(string pkey, Profile profile);
        Task<List<NotificationDefaultResponse<NotificationContract>>> GetNotificationKey(string key, Profile profile);
    }
}
