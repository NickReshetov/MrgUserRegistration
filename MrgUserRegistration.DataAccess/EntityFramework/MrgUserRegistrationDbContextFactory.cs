using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MrgUserRegistration.DataAccess.EntityFramework
{
public class MrgUserRegistrationDbContextFactory : IDesignTimeDbContextFactory<MrgUserRegistrationDbContext>
{
    private static string _connectionString;

    public MrgUserRegistrationDbContext CreateDbContext()
    {
        return CreateDbContext(null);
    }

    public MrgUserRegistrationDbContext CreateDbContext(string[] args)
    {
        if (string.IsNullOrEmpty(_connectionString))
            LoadConnectionString();
        
        var builder = new DbContextOptionsBuilder<MrgUserRegistrationDbContext>();

        builder.UseSqlServer(_connectionString);

        return new MrgUserRegistrationDbContext(builder.Options);
    }

    private static void LoadConnectionString()
    {
        ConfigurationBuilder builder = new ConfigurationBuilder();

        builder.AddJsonFile("appsettings.json", optional: false);

        IConfigurationRoot configuration = builder.Build();

        _connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(_connectionString))
            throw new Exception("Can't load connection string from appsettings.json");
    }
}
}
