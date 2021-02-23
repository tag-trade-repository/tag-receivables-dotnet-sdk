using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TagSDK.Extensions;
using TagSDK.Models.Enums;
using TagSDK.Models.Receivable.Notification;
using TagSDK.Utils;

namespace TagSDK.Services.Receivable.Notification
{
    public class NotificationService : BaseService, INotificationService
    {
        private const string _path = Constants.Constants.Notification.BasePath;
        private const string _pathKey = Constants.Constants.Notification.BasePathKey;
        private const string _pathProcessKey = Constants.Constants.Notification.BasePathProcessKey;

        public NotificationService(IServiceProvider serviceProvider, SDKOptions options) : base(serviceProvider, options) { }

        public async Task<List<NotificationDefaultResponse<NotificationAdvancement>>> GetAdvancementNotification(DateTime date, Profile profile)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_path}/?date={date:yyyy-MM-dd}&notificationType={EventType.ADVANCEMENT.GetDescription()}", DataFormat.Json);

            return await GetPipeline<List<NotificationDefaultResponse<NotificationAdvancement>>>().Execute(new Commands.RequestCommand<List<NotificationDefaultResponse<NotificationAdvancement>>>()
            {
                RestRequest = request,
                Profile = profile
            }).MapResponse();
        }

        public async Task<List<NotificationDefaultResponse<NotificationConsentWrapper>>> GetConsentNotification(DateTime date, Profile profile)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_path}/?date={date:yyyy-MM-dd}&notificationType={EventType.CONSENT.GetDescription()}", DataFormat.Json);

            return await GetPipeline<List<NotificationDefaultResponse<NotificationConsentWrapper>>>().Execute(new Commands.RequestCommand<List<NotificationDefaultResponse<NotificationConsentWrapper>>>()
            {
                RestRequest = request,
                Profile = profile
            }).MapResponse();
        }

        public async Task<List<NotificationDefaultResponse<NotificationContract>>> GetContractNotification(DateTime date, Profile profile)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_path}/?date={date:yyyy-MM-dd}&notificationType={EventType.CONTRACT.GetDescription()}", DataFormat.Json);

            return await GetPipeline<List<NotificationDefaultResponse<NotificationContract>>>().Execute(new Commands.RequestCommand<List<NotificationDefaultResponse<NotificationContract>>>()
            {
                RestRequest = request,
                Profile = profile
            }).MapResponse();
        }

        public async Task<List<NotificationDefaultResponse<NotificationSettlement>>> GetSettlementNotification(DateTime date, Profile profile)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_path}/?date={date:yyyy-MM-dd}&notificationType={EventType.SETTLEMENT.GetDescription()}", DataFormat.Json);

            return await GetPipeline<List<NotificationDefaultResponse<NotificationSettlement>>>().Execute(new Commands.RequestCommand<List<NotificationDefaultResponse<NotificationSettlement>>>()
            {
                RestRequest = request,
                Profile = profile
            }).MapResponse();
        }

        public async Task<List<NotificationDefaultResponse<NotificationSettlementReject>>> GetSettlementRejectNotification(DateTime date, Profile profile)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_path}/?date={date:yyyy-MM-dd}&notificationType={EventType.SETTLEMENTREJECT.GetDescription()}", DataFormat.Json);

            return await GetPipeline<List<NotificationDefaultResponse<NotificationSettlementReject>>>().Execute(new Commands.RequestCommand<List<NotificationDefaultResponse<NotificationSettlementReject>>>()
            {
                RestRequest = request,
                Profile = profile
            }).MapResponse();
        }

        public async Task<List<NotificationDefaultResponse<NotificationContract>>> GetNotificationKey(string key, Profile profile)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathKey}/{key}", DataFormat.Json);

            return await GetPipeline<List<NotificationDefaultResponse<NotificationContract>>>().Execute(new Commands.RequestCommand<List<NotificationDefaultResponse<NotificationContract>>>()
            {
                RestRequest = request,
                Profile = profile
            }).MapResponse();
        }

        public async Task<List<NotificationDefaultResponse<NotificationContract>>> GetNotificationProcessKey(string pkey, Profile profile)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathProcessKey}/{pkey}", DataFormat.Json);

            return await GetPipeline<List<NotificationDefaultResponse<NotificationContract>>>().Execute(new Commands.RequestCommand<List<NotificationDefaultResponse<NotificationContract>>>()
            {
                RestRequest = request,
                Profile = profile
            }).MapResponse();
        }
    }
}
