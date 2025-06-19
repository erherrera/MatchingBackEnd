using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain;

// Dataverse Contact entity mapping
public class Contact
{
    public Guid ContactId { get; set; } // Primary Key in Dataverse
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string EmailAddress1 { get; set; }
    public string MobilePhone { get; set; }
    public string Telephone1 { get; set; }
    public string Address1_Line1 { get; set; }
    public string Address1_City { get; set; }
    public string Address1_StateOrProvince { get; set; }
    public string Address1_PostalCode { get; set; }
    public string Address1_Country { get; set; }
    public DateTime? BirthDate { get; set; }
    public string JobTitle { get; set; }
    public string Company { get; set; }
    public string Description { get; set; }



    public Contact(
        Guid contactId,
        string firstName,
        string lastName,
        string fullName,
        string emailAddress1,
        string mobilePhone,
        string telephone1,
        string address1_Line1,
        string address1_City,
        string address1_StateOrProvince,
        string address1_PostalCode,
        string address1_Country,
        DateTime? birthDate,
        string jobTitle,
        string company,
        string description)
    {
        ContactId = contactId;
        FirstName = firstName;
        LastName = lastName;
        FullName = fullName;
        EmailAddress1 = emailAddress1;
        MobilePhone = mobilePhone;
        Telephone1 = telephone1;
        Address1_Line1 = address1_Line1;
        Address1_City = address1_City;
        Address1_StateOrProvince = address1_StateOrProvince;
        Address1_PostalCode = address1_PostalCode;
        Address1_Country = address1_Country;
        BirthDate = birthDate;
        JobTitle = jobTitle;
        Company = company;
        Description = description;
    }
}
public interface IContactRepository
{
    Task<Contact?> GetByIdAsync(Guid contactId);
    Task<IEnumerable<Contact>> GetAllAsync();
    Task AddAsync(Contact contact);
    Task UpdateAsync(Contact contact);
    Task DeleteAsync(Guid contactId);
}

