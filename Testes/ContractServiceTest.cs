using Microsoft.VisualStudio.TestTools.UnitTesting;

using TagSDK.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TagSDK.Models.Receivable.Contract;
using TagSDK.Models.Request;
using TagSDK.Models.Enums;
using TagSDK.Services.Receivable.Contract;

namespace Testes
{
    [TestClass]
    [Ignore]
    public class ContractServiceTest : BaseTest
    {
        private readonly IContractService _contractService = null;
        public ContractServiceTest()
        {
            Init();
            _contractService = Fac.ContractService;
        }

        [TestMethod]
        public async Task InsertContract()
        {
            var bankAccount = new BankAccount
            {
                Branch = "1144",
                Account = "13341",
                AccountDigit = "X5",
                AccountType = BankAccountType.CC,
                Ispb = "12345678",
                DocumentType = DocumentType.CNPJ,
                DocumentNumber = "39624514000153"
            };
            var ctEspecification = new ContractSpecification
            {
                ExpectedSettlementDate = DateTime.Parse("2021-01-01T05:00:00Z"),
                OriginalAssetHolderDocumentType = DocumentType.CNPJ,
                OriginalAssetHolder = "39624514000153",
                ReceivableDebtor = "74190072000185",
                PaymentScheme = "VCC",
                EffectValue = 100L
            };
            var ctEspecifications = new List<ContractSpecification>
            {
                ctEspecification
            };
            var ctItem = new Contract
            {
                Reference = "CT_01",
                ContractDueDate = DateTime.Parse("2021-01-01T05:00:00Z"),
                AssetHolderDocumentType = DocumentType.CNPJ,
                AssetHolder = "39624514000153",
                ContractUniqueIdentifier = "CT_01",
                SignatureDate = DateTime.Parse("2021-01-01T05:00:00Z"),
                EffectType = EffectType.WARRANTY,
                WarrantyType = WarrantyType.FIDUCIARY,
                WarrantyAmount = 100L,
                BalanceDue = 100L,
                DivisionMethod = DivisionMethodType.FIXEDAMOUNT,
                EffectStrategy = EffectStrategy.SPECIFIC,
                PercentageValue = 10,
                BankAccount = bankAccount,
                ContractSpecifications = ctEspecifications
            };
            var ctItems = new List<Contract>
            {
                ctItem
            };
            var contractInput = new ContractRequest
            {
                Contracts = ctItems
            };
            var result = await _contractService.InsertContract(contractInput);

            Print(result);
        }

        [TestMethod]
        public async Task ListContractsByReference()
        {
            var page = new Pagination()
            {
                Page = 1,
                Limit = 10
            };
            var result = await _contractService.ListContractsByReference("CT_01", page);

            Print(result);
        }

        [TestMethod]
        public async Task ListContractsByKey()
        {
            var result = await _contractService.ListContractsByKey("dda6c698-705d-49b5-a84c-c0a2d605b77c");

            Print(result);
        }

        [TestMethod]
        public async Task ListContractsByProcessKey()
        {

            var page = new Pagination()
            {
                Page = 1,
                Limit = 10
            };

            var result = await _contractService.ListContractsByProcessKey("7c4f2552-4dcf-4320-a460-8fd6fd8ff09b", page);

            Print(result);
        }

        [TestMethod]
        public async Task ListContractsWithParams()
        {
            var cInput = new ContractQueryFilter
            {
                StartContractDueDate = DateTime.Parse("2020-01-01"),
                EndContractDueDate = DateTime.Parse("2020-12-31"),
                AssetHolder = "61821451000184"
            };
            // cInput.StartSignatureDate = null;
            // cInput.endSignatureDate = DateTime.Parse("2021-01-01T05:00:00Z");
            // cInput.startCreatedAt = DateTime.Parse("2021-01-01T05:00:00Z");
            // cInput.endCreatedAt = DateTime.Parse("2021-01-01T05:00:00Z");

            var page = new Pagination()
            {
                Page = 1,
                Limit = 10
            };


            var result = await _contractService.ListContractsWithParams(cInput, page);

            Print(result);
        }

        [TestMethod]
        [Ignore]
        public async Task GetContractHistoryTest()
        {
            var result = await _contractService.GetContractHistoryWithKey("CT_01");
            Print(result);
        }
    }
}
