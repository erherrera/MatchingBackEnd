using System;
using Domain;
using Microsoft.Xrm.Sdk.Query;


namespace Persistence;

public class DataverseMentorRepository : IMentorRepository
{
    private readonly DataverseContext _context;

    public DataverseMentorRepository(DataverseContext context)
    {
        _context = context;
    }

    // ...existing code...
    public async Task<Mentor> GetByIdAsync(string id,CancellationToken cancellationToken = default)
    {
        var entity = await _context.ServiceClient.RetrieveAsync("contact", new Guid(id), new ColumnSet(true));
        if (entity == null) return null;

        // Map fields from Entity to Mentor
        var mentor = new Mentor(
            entity.Id,
            entity.GetAttributeValue<string>("firstname"),
            entity.GetAttributeValue<string>("lastname"),
            null, // Replace null with actual values as needed
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            0,    // Replace 0 with actual int value as needed
            false, // Replace false with actual bool value as needed
            null   // Replace null with actual string value as needed
        );

        return mentor;
    }

    public Task<IEnumerable<Mentor>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        // TODO: Implement retrieval logic from Dataverse
        throw new NotImplementedException();
    }

    public async Task AddAsync(Mentor mentor,CancellationToken cancellationToken = default)
    {
        // TODO: Implement add logic to Dataverse
        await Task.Run(() => throw new NotImplementedException());
    }

    public Task UpdateAsync(Mentor mentor,CancellationToken cancellationToken = default)
    {
        // TODO: Implement update logic to Dataverse
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id,CancellationToken cancellationToken = default)
    {
        // TODO: Implement delete logic from Dataverse
        throw new NotImplementedException();
    }

}
