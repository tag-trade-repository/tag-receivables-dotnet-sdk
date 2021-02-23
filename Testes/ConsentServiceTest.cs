using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TagSDK.Models.Receivable.Consent;
using TagSDK.Models.Enums;
using TagSDK.Services.Receivable.Consent;

namespace Testes
{
    [TestClass]
    [Ignore]
    public class ConsentServiceTest : BaseTest
    {
        private readonly IConsentService _cService = null;
        private readonly Profile _profile = Profile.ACQUIRER;
        public ConsentServiceTest()
        {
            Init();
            _cService = Fac.ConsentService;
        }

        [TestMethod]
        public async Task InsertOptInsTest()
        {
            var optIns = new List<Consent>();
            var optIn = new Consent
            {
                Beneficiary = "63878277000131",
                PaymentScheme = "VCC",
                Acquirer = "58094131000165",
                AssetHolder = "86501627000141",
                SignatureDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
            optIns.Add(optIn);

            var consentRequest = new ConsentRequest
            {
                OptIns = (optIns)
            };

            var result = await _cService.InsertConsents(consentRequest, _profile);

            Print(result);
        }

        [TestMethod]
        public async Task RejectOptInsTest()
        {
            var optIns = new List<ConsentReject>();
            var optRejInput = new ConsentRejectRequest();
            var optRejItem = new ConsentReject
            {
                Reason = "Razão de teste",
                Key = "4e00e0e0-74e0-4997-8f01-e3f546d1e791"
            };
            optIns.Add(optRejItem);
            optRejInput.OptIns = optIns;
            var result = await _cService.RejectOptIn(optRejInput, _profile);

            Print(result);
        }

        [TestMethod]
        public async Task PatchOptOutTest()
        {
            var result = await _cService.PatchOptOut("98487a34-cf87-4f78-8f85-eebf50354c6b");

            Print(result);
        }

        [TestMethod]
        public async Task OptInChangeValidity()
        {
            var optInVChangeInput = new ConsentValidityChangeRequest
            {
                StartDate = DateTime.Parse("2020-12-16"),
                EndDate = DateTime.Parse("2020-12-21")
            };
            var result = await _cService.ChangeOptInValidityDate("98487a34-cf87-4f78-8f85-eebf50354c6b", optInVChangeInput, _profile);

            Print(result);
        }

        [TestMethod]
        public async Task GetOptInWithKey()
        {
            var result = await _cService.GetOptInWithKey("98487a34-cf87-4f78-8f85-eebf50354c6b");

            Print(result);
        }

        [TestMethod]
        public async Task GetOptInWithParams()
        {
            var consentQueryFilter = new ConsentQueryFilter()
            {
                Acquirer = "58094131000165",
                Beneficiary = "63878277000131",
                PaymentScheme = "VCC",
                InitialDate = DateTime.Parse("2020-12-17"),
                FinalDate = DateTime.Parse("2020-12-17"),
                AssetHolder = "86501627000141"
            };

            var result = await _cService.GetOptInWithParams(consentQueryFilter);

            Print(result);
        }
    }
}
