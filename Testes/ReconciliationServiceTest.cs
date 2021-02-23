using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TagSDK.Models.Receivable.Reconciliation;
using TagSDK.Services.Receivable.Reconciliation;

namespace Testes
{
    [TestClass]
    [Ignore]
    public class ReconciliationServiceTest : BaseTest
    {
        private readonly IReconciliationService _rService = null;
        public ReconciliationServiceTest()
        {
            Init();
            _rService = Fac.ReconciliationService;
        }

        [TestMethod]
        public async Task InsertReconciliation()
        {
            var rInput = new ReconciliationRequest
            {
                ReconciliationDate = DateTime.Now
            };
            var result = await _rService.InsertConciliation(rInput);
            Print(result);
        }

        [TestMethod]
        public async Task GetReconciliationWithKey()
        {
            var result = await _rService.GetReconciliationWithKey("42ea18fd-a5d9-4bf9-a9c9-bc0515edb615");
            Print(result);
        }

        [TestMethod]
        public async Task ConfirmReconciliation()
        {
            var rInput = new ReconciliationRequest
            {
                ReconciliationDate = DateTime.Now
            };

            var response = await _rService.InsertConciliation(rInput);

            var result = await _rService.ConfirmReconciliation(response.ReconciliationKey, new ReconciliationConfirmationRequest { ReconciliationKey = response.ReconciliationKey });

            Print(result);
        }


    }
}
