using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories;

public class AccountAdminRepository : GenericRepository<AccountAdmin>, IAccountAdminReposioty
{
    public AccountAdminRepository(CoffeeShopDbContext context) : base(context)
    {
    }
}