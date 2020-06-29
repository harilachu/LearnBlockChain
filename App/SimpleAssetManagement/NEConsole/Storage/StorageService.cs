using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Solidity_Project.Contracts.Storage.ContractDefinition;

namespace Solidity_Project.Contracts.Storage
{
    public partial class StorageService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, StorageDeployment storageDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<StorageDeployment>().SendRequestAndWaitForReceiptAsync(storageDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, StorageDeployment storageDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<StorageDeployment>().SendRequestAsync(storageDeployment);
        }

        public static async Task<StorageService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, StorageDeployment storageDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, storageDeployment, cancellationTokenSource);
            return new StorageService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public StorageService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> RetreiveQueryAsync(RetreiveFunction retreiveFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RetreiveFunction, BigInteger>(retreiveFunction, blockParameter);
        }

        
        public Task<BigInteger> RetreiveQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RetreiveFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> StoreRequestAsync(StoreFunction storeFunction)
        {
             return ContractHandler.SendRequestAsync(storeFunction);
        }

        public Task<TransactionReceipt> StoreRequestAndWaitForReceiptAsync(StoreFunction storeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(storeFunction, cancellationToken);
        }

        public Task<string> StoreRequestAsync(BigInteger num)
        {
            var storeFunction = new StoreFunction();
                storeFunction.Num = num;
            
             return ContractHandler.SendRequestAsync(storeFunction);
        }

        public Task<TransactionReceipt> StoreRequestAndWaitForReceiptAsync(BigInteger num, CancellationTokenSource cancellationToken = null)
        {
            var storeFunction = new StoreFunction();
                storeFunction.Num = num;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(storeFunction, cancellationToken);
        }
    }
}
