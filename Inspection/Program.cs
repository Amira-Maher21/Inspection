using Inspection.API.Main.DiExtensions;

namespace Inspection.API.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {




            var builder = WebApplication.CreateBuilder(args);

            // Register Dapper type handler for DateOnly
            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

            // Controllers and JSON settings
            builder.Services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                    //opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
                });



            //
            builder.Services.AddCors();

            // Swagger
            builder.Services.AddSwaggerServicesExtensions();

            // Dependency Injection
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();
            builder.Services.AddAccountsApplicationServices();
            builder.Services.AddAccountsRepositoryManagers(builder.Configuration);
            builder.Services.ConfigureJWT(builder.Configuration);
            builder.Services.AddAuthorization();
            builder.Services.AddFluentValidationExtensions();

            var connectionString = builder.Configuration.GetConnectionString("Inspection");

            builder.Services.AddDbContext<DbInspectionContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<DbContext, DbInspectionContext>();
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddScoped<DatabaseExceptionManager>();
            builder.Services.AddScoped<IExcelTemplateGenerator, ExcelTemplateGenerator>();

            builder.Services.AddScoped<IJournalEntryQueryRepository, JournalEntryQueryRepository>();
            builder.Services.AddScoped<IPostingAccountMappingQueryRepository, PostingAccountMappingQueryRepository>();
            builder.Services.AddScoped<ILedgerCommandRepository, LedgerCommandRepository>();
            // Register PostingEngine
            builder.Services.AddScoped<IPostingEngine, PostingEngine>();

            // Register Posting Handlers
            builder.Services.AddScoped<IPostingHandler<JournalEntry>, JournalEntryPostingHandler>();


            //GoodsReceipt
            //builder.Services.AddScoped<IPostingHandler<GoodsReceipt>, GoodsReceiptPostingHandler>();

            builder.Services.AddScoped<IAccountBalanceService, AccountBalanceService>();

            builder.Services.AddScoped<ICurrencyService, CurrencyService>();

            //builder.Services.AddScoped<IGoodsReceiptQueryRepository, GoodsReceiptQueryRepository>();
            //builder.Services.AddScoped<IInventoryLedgerCommandRepository, InventoryLedgerCommandRepository>();
            //builder.Services.AddScoped<IInventoryCostLayerCommandRepository, InventoryCostLayerCommandRepository>();
            //builder.Services.AddScoped<IInventoryBalanceCommandRepository, InventoryBalanceCommandRepository>();
            //builder.Services.AddScoped<IInventoryBalanceQueryRepository, InventoryBalanceQueryRepository>();
            //builder.Services.AddScoped<IInventoryLedgerService, InventoryLedgerService>();
            //builder.Services.AddScoped<IInventoryBalanceService, InventoryBalanceService>();
            //builder.Services.AddScoped<IInventoryCostLayersService, InventoryCostLayerService>();

            builder.Services.Scan(scan => scan
            .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            .AddClasses(classes => classes.Where(t =>
                t.GetInterfaces().Any(i =>
                    i.Name.StartsWith("IInventory") ||
                    i.Name.StartsWith("IGoodsReceipt")
                    ||
                    i.Name.StartsWith("ISeries")
                //||
                //i.Name.EndsWith("Repository") ||
                //i.Name.EndsWith("Service")
                )
            ))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );

            //builder.Services.AddScoped<IAccountUnitOfWork, AccountUnitOfWork>();

            // builder.Services.AddScoped<IGoodsReceiptService, GoodsReceiptService>();

            // EventBus
            // ---------------------------
            //  builder.Services.AddScoped<IEventBus, EventBus>();

            // ---------------------------
            // Auto-register Event Handlers
            // ---------------------------
            builder.Services.Scan(scan => scan
                .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(classes =>
                    classes.Where(type =>
                        type.GetInterfaces().Any(i =>
                            i.IsGenericType &&
                            i.GetGenericTypeDefinition() == typeof(IEventHandler<>) &&
                            typeof(IDomainEvent).IsAssignableFrom(
                                i.GetGenericArguments()[0]
                            )
                        )
                    )
                )
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            var app = builder.Build();
            // app.UseMiddleware<GlobalExceptionMiddleware>();

            // Middleware pipeline
            app.AddSwaggerApplicationExtensions();

            // Use the defined CORS policy

            app.UseCors(builder => builder
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin()
            );
            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
