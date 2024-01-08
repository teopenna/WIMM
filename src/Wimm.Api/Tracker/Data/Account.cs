using Wimm.Api.Common.Enums;

namespace Wimm.Api.Tracker.Data;

/// <summary>
/// Details of an account
/// </summary>
public sealed class Account
{
    /// <summary>
    /// Account unique identifier
    /// </summary>
    public Guid Id { get; init; }
    /// <summary>
    /// Name of the account
    /// </summary>
    public string Name { get; init; }
    /// <summary>
    /// Type of the account
    /// </summary>
    public AccountTypes Type { get; init; }
    /// <summary>
    /// Notes
    /// </summary>
    public string Notes { get; init; }

    private Account(Guid id, string name, AccountTypes type, string notes)
    {
        Id = id;
        Name = name;
        Type = type;
        Notes = notes;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="type"></param>
    /// <param name="notes"></param>
    /// <returns></returns>
    public static Account Create(string name, AccountTypes type, string notes)
    {
        return new(Guid.NewGuid(), name, type, notes);
    }
}