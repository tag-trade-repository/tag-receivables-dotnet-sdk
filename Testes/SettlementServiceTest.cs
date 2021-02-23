using Microsoft.VisualStudio.TestTools.UnitTesting;

using TagSDK.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TagSDK.Models.Receivable.Settlement;
using TagSDK.Models.Request;
using TagSDK.Models.Enums;
using TagSDK.Services.Receivable.Settlement;

namespace Testes
{
    [TestClass]
    [Ignore]
    public class SettlementServiceTest : BaseTest
    {
        private readonly ISettlementService _settlementService = null;

        public SettlementServiceTest()
        {
            Init();
            _settlementService = Fac.SettlementService;
        }

        [TestMethod]
        public async Task CallSettlementVanillaTest()
        {

            var bankAccount = new BankAccount
            {
                Branch = "1144",
                Account = "13341",
                AccountDigit = "X5",
                AccountType = BankAccountType.CC,
                Ispb = "12345678",
                DocumentType = DocumentType.CNPJ,
                DocumentNumber = "51914361000184"
            };
            var settlementItem = new Settlement
            {
                Reference = "ST-01",
                AssetHolderDocumentType = DocumentType.CNPJ,
                AssetHolder = "51914361000184",
                SettlementDate = DateTime.Parse("2020-12-16"),
                Amount = 50000L,
                SettlementObligationDate = DateTime.Parse("2020-12-16"),
                PaymentScheme = "VCC",
                BankAccount = bankAccount
            };
            var settlements = new List<Settlement>
            {
                settlementItem
            };
            var receivableSettlementInput = new SettlementRequest
            {
                Settlements = settlements
            };
            var result = await _settlementService.ReportSettlement(receivableSettlementInput);

            Print(result);
        }

        [TestMethod]
        public async Task RejectSettlementVanillaTest()
        {
            var receivableSettlementItem = new SettlementReject
            {
                Key = ("df78ff30-1825-4922-b26f-856f28652c1e"),
                ReasonDetails = ("Liquidacao nao executada.")
            };
            var settlements = new List<SettlementReject>
            {
                receivableSettlementItem
            };
            var receivableSettlementInput = new SettlementRejectRequest { Settlements = settlements };
            var result = await _settlementService.RejectSettlement(receivableSettlementInput);

            Print(result);
        }

        [TestMethod]
        public async Task QueryByKey()
        {
            var result = await _settlementService.GetSettlementByKey("df78ff30-1825-4922-b26f-856f28652c1e");

            Print(result);
        }

        [TestMethod]
        public async Task QueryByProcessKey()
        {
            var pag = new Pagination { Page = 1, Limit = 100 };
            var result = await _settlementService.GetSettlementByProcessKey("dad71f6e-3de6-4dcd-bb54-abe08d944ae8", pag);

            Print(result);
        }

        [TestMethod]
        public async Task QueryByReference()
        {
            var pag = new Pagination { Page = 1, Limit = 100 };
            var result = await _settlementService.GetSettlementByReference("L_1875", pag);

            Print(result);
        }

        [TestMethod]
        public async Task CallSettlementWithParamsVanillaTest()
        {
            var settlementParams = new SettlementQueryFilter
            {
                StartSettlementDate = DateTime.Parse("2020-01-19"),
                EndSettlementDate = DateTime.Now,
                PaymentScheme = ("VCC"),
                AssetHolder = ("51914361000184")
            };
            var pag = new Pagination { Page = 1, Limit = 100 };
            var result = await _settlementService.GetSettlementWithParams(settlementParams, pag);

            Print(result);
        }
    }
}
