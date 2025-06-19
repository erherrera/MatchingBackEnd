using System;
using Domain;
using MediatR;

namespace Application;

public class GetMentorDetails
{
    public class Query : IRequest<Mentor> { 
        public required string Id;
    } 
    public class Handler(IMentorRepository repository) : IRequestHandler<Query, Mentor>
    {
        
        public async Task<Mentor> Handle(Query request, CancellationToken cancellationToken)
        {
            var mentor = await repository.GetByIdAsync(request.Id,cancellationToken);
            if (mentor == null)
            {
                throw new KeyNotFoundException($"Mentor with ID {request.Id} not found.");
            }
            return mentor;
        }
    }
}
