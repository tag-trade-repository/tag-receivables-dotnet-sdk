using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TagSDK.Models.Receivable.Position;
using TagSDK.Services.Receivable.Position;

namespace Testes
{
    [TestClass]
    [Ignore]
    public class PositionServiceTest : BaseTest
    {
        private readonly IPositionService _receivablePositionService;
        public PositionServiceTest()
        {
            Init();
            _receivablePositionService = Fac.PositionService;
        }

        [TestMethod]
        public async Task AgendaPositionWithKeyTest()
        {
            var result = await _receivablePositionService.GetPositionsWithKey("48ad40ab594434f916e497da745efa0c");

            Print(result);
        }

        [TestMethod]
        public async Task AgendaPositionWithReferenceTest()
        {
            var result = await _receivablePositionService.GetPositionsWithReference("UR_450");

            Print(result);
        }

        [TestMethod]
        public async Task AgendaPositionWithProcessReferenceTest()
        {
            var result = await _receivablePositionService.GetPositionsWithProcessReference("PR_550");

            Print(result);
        }

        [TestMethod]
        public async Task AgendaPositionWithOriginalAssetHolder()
        {
            var rPositionParams = new PositionQueryFilter
            {
                PaymentScheme = "VCC",
                InitialExpectedSettlementDate = DateTime.Parse("2020-12-01"),

                FinalExpectedSettlementDate = DateTime.Parse("2020-12-31")

            };
            var result = await _receivablePositionService.GetPositionsWithOriginalAssetHolder("61821451000184", rPositionParams);

            Print(result);
        }

        [TestMethod]
        public async Task AgendaPositionWithAssetHolder()
        {
            var rPositionParams = new PositionQueryFilter
            {
                PaymentScheme = "VCC",
                InitialExpectedSettlementDate = DateTime.Parse("2020-12-01"),

                FinalExpectedSettlementDate = DateTime.Parse("2020-12-31")

            };

            var result = await _receivablePositionService.GetPositionsWithAssetHolder("61821451000184", rPositionParams);

            Print(result);

        }
    }
}
