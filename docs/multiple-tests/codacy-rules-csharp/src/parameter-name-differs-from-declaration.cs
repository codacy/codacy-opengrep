namespace Tests.Practices
{
    interface IBankAccount
    {
        void AddMoney(int money);
    }

    class BankAccount : IBankAccount
    {
        public void AddMoney(int amount) // Noncompliant
        {
        }
    }

    interface IOther
    {
        void Withdraw(int money);
    }

    class Other : IOther
    {
        public void Withdraw(int money)
        {
        }
    }
}
