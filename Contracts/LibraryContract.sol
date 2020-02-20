pragma solidity 0.5.1;

import "./Math.sol";

contract MyContract{
    using Math for uint256;
    uint256 public value;
    
    function calculate(uint _value1, uint _value2) public{
        value = _value1.divide(_value2);
        //value = Math.divide(_value1, _value2);
    }
}
