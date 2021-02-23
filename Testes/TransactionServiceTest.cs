using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TagSDK.Models.Receivable.Transaction;
using TagSDK.Services.Receivable.Transaction;

namespace Testes
{
    [TestClass]
    [Ignore]
    public class TransactionServiceTest : BaseTest
    {

        private readonly ITransactionService _srv;
        public TransactionServiceTest()
        {
            Init();
            _srv = Fac.TransactionService;
        }

        [TestMethod]
        public async Task CreateTransactedUnitsReceivables()
        {
            var item = new Transaction
            {
                Identifier = "0125048520200513",
                TransactionDate = DateTime.Parse("2022-05-15"),
                Amount = (500000),
                Reference = ("TR-488"),
                DueDate = DateTime.Parse
                ("2020-06-15")
            };
            var itemList = new List<Transaction>
            {
                item
            };
            var inputItem = new TransactionReceivable
            {
                Key = ("e9773677dcf7c64e8d30ba551be3c436"),
                Transactions = (itemList)
            };
            var inputItemList = new List<TransactionReceivable>
            {
                inputItem
            };
            var input = new TransactionRequest
            {
                Receivables = inputItemList
            };
            var result = await _srv.CreateTransactedUnitsReceivables(input);

            Print(result);
        }

        [TestMethod]
        [Ignore]
        public async Task GetTransactionTest()
        {
            var result = await _srv.GetTransaction("e9773677dcf7c64e8d30ba551be3c436");

            Print(result);
        }

        [TestMethod]
        public async Task RectifyTransactedUnitsReceivables()
        {
            var item = new Transaction
            {
                Identifier = "0125048520200513",
                TransactionDate = DateTime.Parse("2022-05-15"),
                Amount = 500000,
                Reference = "TR-488",
                DueDate = DateTime.Parse("2020-06-15")
            };
            var itemList = new List<Transaction>
            {
                item
            };
            var inputItem = new TransactionReceivable
            {
                Key = "e9773677dcf7c64e8d30ba551be3c436",
                Transactions = itemList
            };
            var inputItemList = new List<TransactionReceivable>
            {
                inputItem
            };
            var input = new TransactionRequest
            {
                Receivables = inputItemList
            };
            var result = await _srv.RectifyTransactedUnitsReceivables(input);

            Print(result);
        }
    }
}
