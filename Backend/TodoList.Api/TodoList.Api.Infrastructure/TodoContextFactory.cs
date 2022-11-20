using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Microsoft.EntityFrameworkCore.Design;

namespace TodoList.Api.Infrastructure
{
    public class TodoContextFactory: IDesignTimeDbContextFactory<TodoContext>
    {
        protected internal IConfigurationRoot Configuration { get; }
        public TodoContextFactory()
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .AddJsonFile("appsettings.Development.json", optional: true)
           .Build();
            Configuration = configuration;
        }
        public TodoContext CreateDbContext(string[] args)
        {
            var connectionString = Configuration.GetConnectionString("dbConnection");
            var postgresSqlBuilder = new NpgsqlConnectionStringBuilder(connectionString);
            var builder = new DbContextOptionsBuilder<TodoContext>();
            builder.UseNpgsql(postgresSqlBuilder.ConnectionString);
            return new TodoContext(builder.Options);

        }
    }
}