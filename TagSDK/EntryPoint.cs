using System;
using System.Collections.Generic;
using TagSDK.Services;
using Microsoft.Extensions.DependencyInjection;
using TagSDK.Services.Interfaces;
using TagSDK.Pipeline.Interfaces;
using TagSDK.Pipeline;
using TagSDK.Validators;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using TagSDK.Authorization;
using TagSDK.Services.Receivable.Advancement;
using TagSDK.Services.Receivable.Consent;
using TagSDK.Services.Receivable.Contract;
using TagSDK.Services.Receivable.Notification;
using TagSDK.Services.Receivable.Position;
using TagSDK.Services.Receivable.Reconciliation;
using TagSDK.Services.Receivable.Register;
using TagSDK.Services.Receivable.Settlement;
using TagSDK.Services.Receivable.Transaction;

namespace TagSDK.Factories
{
    public static class TagSdk
    {
        private static TagServiceCollection _factory = null;
        public static TagServiceCollection GetServices(Action<SDKOptions> actOptions)
        {
            if (_factory == null)
            {
                IServiceCollection serviceCollection = new ServiceCollection();

                var options = new SDKOptions();
                actOptions(options);

                RegisterServices(serviceCollection, options);

                _factory = new TagServiceCollection(serviceCollection.BuildServiceProvider());
            }

            return _factory;
        }

        public static IServiceCollection AddTagSDK(this IServiceCollection services, Action<SDKOptions> actOptions)
        {
            var options = new SDKOptions();
            actOptions(options);

            RegisterServices(services, options);

            return services;
        }

        private static void RegisterServices(IServiceCollection services, SDKOptions options)
        {
            services
                        .AddSingleton<SDKOptions>(options)
                        .AddTransient<IModelValidator, DefaultModelValidator>()
                        .AddTransient<IRestClient, RestClient>((provider) =>
                        {
                            var restClient = new RestClient();
                            restClient.UseNewtonsoftJson();
                            return restClient;
                        })
                        .AddSingleton<IAuthorizator, DefaultAuthorizator>()
                        .AddTransient(typeof(LogMidleware<,>))
                        .AddTransient(typeof(ValidateMidleware<,>))
                        .AddTransient(typeof(RequestMidleware<,>))
                        .AddTransient(typeof(IPipelineBehavior<,>), typeof(PipelineDefaultBehavior<,>))
                        //services
                        .AddTransient<IAuthenticateService, AuthenticateService>()
                        .AddTransient<IReceivableService, ReceivableService>()
                        .AddTransient<IAdvancementService, AdvancementService>()
                        .AddTransient<ICommercialEstablishmentService, CommercialEstablishmentService>()
                        .AddTransient<INotificationService, NotificationService>()
                        .AddTransient<ITransactionService, TransactionService>()
                        .AddTransient<ISettlementService, SettlementService>()
                        .AddTransient<IPositionService, PositionService>()
                        .AddTransient<IContractService, ContractService>()
                        .AddTransient<IContractService, ContractService>()
                        .AddTransient<IConsentService, ConsentService>()
                        .AddTransient<IReconciliationService, ReconciliationService>();
        }
    }

    public class TagServiceCollection
    {
        protected readonly IServiceProvider ServiceProvider;

        internal TagServiceCollection(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;

            FluentValidation.AssemblyScanner
                .FindValidatorsInAssembly(typeof(TagServiceCollection).Assembly)
                .ForEach(result =>
                {
                    if (Validators.ContainsKey(result.InterfaceType))
                    {
                        (Validators[result.InterfaceType] as List<Type>).Add(result.ValidatorType);
                    }
                    else
                    {
                        Validators.Add(result.InterfaceType, new List<Type>() { result.ValidatorType });
                    }
                });
        }

        private Dictionary<Type, IEnumerable<Type>> Validators { get; set; } = new Dictionary<Type, IEnumerable<Type>>();

        public IAuthenticateService AuthenticateService => ServiceProvider.GetService<IAuthenticateService>();

        public IReceivableService ReceivableService => ServiceProvider.GetService<IReceivableService>();

        public IAdvancementService AdvancementService => ServiceProvider.GetService<IAdvancementService>();

        public ICommercialEstablishmentService CommercialEstablishmentService => ServiceProvider.GetService<ICommercialEstablishmentService>();

        public INotificationService NotificationService => ServiceProvider.GetService<INotificationService>();

        public ITransactionService TransactionService => ServiceProvider.GetService<ITransactionService>();

        public ISettlementService SettlementService => ServiceProvider.GetService<ISettlementService>();

        public IReconciliationService ReconciliationService => ServiceProvider.GetService<IReconciliationService>();
        public IPositionService PositionService => ServiceProvider.GetService<IPositionService>();

        public IContractService ContractService => ServiceProvider.GetService<IContractService>();

        public IConsentService ConsentService => ServiceProvider.GetService<IConsentService>();

    }
}
