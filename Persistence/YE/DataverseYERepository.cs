using System;
using Domain;

namespace Persistence;

public class DataverseYERepository : IYERepository
{
    public Task<YE> GetByIdAsync(Guid id)
    {
        // Implement logic to retrieve a YEEntity by id from Dataverse
        throw new NotImplementedException();
    }

    public Task<IEnumerable<YE>> GetAllAsync()
    {
        // Implement logic to retrieve all YEEntities from Dataverse
        throw new NotImplementedException();
    }

    public Task AddAsync(YE entity)
    {
        // Implement logic to add a new YEEntity to Dataverse
        throw new NotImplementedException();
    }

    public Task UpdateAsync(YE entity)
    {
        // Implement logic to update an existing YEEntity in Dataverse
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        // Implement logic to delete a YEEntity by id from Dataverse
        throw new NotImplementedException();
    }
}
