using BankSim.Domain.Abstractions;
using BankSim.Infrastructure.Persistence.Models;

namespace BankSim.Infrastructure.Persistence.Mapper;


/// <summary>
/// Mapper to Domain entity and database entity
/// </summary>
public interface IMapperAccount
{
    /// <summary>
    /// This function convert database object to the domain object
    /// </summary>
    static abstract AccountBase ToDomain(AccountModel account);
    
    /// <summary>
    /// this function convert domain object to database object
    /// </summary>
    /// <returns></returns>
    static abstract AccountModel ToDatabaseModel(AccountBase account);
}
