using System;
using Domain;
using Microsoft.Xrm.Sdk;

namespace Application;

public class MentorService
{
    private readonly IMentorRepository _repository;

    public MentorService(IMentorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Mentor> GetByIdAsync(string id)
    {
        var mentor = await _repository.GetByIdAsync(id);
        if (mentor == null)
            throw new InvalidOperationException($"Mentor with id {id} not found.");

        return mentor;
    }

    // Add other methods as needed
}
