using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;
using System.Reflection;

namespace Migrations
{
    public class SqlMigrator
    {
        public IConfiguration Configuration { get; }

        private ILogger<SqlMigrator> _logger;

        public SqlMigrator(IConfiguration configuration, ILogger<Migrations.SqlMigrator> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public void Migrate()
        {
            try
            {
                var connection = new SqlConnection(Configuration.GetConnectionString("SQL"));
                var evolve = new Evolve.Evolve(connection, msg => _logger.LogInformation(msg))
                {
                    Locations = new[] { "scripts" },
                    IsEraseDisabled = true
                };

                evolve.Migrate();
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Database migration failed.", ex);
                throw;
            }
        }
    }
}
