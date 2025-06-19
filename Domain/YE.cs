using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain;

public class YE:Contact
{
    public string Expertise { get; set; }
    public int YearsOfExperience { get; set; }
    public bool IsAvailable { get; set; }
    public YE(
        Guid contactId,
        string firstName,
        string lastName,
        string email,
        string phone,
        string address,
        string city,
        string state,
        string zip,
        string country,
        string company,
        string jobTitle,
        DateTime? dateOfBirth,
        string linkedIn,
        string twitter,
        string expertise,
        int yearsOfExperience,
        bool isAvailable,
        string description 
    ) : base(
        contactId,
        firstName,
        lastName,
        email,
        phone,
        address,
        city,
        state,
        zip,
        country,
        company,
        jobTitle,
        dateOfBirth,
        linkedIn,
        twitter,
        description
    )
    {
        Expertise = expertise;
        YearsOfExperience = yearsOfExperience;
        IsAvailable = isAvailable;
    }
}


public interface IYERepository
{
    Task<YE> GetByIdAsync(Guid contactId);
    Task<IEnumerable<YE>> GetAllAsync();
    Task AddAsync(YE ye);
    Task UpdateAsync(YE ye);
    Task DeleteAsync(Guid contactId);
}