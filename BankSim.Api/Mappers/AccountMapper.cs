//using BankSim.Api.Models;
//using BankSim.Domain.Abstractions;
//using BankSim.Domain.Account;
//using BankSim.Domain.ValueObjects;
//using System.Runtime.CompilerServices;

//namespace BankSim.Api.Mappers
//{
//    /// <summary>
//    /// Account Mapper map Account and AccountDto
//    /// </summary>
//    public static class AccountMapper
//    {
//        /// <summary>
//        /// Converts to dto.
//        /// </summary>
//        /// <param name="account">The account.</param>
//        /// <returns></returns>
//        public static AccountDto ToDto(this AccountBase account)
//        {
//            return new AccountDto
//            {
//                Id = account.Id,
//                Owner = account.Owner,
//                Balance = account.Balance,
//            };
//        }
//        /// new<summary>
//        /// Converts to entity.
//        /// </summary>
//        /// <returns></returns>
//        public static AccountBase ToEntity(this AccountDto dto)
//        {
//            var money = new Money(dto.Balance.Amount, dto.Balance.Currency);
//            return new CheckingAccount(dto.Owner ?? "UNKNOWN", money);
//        }
//    }
//}
