pragma solidity ^0.6.1;

contract AuditLogContract
{
    address owner;
    
    struct AuditLog{
        string _dateTimeStamp;
        string _user;
        string _change;
        string _oldValue;
        string _newValue;
    }
    
    //address[] public LogUsers;
    //mapping(address => AuditLog[]) public MappedLogs;
    
    AuditLog[] public AuditLogs;
    uint256 public AuditLogCount;
    
    modifier onlyOwner(){
        require(msg.sender == owner);
        _;
    }
    
     constructor() public{
        owner = msg.sender;
    }
    
    function InsertLog(
        string memory dateTimeStamp,
        string memory user,
        string memory change,
        string memory oldValue,
        string memory newValue) public
    {
        //LogUsers.push(msg.sender);
        AuditLogs.push(AuditLog(dateTimeStamp, user, change, oldValue, newValue));
        AuditLogCount++;
    }
        
    function FetchLogs(uint256 index) public view 
        returns(
        string memory datetimestamp, 
        string memory user, 
        string memory change, 
        string memory oldvalue, 
        string memory newvalue)
    {
        datetimestamp = AuditLogs[index]._dateTimeStamp;
        user = AuditLogs[index]._user;
        change = AuditLogs[index]._change;
        oldvalue = AuditLogs[index]._oldValue;
        newvalue = AuditLogs[index]._newValue;
        
        return (datetimestamp, user, change, oldvalue, newvalue);
    }
    
    function FetchLogCount() public view returns (uint256 count)
    {
        count = AuditLogCount;
        return count;
    }
}

