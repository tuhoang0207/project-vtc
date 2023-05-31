using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using BLL.Interfaces;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace UI;




public enum AccountType
{
    Admin = 1,
    Employee = 2,
}
public class AccountManager
{

    public static AccountManager Instance;
    private AccountManager()
    {
        Instance = this;
    }
   

    private AccountType _accountType;

    
    public void UpdateAccountType(AccountType accountType)
    {
        switch (accountType)
        {
            case AccountType.Admin:
                this._accountType = AccountType.Admin;
                break;
            case AccountType.Employee:
                this._accountType = AccountType.Employee;
                break;
        }
        
    }

    public bool AccountAdmin()
    {
        return _accountType == AccountType.Admin;
    }

    public bool AccountEmployee()
    {
        return _accountType == AccountType.Employee;
    }
}