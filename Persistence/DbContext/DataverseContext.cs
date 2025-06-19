using System;
using Microsoft.Extensions.Configuration;
using Microsoft.PowerPlatform.Dataverse.Client;

namespace Persistence.DbContext;

public class DataverseContext : IDataverseContext
{
    public ServiceClient ServiceClient { get; }

    public DataverseContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Dataverse");
        ServiceClient = new ServiceClient(connectionString);
    }
}
