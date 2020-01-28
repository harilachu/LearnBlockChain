pragma solidity 0.5.1;

contract MyContract {
    uint8 public peopleCount = 0;
    mapping(uint8 => Person) public people;
    
    struct Person{
        uint8 _id;
        string _firstName;
        string _lastName;
    }
    
    address owner;
    uint256 openingTime = 1580225640;
    
    modifier onlyOwner(){
        require(msg.sender == owner);
        _;
    }
    
    modifier onlyWhenOpen(){
        require(block.timestamp >= openingTime);
        _;
    }
    
    constructor() public{
        owner = msg.sender;
    }
   
    function AddPerson(string memory _firstName, string memory _lastName) public onlyWhenOpen{
        incrementCount();
        people[peopleCount] =  Person(peopleCount, _firstName, _lastName);
    }
    
    function incrementCount() internal{
        peopleCount += 1;
    }
}
