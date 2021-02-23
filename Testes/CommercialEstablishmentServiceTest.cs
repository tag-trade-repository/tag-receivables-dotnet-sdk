using Microsoft.VisualStudio.TestTools.UnitTesting;

using TagSDK.Models;
using TagSDK.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using TagSDK.Models.Request;
using TagSDK.Models.Enums;
using TagSDK.Models.Customer;

namespace Testes
{
    [TestClass]
    [Ignore]
    public class CommercialEstablishmentServiceTest : BaseTest
    {
        private readonly ICommercialEstablishmentService _cEstablishmentService;
        public CommercialEstablishmentServiceTest()
        {
            Init();
            _cEstablishmentService = Fac.CommercialEstablishmentService;
        }

        [TestMethod]
        public async Task InsertCommercialEstablishmentTest()
        {
            var paymentSchemes = new List<string>
            {
                "VCC",
                "MCC"
            };

            var cnpj = GeraCNPJ();

            var bankAccount = new BankAccount
            {
                Branch = "1144",
                Account = "13341",
                AccountDigit = "X5",
                AccountType = BankAccountType.CC,
                Ispb = "12345678",
                DocumentType = DocumentType.CNPJ,
                DocumentNumber = cnpj
            };

            var cmEstab = new CommercialEstablishment()
            {
                DocumentType = DocumentType.CNPJ,
                DocumentNumber = cnpj,
                PaymentSchemes = paymentSchemes,
                BankAccount = bankAccount
            };

            var commercialEstablishments = new List<CommercialEstablishment>
            {
                cmEstab
            };

            var cmEstabReq = new CommercialEstablishmentRequest()
            {
                CommercialEstablishments = commercialEstablishments
            };

            var result = await _cEstablishmentService.RegisterCommercialEstablishments(cmEstabReq);

            Print(result);
        }

        [TestMethod]
        [Ignore]
        public async Task UpdateCommercialEstablishmentTest()
        {
            var paymentSchemes = new List<string>
            {
                "VCC"
            };
            var cnpj = "54762153000103";
            var bankAccount = new BankAccount
            {
                Branch = "1144",
                Account = "13341",
                AccountDigit = "X5",
                AccountType = BankAccountType.CC,
                Ispb = "12345678",
                DocumentType = DocumentType.CNPJ,
                DocumentNumber = cnpj
            };
            var cmEstab = new CommercialEstablishmentUpdateInput
            {
                PaymentSchemes = (paymentSchemes),
                BankAccount = (bankAccount),
                Enabled = (true)
            };
            var cmEstabReq = new CommercialEstablishmentUpdateRequest
            {
                CommercialEstablishment = (cmEstab)
            };

            var result = await _cEstablishmentService.UpdateCommercialEstablishments(cnpj, cmEstabReq);

            Print(result);
        }

        [TestMethod]
        public async Task ListCommercialEstablishmentWithPaginationTest()
        {
            var pag = new Pagination
            {
                Limit = 1,
                Page = 2
            };
            var result = await _cEstablishmentService.GetCommercialEstablishmentsWithPagination(pag);

            Print(result);
        }

        [TestMethod]
        public async Task ListCommercialEstablishmentWithDocumentNumberTest()
        {
            var result = await _cEstablishmentService.GetCommercialEstablishmentsWithDocumentNumber("62661584000101");

            Print(result);
        }
    }
}
