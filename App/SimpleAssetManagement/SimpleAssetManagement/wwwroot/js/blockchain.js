//Web3 = require("web3");

var web3;
var eth_account = "0xA6C763acc2f47E674273425e1500c05A4F8e607e";
var contract_address = "0xc3AF16a2d0837290f26Ba21A0b93118B495F8878";
var abi = [
	{
		"inputs": [
			{
				"internalType": "string",
				"name": "dateTimeStamp",
				"type": "string"
			},
			{
				"internalType": "string",
				"name": "user",
				"type": "string"
			},
			{
				"internalType": "string",
				"name": "change",
				"type": "string"
			},
			{
				"internalType": "string",
				"name": "oldValue",
				"type": "string"
			},
			{
				"internalType": "string",
				"name": "newValue",
				"type": "string"
			}
		],
		"name": "InsertLog",
		"outputs": [],
		"stateMutability": "nonpayable",
		"type": "function"
	},
	{
		"inputs": [],
		"stateMutability": "nonpayable",
		"type": "constructor"
	},
	{
		"inputs": [],
		"name": "AuditLogCount",
		"outputs": [
			{
				"internalType": "uint256",
				"name": "",
				"type": "uint256"
			}
		],
		"stateMutability": "view",
		"type": "function"
	},
	{
		"inputs": [
			{
				"internalType": "uint256",
				"name": "",
				"type": "uint256"
			}
		],
		"name": "AuditLogs",
		"outputs": [
			{
				"internalType": "string",
				"name": "_dateTimeStamp",
				"type": "string"
			},
			{
				"internalType": "string",
				"name": "_user",
				"type": "string"
			},
			{
				"internalType": "string",
				"name": "_change",
				"type": "string"
			},
			{
				"internalType": "string",
				"name": "_oldValue",
				"type": "string"
			},
			{
				"internalType": "string",
				"name": "_newValue",
				"type": "string"
			}
		],
		"stateMutability": "view",
		"type": "function"
	},
	{
		"inputs": [],
		"name": "FetchLogCount",
		"outputs": [
			{
				"internalType": "uint256",
				"name": "count",
				"type": "uint256"
			}
		],
		"stateMutability": "view",
		"type": "function"
	},
	{
		"inputs": [
			{
				"internalType": "uint256",
				"name": "index",
				"type": "uint256"
			}
		],
		"name": "FetchLogs",
		"outputs": [
			{
				"internalType": "string",
				"name": "datetimestamp",
				"type": "string"
			},
			{
				"internalType": "string",
				"name": "user",
				"type": "string"
			},
			{
				"internalType": "string",
				"name": "change",
				"type": "string"
			},
			{
				"internalType": "string",
				"name": "oldvalue",
				"type": "string"
			},
			{
				"internalType": "string",
				"name": "newvalue",
				"type": "string"
			}
		],
		"stateMutability": "view",
		"type": "function"
	}
]


web3 = new Web3(new Web3.providers.HttpProvider("http://127.0.0.1:8545"));

var accounts = undefined;
var new_contract = undefined;

web3.eth.getAccounts().then(function (result) {
	console.log(result);
	accounts = result;
	web3.eth.defaultAccount = accounts[0];

	var default_address = {
		from: eth_account, // default from address
		gasLimit: web3.utils.toHex(1000000),
		gasPrice: web3.utils.toHex(web3.utils.toWei('10', 'gwei')) // '20000000000' // default gas price in wei, 20 gwei in this case
	};
	new_contract = new web3.eth.Contract(abi, contract_address, default_address);

});

async function FetchLogs(userid)
{
	var logresult = await new_contract.methods.FetchLogs(userid).call().then(
		function (result) {
			console.log(result);
			return result;
		}
	);

	return logresult;
}

async function FetchLogCount() {
	var count = await new_contract.methods.FetchLogCount().call().then(
		function (result) {
			return result;
		}
	);

	return count;
}

async function AddLog(datetime, user, change, oldvalue, newvalue) {
	await new_contract.methods.InsertLog(datetime, user, change, oldvalue, newvalue).send();
}
