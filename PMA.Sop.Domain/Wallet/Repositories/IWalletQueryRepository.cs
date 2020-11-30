using System.Threading.Tasks;

namespace PMA.Sop.Domain.Wallet.Repositories
{
    public interface IWalletQueryRepository
    {
        Task<decimal> BalanceUserWalletAsync(string userName);
    }
}