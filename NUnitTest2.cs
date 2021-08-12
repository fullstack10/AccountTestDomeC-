using System;
using NUnit.Framework;

[TestFixture]
public class Tester
{	
    private double epsilon = 1e-6;

 
    
    [Test]
    public void AccountCannotHaveNegativeOverdraftLimit()
    {
        Account account = new Account(-20);

        Assert.AreEqual(0, account.OverdraftLimit, epsilon);
    }

    [Test]
    public void PositiveDepositAndWithdraw() //Testcase1
    {
        Account account = new Account(-20);

        Assert.AreEqual(false,account.Deposit(-20));
        Assert.AreEqual(false,account.Withdraw(-20));
    }

    [Test]
    public void OverdraftLimit()  //Testcase2
    {
        Account account = new Account(100);

        Assert.AreEqual(false,account.Withdraw(120));
    }
    
    [Test]
    public void VerifyBalanceAfterDeposit() //Testcase3
    {
     
         double depositAmount = 10.0;
         double expected = 10.0;
        
        Account account = new Account(100); 
        bool result = account.Deposit(depositAmount);
        Assert.AreEqual(expected,account.Balance);
    }
    
    [Test]
    public void VerifyBalanceAfterWithdraw() //Testcase3
    {
               
         double withdrawal = 10.0;
         double expected = -10.0;
        
        Account account = new Account(currentBalance); 
        bool result = account.Withdraw(withdrawal);
        Assert.AreEqual(expected,account.Balance);
    }

    [Test]
    public void CorrectResult() //Testcase4
    {
        Account account = new Account(100);

        Assert.AreEqual(true,account.Deposit(50));
        Assert.AreEqual(true,account.Withdraw(20));
    }


}
