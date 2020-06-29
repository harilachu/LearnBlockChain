using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Solidity_Project.Contracts.Storage.ContractDefinition
{


    public partial class StorageDeployment : StorageDeploymentBase
    {
        public StorageDeployment() : base(BYTECODE) { }
        public StorageDeployment(string byteCode) : base(byteCode) { }
    }

    public class StorageDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6080604052348015600f57600080fd5b5060ac8061001e6000396000f3fe6080604052348015600f57600080fd5b506004361060325760003560e01c80636057361d146037578063b05784b8146053575b600080fd5b605160048036036020811015604b57600080fd5b5035606b565b005b60596070565b60408051918252519081900360200190f35b600055565b6000549056fea2646970667358221220ec82b725534378fedab8b6afad53d33bc93a159fb5b88674bd77553884f7d8a264736f6c63430006080033";
        public StorageDeploymentBase() : base(BYTECODE) { }
        public StorageDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class RetreiveFunction : RetreiveFunctionBase { }

    [Function("retreive", "uint256")]
    public class RetreiveFunctionBase : FunctionMessage
    {

    }

    public partial class StoreFunction : StoreFunctionBase { }

    [Function("store")]
    public class StoreFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "num", 1)]
        public virtual BigInteger Num { get; set; }
    }

    public partial class RetreiveOutputDTO : RetreiveOutputDTOBase { }

    [FunctionOutput]
    public class RetreiveOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
