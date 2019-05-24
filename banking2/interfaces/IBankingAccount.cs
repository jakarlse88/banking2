using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.interfaces
{
    interface IBankingAccount
    {
        decimal ViewBalance();
        void DepositFunds(decimal fundsToBeDeposited);
        void WithdrawFunds(decimal fundsToBeWithdrawn);
    }
}
