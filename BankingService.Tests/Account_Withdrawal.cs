using System;
using Xunit;
using BankingService;
using FluentAssertions;

namespace BankingService.Tests
{
    public class Account_Withdrawal {
        [Fact]
        public void WithdrawalFails_If_Balance_IsInsufficient()
        {
        //Given
        Account account = new Account("CX-3", "Monica", "Barns");
        
        //When
        Action withdrawal = () => account.Withdrawal(50);
        
        //Then
        withdrawal.Should().Throw<ApplicationException>()
        .WithMessage("Cannot withdraw amount higher than balance.");

        }

        [Fact]
        public void WithdrawalFails_If_Amount_IsNegative()
        {
        //Given
        Account account = new Account("CX-3", "Monica", "Barns");
        
        //When
        Action withdrawal = () => account.Withdrawal(-50);
        
        //Then
        withdrawal.Should().Throw<ApplicationException>()
        .WithMessage("Cannot withdraw negative amounts");

        }

        [Fact]
        public void WithdrawlPass_WhenBalance_IsHigherThanWithdrawalAmount()
        {
            //Given
            Account account = new Account("CX-3", "Monica", "Barns");
            //When
            account.Deposit(50);
            account.Withdrawal(25);
            //Then
            account.Balance.Should().Be(25);
        }
    }
}