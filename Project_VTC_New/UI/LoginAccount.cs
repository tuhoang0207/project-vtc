using System.Runtime.InteropServices.ComTypes;
using BLL.Interfaces;
using DAL.Entities;


namespace UI;

public class LoginAccount
{
    private IAccountAdminService _accountAdminService;
    private IAccountEmployeeService _accountEmployeeService;


    public LoginAccount(IAccountAdminService accountAdminService, IAccountEmployeeService accountEmployeeService)
    {
        this._accountAdminService = accountAdminService;
        this._accountEmployeeService = accountEmployeeService;
    }

    public void Menu()
    {
        int choice = 0;
        do
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Login");
            Console.Write("Enter Choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    Console.WriteLine("Good Bye");
                    Environment.Exit(0);
                    break;
                case 1:
                    IsLogin();
                    break;
            }
        } while (choice != 0);
       
    }

    public bool IsLogin()
    {   
        Console.Write("User Name: ");
        string userName = Console.ReadLine();
        Console.Write("Pass Word: ");
        string passWord = Console.ReadLine();
        if (userName != null && passWord != null)
        {
            LoginAccountAdmin(userName,passWord);
            LoginAccountEmployee(userName, passWord);
            return true;
        }
        return false;
    }

    public void LoginAccountAdmin(string userName, string passWord)
    {
        if (this._accountAdminService.IsLogin(userName, passWord))
        {
            AccountManager.Instance.UpdateAccountType(AccountType.Admin);
        }
    }

    public void LoginAccountEmployee(string userName, string passWord)
    {
        if (this._accountEmployeeService.Islogin(userName,passWord))
        {
            AccountManager.Instance.UpdateAccountType(AccountType.Employee);
        }
    }
}