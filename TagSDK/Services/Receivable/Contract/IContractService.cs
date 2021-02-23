using System.Threading.Tasks;
using TagSDK.Models.Receivable.Contract;
using TagSDK.Models.Request;

namespace TagSDK.Services.Receivable.Contract
{
    public interface IContractService
    {
        Task<ContractResponse> InsertContract(ContractRequest contract);
        Task<ContractPaginatedQueryResponse> ListContractsByReference(string reference, Pagination page);
        Task<ContractPaginatedQueryResponse> ListContractsByKey(string key);
        Task<ContractPaginatedQueryResponse> ListContractsByProcessKey(string processKey, Pagination page);
        Task<ContractPaginatedQueryResponse> ListContractsWithParams(ContractQueryFilter queryParams, Pagination page);
        Task<ContractHistoryResponse> GetContractHistoryWithKey(string key);
    }
}

