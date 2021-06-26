using System;
using IdentityServer4.EntityFramework.Options;
using Microsoft.Extensions.Options;

namespace Tests
{
    public class OperationalStoreOptionsForTest : IOptions<OperationalStoreOptions>
    {
        public OperationalStoreOptions Value => new OperationalStoreOptions();
    }
}
