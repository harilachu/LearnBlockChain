//Web3 = require("web3");

var web3;
var eth_account = "0xEB7d1b55a9FC16DBb6B52fAb1cFb7AaAc2C6B405";
var contract_address = "0x0bC8B5D4580C869908da761DFc3f8c35FF7AB58C";
var abi = [
	{
		"constant": false,
		"inputs": [
			{
				"name": "userid",
				"type": "uint16"
			},
			{
				"name": "id",
				"type": "uint256"
			},
			{
				"name": "dateTimeStamp",
				"type": "string"
			},
			{
				"name": "user",
				"type": "string"
			},
			{
				"name": "change",
				"type": "string"
			},
			{
				"name": "oldValue",
				"type": "string"
			},
			{
				"name": "newValue",
				"type": "string"
			}
		],
		"name": "InsertLog",
		"outputs": [],
		"payable": false,
		"stateMutability": "nonpayable",
		"type": "function"
	},
	{
		"inputs": [],
		"payable": false,
		"stateMutability": "nonpayable",
		"type": "constructor"
	},
	{
		"constant": true,
		"inputs": [
			{
				"name": "userid",
				"type": "uint16"
			}
		],
		"name": "FetchLogs",
		"outputs": [
			{
				"name": "id",
				"type": "uint256"
			},
			{
				"name": "dateTimeStamp",
				"type": "string"
			},
			{
				"name": "user",
				"type": "string"
			},
			{
				"name": "change",
				"type": "string"
			},
			{
				"name": "oldValue",
				"type": "string"
			},
			{
				"name": "newValue",
				"type": "string"
			}
		],
		"payable": false,
		"stateMutability": "view",
		"type": "function"
	},
	{
		"constant": true,
		"inputs": [
			{
				"name": "",
				"type": "uint16"
			}
		],
		"name": "Logs",
		"outputs": [
			{
				"name": "_id",
				"type": "uint256"
			},
			{
				"name": "_dateTimeStamp",
				"type": "string"
			},
			{
				"name": "_user",
				"type": "string"
			},
			{
				"name": "_change",
				"type": "string"
			},
			{
				"name": "_oldValue",
				"type": "string"
			},
			{
				"name": "_newValue",
				"type": "string"
			}
		],
		"payable": false,
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
