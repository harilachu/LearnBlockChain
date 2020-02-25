pragma solidity ^0.5.1;

contract AuditLogContract
{
    address owner;
    
    struct AuditLog{
        uint256 _id;
        string _dateTimeStamp;
        string _user;
        string _change;
        string _oldValue;
        string _newValue;
    }
    
    mapping(uint16 => AuditLog) public Logs;
    
    modifier onlyOwner(){
        require(msg.sender == owner);
        _;
    }
    
     constructor() public{
        owner = msg.sender;
    }
    
    function InsertLog(uint16 userid, 
        uint256 id,
        string memory dateTimeStamp,
        string memory user,
        string memory change,
        string memory oldValue,
        string memory newValue) public onlyOwner
    {
        Logs[userid] = AuditLog(id, dateTimeStamp, user, change, oldValue, newValue);
    }
        
    function FetchLogs(uint16 userid) public view 
    returns(
        uint256 id, 
        string memory dateTimeStamp, 
        string memory user, 
        string memory change, 
        string memory oldValue, 
        string memory newValue)
    {
        AuditLog memory log = Logs[userid];
        id = log._id;
        dateTimeStamp = log._dateTimeStamp;
        user = log._user;
        change = log._change;
        oldValue = log._oldValue;
        newValue = log._newValue;
    }
    
}

