using Autofac;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.UnitOfWorks;

namespace Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly string _webAddress;
        private readonly int _delay;

        public InfrastructureModule(string connectionString, string migrationAssemblyName, string webAddress, int delay)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _webAddress = webAddress;
            _delay = delay;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WorkerContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .SingleInstance();

            builder.RegisterType<SettingsConfig>()
                   .WithParameter("webAddress", _webAddress)
                   .WithParameter("delay", _delay)
                   .SingleInstance();

            //Registering repositories
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>()
                .SingleInstance();
            builder.RegisterType<StockExchangeRepository>().As<IStockExchangeRepository>()
                .SingleInstance();

            //Registering UnitOfWorks
            builder.RegisterType<WorkerUnitOfWork>().As<IWorkerUnitOfWork>()
                .SingleInstance();

            //Registering services
            builder.RegisterType<ParseFormWeb>().As<IParseFormWeb>()
                .SingleInstance();

            builder.RegisterType<StockExchangeService>().As<IStockExchangeService>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
