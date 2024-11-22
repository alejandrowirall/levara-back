using Serilog;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL.ColumnWriters;

namespace Levara.WebApi.Infrastructure.Security;


public static class LevaraSerilogExtensions
{
    public static IServiceCollection AddLevaraSerilog(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSerilog();

        var columnWriters = new Dictionary<string, ColumnWriterBase>
            {
                { "Id" , new IdAutoIncrementColumnWriter() },
                //{ "UserId", new SinglePropertyColumnWriter(propertyName: "UserId", dbType: NpgsqlTypes.NpgsqlDbType.Integer) },
                //{ "Path", new SinglePropertyColumnWriter(propertyName: "Path", dbType: NpgsqlTypes.NpgsqlDbType.Text) },
                { "Message", new RenderedMessageColumnWriter() },
                { "MessageTemplate", new MessageTemplateColumnWriter() },
                { "Level", new LevelColumnWriter() },
                { "TimeStamp", new TimestampColumnWriter() },
                { "Exception", new ExceptionColumnWriter() },
                { "LogEvent", new LogEventSerializedColumnWriter() },
                //{ "RequestId", new SinglePropertyColumnWriter(propertyName: "RequestId", dbType: NpgsqlTypes.NpgsqlDbType.Uuid) },
                //{ "CorrelationId", new SinglePropertyColumnWriter(propertyName: "CorrelationId", dbType: NpgsqlTypes.NpgsqlDbType.Uuid) },

            };

        LogEventLevel minimumLevel = LogEventLevel.Warning;

        Serilog.Debugging.SelfLog.Enable(Console.Out);

        Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Is(minimumLevel)
               .MinimumLevel.Override("Microsoft.Hosting.Lifetime", minimumLevel == LogEventLevel.Warning ? LogEventLevel.Information : minimumLevel)
               .MinimumLevel.Override("Levara.WebApi.Infrastructure.Middlewares", minimumLevel == LogEventLevel.Warning ? LogEventLevel.Information : minimumLevel)
               //.WriteTo.Async(a => a
               //            .PostgreSQL(
               //                connectionString: configuration["DatabaseConfiguration:ConnectionString"].ToString(),
               //                tableName: "Logs",
               //                columnOptions: columnWriters,
               //                needAutoCreateTable: true,
               //                batchSizeLimit: 500,
               //                period: TimeSpan.FromSeconds(5)
               //            ))
               .WriteTo.PostgreSQL(
                               connectionString: configuration["DatabaseConfiguration:ConnectionString"].ToString(),
                               tableName: "Logs",
                               columnOptions: columnWriters,
                               needAutoCreateTable: true
                           )
               .CreateLogger();

        return services;
    }
}
