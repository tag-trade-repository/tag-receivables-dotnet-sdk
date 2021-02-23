using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TagSDK.Models.Enums;
using TagSDK.Models.Receivable.Notification;
using TagSDK.Services.Receivable.Notification;

namespace Testes
{
    [TestClass]
    [Ignore]
    public class NotificationServiceTest : BaseTest
    {
        private readonly DateTime _date = DateTime.Parse("2020-12-10");
        private readonly INotificationService _nS;
        private readonly Profile _profile = Profile.CREDITOR;

        public NotificationServiceTest()
        {
            Init();
            _nS = Fac.NotificationService;
        }

        [TestMethod]
        public async Task ListNotificationSettlementTest()
        {
            var result = await _nS.GetSettlementNotification(_date, _profile);

            Print(result);
        }

        [TestMethod]
        public async Task ListNotificationSettlementRejectTest()
        {
            var result = await _nS.GetSettlementRejectNotification(DateTime.Parse("2020-12-10"), _profile);

            Print(result);
        }

        [TestMethod]
        [Ignore]
        public async Task ListNotificationAdvancementTest()
        {
            var result = await _nS.GetAdvancementNotification(_date, _profile);

            Print(result);
        }

        [TestMethod]
        public async Task ListContractNotificationTest()
        {
            var result = await _nS.GetContractNotification(DateTime.Parse("2020-12-09"), _profile);

            Print(result);
        }

        [TestMethod]
        public async Task ListNotificationConsentTest()
        {
            var result = await _nS.GetConsentNotification(_date, _profile);

            Print(result);
        }

        [TestMethod]
        public async Task ListNotificationProcessKeyTest()
        {
            var result = await _nS.GetNotificationKey("2c76b0f6-513a-4c07-a17a-d37b9b6484f9", _profile);

            Print(result);
        }

        [TestMethod]
        public async Task ListNotificationKeyTest()
        {
            var result = await _nS.GetNotificationProcessKey("826392f6-d199-4e2c-b557-f4ae3fb871b3", _profile);

            Print(result);
        }
    }
}
