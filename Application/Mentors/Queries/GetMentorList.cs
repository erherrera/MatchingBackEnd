using System;
using Domain;
using MediatR;

namespace Application;

public class GetMentorList
{
    public class Query : IRequest<List<Mentor>> { } 
    public class Handler(IMentorRepository repository) : IRequestHandler<Query, List<Mentor>>
    {
        
        public async Task<List<Mentor>> Handle(Query request, CancellationToken cancellationToken)
        {
            var mentors = await repository.GetAllAsync(cancellationToken);
            return mentors.ToList();
        }
    }
    
}
