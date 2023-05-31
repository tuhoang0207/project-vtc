
using BLL.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Services;

public class AccountAdminService : IAccountAdminService
{
    public IUnitOfWork unitOfWork;

    public AccountAdminService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public bool IsLogin(string username, string password)
    {
        if (username != null  && password != null)
        {
            return unitOfWork.accountAdminReposioty
                .GetAllAsync()
                .Where(account => account.UserName == username && account.PassWord == password).Any();

        }

        return false;
    }
}