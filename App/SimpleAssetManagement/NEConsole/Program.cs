using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.Contracts;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;
using Nethereum.HdWallet;
using Nethereum.Signer;
using Solidity_Project.Contracts.Storage;
using Solidity_Project.Contracts.Storage.ContractDefinition;


namespace NEConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAccountBalance().Wait();
            //DeployNewContract().Wait();
            //UseExistingContract().Wait();
            SigningMessage().Wait();

            Console.ReadLine();
        }

        static async Task GetAccountBalance()
        {
            //var web3 = new Web3("https://mainnet.infura.io/v3/7238211010344719ad14a89db874158c");
            var web3 = new Web3("http://127.0.0.1:8502");
            var balance = await web3.Eth.GetBalance.SendRequestAsync("0xd3c69E4902ead5D1c68A6f491B7d48a2AcA1EEE8");
            Console.WriteLine($"Balance in Wei: {balance.Value}");

            //var etherAmount = Web3.Convert.FromWei(balance.Value);
            //Console.WriteLine($"Balance in Ether: {etherAmount}");

            //string Words = "magic good lend attend cat february embody blur invest table buyer reduce";
            //string Password1 = "Lachuhari-123";
            //var wallet1 = new Wallet(Words, Password1);
            //for (int i = 0; i < 10; i++)
            //{
            //    var account = wallet1.GetAccount(i);
            //    Console.WriteLine("Account index : " + i + " - Address : " + account.Address + " - Private key : " + account.PrivateKey );
            //    var acbalance = await web3.Eth.GetBalance.SendRequestAsync(account.Address);
            //    Console.WriteLine($"Account balance: {acbalance.Value}");
            //}

            //var accounts = await web3.Personal.ListAccounts.SendRequestAsync(15162);

        }

        static async Task DeployNewContract()
        {
            try
            {
                // Setup
                var url = "http://127.0.0.1:8502";
                var account = new Account("0x82E41304BB1E81A848BFC705CB06FEDB0554A9906744EB225820A3CF3CF40A79");
                var web3 = new Web3(account, url);
                
                CancellationTokenSource cancellation = new CancellationTokenSource(10000);
                var service = await StorageService.DeployContractAndGetServiceAsync(web3, new StorageDeployment(), cancellation);
                Console.WriteLine($"Contract Address: {service.ContractHandler.ContractAddress}");
                Console.WriteLine("");

                // Get the stored value
                var currentStoredValue = await service.RetreiveQueryAsync();
                Console.WriteLine($"Contract has value stored: {currentStoredValue}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static async Task UseExistingContract()
        {
            try
            {
                // Setup
                var url = "http://127.0.0.1:8502";
                var account = new Account("0x82E41304BB1E81A848BFC705CB06FEDB0554A9906744EB225820A3CF3CF40A79");
                var web3 = new Web3(account, url);
                // An already-deployed SimpleStorage.sol contract on Rinkeby:
                var contractAddress = "0xcf5636b4c062262b52e00455b04b1c89d3c04d11";
                var service = new StorageService(web3, contractAddress);

                var receipt = await service.StoreRequestAndWaitForReceiptAsync(new BigInteger(1234));
                Console.WriteLine($"Set Value Receipt: {receipt.Status}");
                Console.WriteLine($"BlockNumber: {receipt.BlockNumber}");

                // Get the stored value
                var currentStoredValue = await service.RetreiveQueryAsync();
                Console.WriteLine($"Contract has value stored: {currentStoredValue}");

                //pwvar accounts = await web3.Eth.Accounts.SendRequestAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static async Task SigningMessage()
        {
            try
            {
                // Setup
                var url = "http://127.0.0.1:8502";
                var privateKey = "0x82E41304BB1E81A848BFC705CB06FEDB0554A9906744EB225820A3CF3CF40A79";
                var account = new Account(privateKey);
                var web3 = new Web3(account, url);
                // An already-deployed SimpleStorage.sol contract on Rinkeby:
                var contractAddress = "0xcf5636b4c062262b52e00455b04b1c89d3c04d11";
                var service = new StorageService(web3, contractAddress);
                
                //Signing
                var msg1 = "wee test message 18/09/2017 02:55PM";
                var signer1 = new EthereumMessageSigner();
                var ethKey = new EthECKey(privateKey);

                var signature1 = signer1.EncodeUTF8AndSign(msg1, ethKey);
                Console.WriteLine($"Signature: {signature1}");
                Console.WriteLine($"Public address from Key: {ethKey.GetPublicAddress()}");
                //get accounts addresses
                var accounts = await web3.Eth.Accounts.SendRequestAsync();
                
                Console.WriteLine($"Public address from eth Accounts: {accounts[0]}");
                //Recover signature
                var addressRec1 = signer1.EncodeUTF8AndEcRecover(msg1, signature1);
                Console.WriteLine($"Recovered address from signature: {addressRec1}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}

