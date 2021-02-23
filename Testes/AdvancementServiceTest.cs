using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TagSDK.Models.Receivable.Advancement;
using TagSDK.Models.Enums;
using TagSDK.Services.Receivable.Advancement;

namespace Testes
{
    [TestClass]
    [Ignore]
    public class AdvancementServiceTest : BaseTest
    {
        private readonly IAdvancementService _advacementService;
        public AdvancementServiceTest()
        {
            Init();
            _advacementService = Fac.AdvancementService;
        }

        [TestMethod]
        public async Task InsertAdvancementVanillaTest()
        {
            var adReceivable = new AdvancedReceivable
            {
                AdvancedAmount = 100L,
                PaymentScheme = "VCC",
                SettlementObligationDate = DateTime.Now
            };
            var adReceivables = new List<AdvancedReceivable>
            {
                adReceivable
            };
            var adItem = new Advancement
            {
                AssetHolderDocumentType = DocumentType.CNPJ,
                AssetHolder = "74190072000185",
                OperationValue = 100L,
                OperationExpectedSettlementDate = DateTime.Now,
                Reference = "RF_01",
                AdvancedReceivables = adReceivables
            };
            var adItems = new List<Advancement>
            {
                adItem
            };
            var adInput = new AdvancementRequest
            {
                Advancements = adItems
            };
            var result = await _advacementService.InsertAdvancements(adInput);

            Print(result);
        }
    }
}
