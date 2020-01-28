pragma solidity 0.5.1;

contract ERC20Token{
    string public name;
    mapping(address => uint) public balances;
    
    constructor(string memory _name) public{
        name = _name;
    }
    
    function mint() public {
        balances[tx.origin]++;
    }
}

contract ChildERCToken is ERC20Token{
    string public symbol;
    address[] public owners;
    uint256 ownerCount;
    
    constructor(string memory _name, string memory _symbol) ERC20Token(_name) public {
        symbol = _symbol;
    }
    
    function mint() public{
        super.mint();
        ownerCount++;
        owners.push(msg.sender);
    }
}


contract PayableContract{
    address payable wallet;
    address token;
    
    constructor(address payable _wallet, address _token) public{
        wallet = _wallet;
        token = _token;
    }
    
    function buyToken() public payable{
        ERC20Token _token = ERC20Token(address(token));
        _token.mint();
        wallet.transfer(msg.value);
    }
}

/*contract PayableContract{
    address payable wallet;
    mapping(address => uint) public balances;
    
    event Purchase(address _buyer, uint256 amount);
    
    constructor(address payable _wallet) public{
        wallet = _wallet;
    }
    
    function buyToken() public payable{
        balances[msg.sender] += 1;
        wallet.transfer(msg.value);
        emit Purchase(msg.sender, msg.value);
    }
}
*/
