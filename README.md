# LearnBlockChain

![Alt text](/eth2.jpg?raw=true "Title")

The <b>Contracts</b> folder contains some examples of contracts written using solidity programming language.
The <b>Apps</b> folder contains a sample asset management web application, written in <b>ASP.Net Core 3.1 Blazor Webserver</b> and uses <b>Web3js</b> to communicate with the deployed Smart contract <b>SimpleAssetAuditLogs.sol</b>. It also uses <b>Entity framework core</b> to store the Asset data.

To run the Web app,
1. Clone the repository.
2. Open solution in VS2019.
3. Run the database migration script to create a local database and migrate to the latest corresponding entities.
4. Download nuget packages<br/>
<b>Ganache CLI:</b> To install globally run <code>Npm i -g ganache-cli</code><br/>
<b>Web3js:</b> Since Web3js distributions files are already added to the APP, it is not necessary to download the package again. <br/> If you wish to use latest Web3js package code, then use the command <code>Npm i --save ethereum/web3.js</code> to download the package and follow the instructions from https://github.com/ethereum/web3.js/ to build and run. <br/>
If not you can also donwload the latest Dist file from the above mentioned Web3 github page and use.<br/>
6. Run from cmd prompt <code>ganache</code>. This will start a local ethereum in your PC and will provide you a list of accounts to deploy and test your contract.
7. Install Metamask chrome extension from https://metamask.io/. Follow its instructions to create a new wallet account with passphrase. After running <b>ganache</b> you can import your local wallet into metamask and control your account from the wallet.
8. Open Remix IDE https://remix.ethereum.org/ to deploy the contract <b>SimpleAssetAuditLogs.sol</b>. Use <b>Injected Web3</b> to deploy the smart contract using Metamask.
9. Copy the <b>ABI</b> and <b>Contract address</b> from remix into the javascript file <b>blockkchain.js</b> available in the App and assign it to the corresponding variables.
10. Run the App, and play around.

Photo by David McBee from Pexels
