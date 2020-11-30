using Microsoft.EntityFrameworkCore;
using PMA.Sop.DAL.Context;
using PMA.Sop.Domain.Wallet.Repositories;

namespace PMA.Sop.DAL.Wallet.Repositories
{
    public class WalletCommandRepository : IWalletCommandRepository
    {

        private readonly DatabaseContext _dbContext;

        public WalletCommandRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}