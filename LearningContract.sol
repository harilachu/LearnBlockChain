pragma solidity ^0.5.1;

contract Demo{
    
    string public name;
    
    function setName(string memory _name) public
    {
        name = _name;
    }
    
    function getName() view public returns(string memory)
    {
        return name;
    }
}
