using System;

namespace AccountExample
{
    // تعريف الفئة المجردة (Abstract class) التي تكون الأساس للفئات الأخرى
    abstract class Account
    {
        public decimal Balance { get; set; }
        public int Years { get; set; }

        // دالة مجردة (Abstract method) لحساب الفائدة
        public abstract decimal CalculateInterest();
    }

    // فئة لحساب التوفير (SavingsAccount) التي ترث من الفئة المجردة Account
    class SavingsAccount : Account
    {
        public override decimal CalculateInterest()
        {
            // إذا كانت المدة أقل من 3 سنوات
            if (Years < 3)
            {
                return Balance * 0.03m * Years;
            }
            // إذا كانت المدة أكثر من 3 سنوات
            else
            {
                return Balance * 0.04m * Years;
            }
        }
    }

    // فئة لحساب الوديعة الثابتة (FixedDepositAccount) التي ترث من الفئة المجردة Account
    class FixedDepositAccount : Account
    {
        public override decimal CalculateInterest()
        {
            // إذا كانت المدة أقل من 2 سنوات
            if (Years < 2)
            {
                return Balance * 0.06m * Years;
            }
            // إذا كانت المدة أكثر من 3 سنوات
            else if (Years >= 3)
            {
                return Balance * 0.08m * Years + (500 + Years);
            }
            // إذا كانت المدة بين 2 و 3 سنوات
            else
            {
                return Balance * 0.07m * Years;
            }
        }
    }

    // الفئة الرئيسية (Main class)
    class Program
    {
        static void Main(string[] args)
        {
            // إنشاء مصفوفة من الحسابات
            Account[] accounts = new Account[2];

            // إنشاء حساب التوفير (SavingsAccount)
            accounts[0] = new SavingsAccount { Balance = 1000m, Years = 4 };
            // إنشاء حساب الوديعة الثابتة (FixedDepositAccount)
            accounts[1] = new FixedDepositAccount { Balance = 2000m, Years = 5 };

            // حساب الفائدة لجميع الحسابات
            foreach (var account in accounts)
            {
                Console.WriteLine($"Balance: {account.Balance} - Years: {account.Years} - Interest: {account.CalculateInterest()}");
            }
        }
    }
}