using Microsoft.VisualStudio.TestTools.UnitTesting;

using TagSDK.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TagSDK.Models.Receivable.Register;
using TagSDK.Models.Enums;
using TagSDK.Services.Receivable.Register;

namespace Testes
{
    [TestClass]
    [Ignore]
    public class ServiceTest : BaseTest
    {
        private readonly IReceivableService _tService = null;

        public ServiceTest()
        {
            Init();
            _tService = Fac.ReceivableService;
        }

        [TestMethod]
        public async Task InsertReceivableTest()
        {
            var bankAccount = new BankAccount
            {
                Branch = "1144",
                Account = "13341",
                AccountDigit = "X5",
                AccountType = BankAccountType.CC,
                Ispb = "12345678",
                DocumentType = DocumentType.CNPJ,
                DocumentNumber = "34144310000100"
            };

            var settlement = new ReceivableSettlement()
            {
                Reference = "L_1875",
                AssetHolder = "34144310000100",
                AssetHolderDocumentType = DocumentType.CPF,
                SettlementDate = DateTime.Parse("2020-02-02"),
                SettlementObligationDate = DateTime.Parse("2021-11-01"),
                Amount = 100.00M,
                BankAccount = bankAccount
            };

            var settlements = new List<ReceivableSettlement>
            {
                settlement
            };

            var receivable = new Receivable()
            {
                Reference = "UR_450",
                DueDate = DateTime.Now.AddDays(1),
                PaymentScheme = "VCC",
                OriginalAssetHolderDocumentType = DocumentType.CPF,
                OriginalAssetHolder = "34144310000100",
                Amount = 50000.00M,
                PrePaidAmount = 0,
                BankAccount = bankAccount,
                Settlements = settlements
            };

            var processReference = "PR_550";
            var receivables = new List<Receivable>
            {
                receivable
            };
            var rI = new ReceivableRequest
            {
                ProcessReference = processReference,
                Receivables = receivables
            };

            var result = await _tService.RegisterReceivable(rI);

            Print(result);
        }
    }
}
