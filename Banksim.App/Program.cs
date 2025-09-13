﻿public class Program
{
    public static void Main(string[] args)
    {
        AccountBase account = new CheckingAccount { Owner = "Hasan", Balance = new Money { Amount = 200, Currency = "USD" } };
        AccountBase account1 = new CheckingAccount { Owner = "Akbar", Balance = new Money { Amount = 300, Currency = "USD" } };

        TransferService transferService = new TransferService();

        transferService.Transfer(account, account1, new Money { Amount = 100, Currency = "USD" }, "This is a gift!");

        //account.Deposit(new Money { Amount = 200, Currency = "USD" }, TransactionType.Deposit, "");

        foreach (Transaction transaction in account.GetTransactions())
        {
            //Console.WriteLine(account.ToString());
            Console.WriteLine(transaction.ToString());
            Console.WriteLine("\n------------------------------------------------------------------------\n");
        }
        foreach (Transaction transaction in account1.GetTransactions())
        {
            //Console.WriteLine(account.ToString());
            Console.WriteLine(transaction.ToString());
            Console.WriteLine("\n------------------------------------------------------------------------\n");
        }
        Console.WriteLine(account1.Balance);
        Console.WriteLine(account.Balance);
        //new Money { Amount = 200, Currency = "USD" }.Subtract(new Money { Amount = 300, Currency = "USD" });
    }
}