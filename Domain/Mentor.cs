using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain;

public class Mentor : Contact
{
    public string Expertise { get; set; }
    public int YearsOfExperience { get; set; }
    public bool IsAvailable { get; set; }

    public Mentor(
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
public interface IMentorRepository
{
    Task<Mentor> GetByIdAsync(string id,CancellationToken cancellationToken = default);
    Task<IEnumerable<Mentor>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Mentor mentor);
    Task UpdateAsync(Mentor mentor);
    Task DeleteAsync(Guid id);
}
