https://www.testdome.com/questions/c-sharp/account-test/18413

using System;
using NUnit.Framework;

[TestFixture]
public class Tester
{	
    private double epsilon = 1e-6;

    [Test]
    public void accountCannotHaveNegativeOverdraftLimit()
    {
        Account account = new Account(-20);
        
        Assert.AreEqual(0d, account.OverdraftLimit, epsilon);
    }
        
    [Test]
     public void depositDoesntAcceptNegativeValue() {
        Account account = new Account(20);
        var result = account.Deposit(-10);

        Assert.AreEqual(0d, account.Balance, epsilon);
        Assert.False(result);
    }
    
     [Test]
     public void withdrawDoesntAcceptNegativeValue() {
        Account account = new Account(20);
        var result = account.Withdraw(-10);

        Assert.AreEqual(0d, account.Balance, epsilon);
        Assert.False(result);
    }
    
    [Test]
    public void depositPositiveValueOk() {
        Account account = new Account(20);
        var result = account.Deposit(10);

        Assert.AreEqual(10d, account.Balance, epsilon);
        Assert.True(result);
    }
    
     [Test]
     public void withdrawPositiveValueOverdraftOk() {
        Account account = new Account(20);
        var result = account.Withdraw(10);

        Assert.AreEqual(-10d, account.Balance, epsilon);
          Assert.True(result);
    }
    
      public void withdrawPositiveValueBalanceOk() {
        Account account = new Account(0);
        account.Deposit(20);
        var result = account.Withdraw(10);

        Assert.AreEqual(10d, account.Balance, epsilon);
        Assert.True(result);
    }

    [Test]
    public void accountCannotOverstepOverdraftLimit() {
        Account account = new Account(20);
        var result = account.Withdraw(30);

        Assert.AreEqual(0d, account.Balance, epsilon);
        Assert.False(result);
    }

}
