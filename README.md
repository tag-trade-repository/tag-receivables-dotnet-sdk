## 1 - Introdução
Esta SDK tem como objetivo facilitar a integração com a Plataforma de Registro da TAG para Recebíveis de Arranjo de Pagamento.

### 1.1 - Perfis de usuário
- Credenciador - ***Acquirer***
- Credor - ***Creditor***

## 2 - Documentação de negócio da API
A documentação de negócio da Api de Registro de Arranjo de Pagamento pode ser encontrada no link: [Documentação API TAG](https://docs.taginfraestrutura.com.br/reference).

## 3 - Como fazer o download do projeto
Para fazer o download da SDK acesse o [repositório]() e clone o projeto utilizando o **Git**. Exemplo:

```shell
 git clone <link-de-clonagem>
```

Para mais informações sobre a instalação do **_git_**,
acesse: [Instalação Git](https://git-scm.com/book/pt-br/v2/Come%C3%A7ando-Instalando-o-Git). </br>
Para mais informações sobre **_git_** e seus comandos, acesse: [Documentação Git](https://git-scm.com/doc).

## 4 - Como fazer o build do projeto
Com o projeto aberto no ***Visual Studio*** abra a opção ***Compilação***, localizada no menu superior, e em seguida clique em ***Pacote nome-do-projeto***. Assim, um arquivo com extensão ***.dll*** será criado e poderá ser usado como dependência em outro projeto. 

## 5 - Como adicionar a SDK como dependência

### 5.1 - Adicionar ddl
No menu lateral "Gerênciador de Soluções" expanda o projeto e clique com o botão direito na opção dependências e em seguida acesse ***Adicionar Referência de Projeto > Procurar***. Por fim, procure a ***ddl*** gerada pelo build, selecione-a, clique em ***Adicionar*** e em sequência em ***OK***.

### 5.2 - Adicionar pacote NuGet
Com o projeto aberto clique com botão direito em dependências e em gerênciar pacote do NuGet. Em seguida digite na barra de pesquisa o nome do pacote `TagSDK` e clique em instalar. 

## 6 - Como utilizar

### 6.1 - Principais classes
A SDK tem 3 classes principais que devem estar claras para aqueles que querem consumir. A primeira é a classe `SDKOptions` que tem como principal objetivo centralizar a configuração da SDK. Nela estão contidas configurações como:

- Credenciais de Acesso;
- URL base para APIs de Registro de Arranjo de Pagamento;

Essas configurações serão necessárias dentro de todo o contexto de uso da SDK e são essenciais para o funcionamento como um todo. Abaixo temos a estrutura básica dessa classe:

```cs
namespace TagSDK
{
    public class SDKOptions
    {
        public string BaseUrl { get; set; }
        public Polly.AsyncPolicy DefaultPolicy { get; set; }

        private Dictionary<Profile, TokenInput> Credentials = new Dictionary<Profile, TokenInput>();

        public TokenInput getCredential(Profile profile)
        {
            return this.Credentials[profile];
        }

        public void SetCredential(TokenInput tokenInput, Profile profile)
        {
            this.Credentials[profile] = tokenInput;
        }
    }
}
```

Em segundo lugar temos a classe `TagSDK`, contida no arquivo `EntryPoint.cs`, que serve de ponto de entrada para o uso da SDK. A partir dela criaremos as instâncias dos serviços utilizados para integração com as APIs de Registro de Arranjo de Pagamento.

```cs
public static class TagSdk
    {
        private static TagServiceCollection factory = null;
        public static TagServiceCollection GetServices(Action<SDKOptions> options)
        {
            //lógica de para criação do container abstraído de serviços (TagServiceCollection)
        }

        public static IServiceCollection AddTagSDK(this IServiceCollection services, Action<SDKOptions> options)
        {
            //lógica para registro dos serviços passando um container já criado como parâmetro
        }

        private static void RegisterServices(IServiceCollection services, SDKOptions options)
        {
            //lógica para registro dos serviços
        }
    }
}
```

Por fim, porém não menos importante, temos a classe `TagServiceCollection` também contida no arquivo `EntryPoint.cs` que representa, de fato, o ponto de acesso aos serviços da SDK. Ela recebe a instância de um `IServiceProvider` em seu construtor que de fato faz a recuperação dos serviços previamente registrados. Dentro da classe `TagServiceCollection` estão contidos métodos semânticos para acesso aos serviços obtidos a partir do `IServiceProvider` de uma forma abstraída e simplificada como mostrado no **_snippet_** abaixo:

```cs
 public class TagServiceCollection
    {
        protected readonly IServiceProvider serviceProvider;

        internal TagServiceCollection(IServiceProvider serviceProvider)
        {
            //lógica do construtor
        }

        private Dictionary<Type, IEnumerable<Type>> Validators { get; set; } = new Dictionary<Type, IEnumerable<Type>>();

        public IAuthenticateService AuthenticateService { get => serviceProvider.GetService<IAuthenticateService>(); }
        public IClientService ClienteService { get => serviceProvider.GetService<IClientService>(); }

        public IPaymentSchemeService PaymentSchemeService { get => serviceProvider.GetService<IPaymentSchemeService>(); }

        public IReceivableService ReceivableService { get => serviceProvider.GetService<IReceivableService>(); }

        public IAdvancementService AdvancementService { get => serviceProvider.GetService<IAdvancementService>(); }

        public IHealthCheckService HealthCheckService { get => serviceProvider.GetService<IHealthCheckService>(); }

        public ICommercialEstablishmentService CommercialEstablishmentService { get => serviceProvider.GetService<ICommercialEstablishmentService>(); }

        public INotificationService NotificationService { get => serviceProvider.GetService<INotificationService>(); }

        public IReceivableTransactionService ReceivableTransactionService { get => serviceProvider.GetService<IReceivableTransactionService>(); }

        public ISettlementService ReceivableSettlementService { get => serviceProvider.GetService<ISettlementService>(); }

        public IPositionService PositionService { get => serviceProvider.GetService<IPositionService>(); }
        public IContractService ContractService { get => serviceProvider.GetService<IContractService>(); }
        public IHistoryService HistoryService { get => serviceProvider.GetService<IHistoryService>(); }
        public IConsentService ConsentService { get => serviceProvider.GetService<IConsentService>(); }
    }
}
```

### 6.2 - Exemplo de utilização
A utilização da SDK é bem simples, vamos dividi-la em 4 passos:

- Chamada da classe TagSDK para devolução do container de serviços passando uma instância do SDKOptions como pârametro;
- Chamada e utilização de um serviço simples;
- Chamada de método de serviço que recebe um Profile como parâmetro;
- Tratamento de erros retornados pelos serviços;

Primeiramente vamos instânciar as credênciais de acesso necessárias para realizar chamadas dentro da SDK. Para isso vamos utilizar a classe `TokenInput` que contém em sua estrutura todos os atributos necessários para lidar com autorização nas chamadas da Api de Registro de Arranjo de Pagamento. Em seguida, devemos chamar o método `GetServices(Action<SDKOptions> options)` da classe `TagSDK` passando a nossa configuração como parâmetro. As crêdenciais são inseridas na configuração pelo método `SetCredential(TokenInput tokenInput, Profile profile)` que recebe o objeto do tipo `TokenInput` e um `Profile` relacionado a essas credenciais. A SDK, neste momento, contempla apenas 2 tipos de Profiles, ***Acquirer*** e ***Creditor***, sendo cada um deles único em relação a configuração, ou seja, caso uma nova credencial seja cadastrada com um ***Profile*** já utilizado, esta sobrescreverá a antiga permitindo que tenhamos apenas uma instância de uma credencial do tipo ***Acquirer*** e uma do tipo ***Creditor*** em memória. O método `GetServices` é estático e devolve a instância de um [singleton](https://refactoring.guru/design-patterns/singleton) do tipo `TagServiceCollection` que é o nosso **_container de serviços_**. Caso o **_container de serviços_** esteja vivo em memória o método `GetServices` sempre devolverá o mesmo, caso contrário ele criará um novo **_container_** com instâncias de cada serviço disponível na SDK.

```cs
namespace Consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TokenInput acquirerCredentials = new TokenInput();
            acquirerCredentials.Audience = "example-audience";
            acquirerCredentials.ClientId = "example-client-id-acquirer";
            acquirerCredentials.ClientSecret = "example-client-secret-acquirer";

            TokenInput creditorCredentials = new TokenInput();
            creditorCredentials.Audience = "example-audience";
            creditorCredentials.ClientId = "example-client-id-creditor";
            creditorCredentials.ClientSecret = "example-client-secret-creditor";

            TagServiceCollection fac = TagSdk.GetServices(options =>
            {
                options.BaseUrl = "https://example-url.com.br";
                options.SetCredential(acquirerCredentials, Profile.ACQUIRER);
                options.SetCredential(creditorCredentials, Profile.CREDITOR);
            });

        }
    }
}
```

Na sequência para realizar chamadas a API de Registro de Arranjo de Pagamento devemos invocar a instância de um dos serviços desejados através do nosso **_entrypoint de serviços_** e então fazer uma chamada ao método desejado, passando os parâmetros necessários. No ***snippet*** abaixo é possível observar como realizar uma operação de Registro e Atualização de Ativos Financeiros:

```cs
namespace Consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TagServiceCollection fac = TagSdk.GetServices(options =>
            {
                options.BaseUrl = "https://example-url.com.br";
                options.SetCredential(acquirerCredentials, Profile.ACQUIRER);
                options.SetCredential(creditorCredentials, Profile.CREDITOR);
            });

            BankAccount bankAccount = new BankAccount
            {
                Branch = "1144",
                Account = "13341",
                AccountDigit = "X5",
                AccountType = AccountBankAccountType.CC,
                Ispb = "12345678",
                DocumentType = DocumentType.CNPJ,
                DocumentNumber = "34144310000100"
            };

            Receivable receivable = new Receivable {
                Reference = "UR_450",
                DueDate = DateTime.Parse("2021-01-01T05:00:00Z"),
                PaymentScheme = "VCC",
                OriginalAssetHolderDocumentType = DocumentType.CPF,
                OriginalAssetHolder = "34144310000100",
                Amount = 5000000,
                PrePaidAmount = 0,
                BankAccount =bankAccount };

            string processReference = "PR_550";

            List<Receivable> receivables = new List<Receivable>();
            receivables.Add(receivable);

            ReceivableRequest rI = new ReceivableRequest {
                ProcessReference = processReference,
                Receivables = receivables };

            IReceivableService rService = fac.ReceivableService;

            var result = await rService.RegisterReceivable(rI);

            //leitura do objeto retornado
        }
    }
}
```

Alguns serviços podem ter chamadas com os dois perfis de credenciais diferentes (***Acquirer*** e ***Creditor***). Neste caso é necessário indicar o perfil na chamada do método invocado. O ***code snippet*** mostra isso com a chamada do método `InsertConsents(ConsentRequest consentRequest, Profile profile)`:

```cs
namespace Consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TagServiceCollection fac = TagSdk.GetServices(options =>
            {
                options.BaseUrl = "https://example-url.com.br";
                options.SetCredential(acquirerCredentials, Profile.ACQUIRER);
                options.SetCredential(creditorCredentials, Profile.CREDITOR);
            });

            IConsentService consentService = fac.ConsentService;

            Consent optIn = new Consent();
            optIn.Beneficiary = "00000000000000";
            optIn.AssetHolder = "11111111111111";
            optIn.Acquirer = "22222222222222";
            optIn.PaymentScheme = "VCC";
            optIn.SignatureDate = DateTime.Parse("2021-01-01");
            optIn.StartDate = DateTime.Parse("2021-01-01");
            optIn.EndDate = DateTime.Parse("2021-01-01");

            List<Consent> optIns = new List<Consent>();
            optIns.Add(optIn);

            ConsentRequest consentRequest = new ConsentRequest{
                OptIns = optIns;
            };

           consentService.InsertConsents(ConsentRequest optInRequest, Profile profile);
        }
    }
}
```

Por fim, a SDK disponibiliza uma **_Exception_** especial, chamada `TagSDKException`, que encapsula os erros gerados nas chamadas dos serviços. Essa **_Exception_** pode ser facilmente tratada com um **_Try catch_** e pode retornar 3 tipos de respostas:

- O HTTP Status retornado pela chamada do serviço apenas;
- O HTTP Status e uma mensagem de erro personalizada;
- O HTTP Status, mensagem de erro gerada pela chamada ao serviço e objeto de erro do tipo `ResponseError`
  (que encapsula o erro gerado pela API).

Abaixo podemos visualizar a estrutura das classes `TagSDKException` e `ResponseError`:

```cs
namespace TagSDK.Exceptions
{
    [Serializable]
    public class TagSDKException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public ResponseError Error { get; set; }

        public TagSDKException() { }

        public TagSDKException(string message)
            : base(message) { }

        public TagSDKException(string message, Exception inner)
            : base(message, inner) { }

        public TagSDKException(string message, HttpStatusCode StatusCode, ResponseError error)
            : this(message)
        {
            this.StatusCode = StatusCode;
            this.Error = error;
        }

        //...
    }
}
```

```cs
public class ResponseError
{
    [JsonProperty("errors")]
    public List<string> Errors { get; set; }

    [JsonProperty("processKey")]
    public string ProcessKey { get; set; }

    [JsonProperty("createdAt")]
    public DateTime createdAt { get; set; }
}
```

Em seguida podemos visualizar um exemplo de tratamento de erro:

```cs
public class ResponseError
namespace Consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //recuperação do container de serviços através da classe TagSDK passando SDKOptions como parâmetro
            //recuperação de um serviço através do container de serviços
            //criação do objeto de request - receivableRequest

            try
            {
                var receivableResponse = await receivableService.RegisterReceivable(receivableRequest);
                //lógica de utilização
            }
            catch (TagSDKException e)
            {
                await HandlingTagSDKErrors(e);
            }
        }
    }

    static async void HandlingTagSDKErrors(TagSDKException e)
    {
        if(e.StatusCode == HttpStatusCode.BadRequest)
        {
            if(e.Error != null)
            {
                var returnedError = e.Error;
                foreach(string error in returnedError.Errors) 
                {
                    Console.WriteLine(error);
                }
                Console.WriteLine($"Process Key: {returnedError.ProcessKey}");
                Console.WriteLine($"Created At: {returnedError.createdAt}");
                Console.WriteLine($"HTTP Status: {e.StatusCode}");
                Console.WriteLine($"Erro: ${e.toString()}");
            } 
            else 
                Console.WriteLine($"Erro: ${e.toString()}");
            
        } 
        else 
            Console.WriteLine($"HTTP Status: {e.StatusCode.toString()}");
    }
}
```

## 7 - Testes Integrados/Exemplo de consumo de API no ambiente de Non-Prod
A realização dos ***testes integrados*** demanda credenciais válidas do ambiente de Non-Prod, sendo que essas credenciais são configuradas a partir de um arquivo com extensão ***.json***. Esse arquivo deve possuir a seguinte estrutura:

```json
{
  "creditor":{
    "client_id":"example-acquirer-client-id",
    "client_secret":"example-acquirer-client-secret",
    "audience":"example-acquirer-audience",
    "grant_type":"example-acquirer-grant-type"
  },
  "acquirer":{
    "client_id":"example-creditor-client-id",
    "client_secret":"example-creditor-client-secret",
    "audience":"example-creditor-audience",
    "grant_type":"example-creditor-grant-type"
  }
}
```

O exemplo abaixo que foi extraído da classe `BaseTest` e mostra como o arquivo é consumido:

```cs
var builder = new ConfigurationBuilder()
    .SetBasePath($"{Directory.GetDirectoryRoot("/")}/Configuration")
    .AddJsonFile("appsettings.json");

Configuration = builder.Build();

Dictionary<string, object> creditor = Configuration.GetSection("creditor").Get<Dictionary<string, object>>();
Dictionary<string, object> acquirer = Configuration.GetSection("acquirer").Get<Dictionary<string, object>>();

TokenRequest acquirerCredentials = new TokenRequest();
acquirerCredentials.Audience = (string)acquirer["audience"];
acquirerCredentials.ClientId = (string)acquirer["client_id"];
acquirerCredentials.ClientSecret = (string)acquirer["client_secret"];
```

Por fim, a execução efetiva dos testes pode ser feita através das classes disponibilizadas no ***folder*** ***Testes*** e estas podem ser utilizadas pelo desenvolvedor para validar chamadas, entender o fluxo e debugar o código conforme sua necessidade. O ***snippet*** abaixo mostra a estrutura de uma das classes de teste disponíveis:

```cs
namespace Testes
{
    [TestClass]
    public class AdvancementServiceTest : BaseTest
    {


        IAdvancementService advacementService;
        public AdvancementServiceTest()
        {
            Init();
            advacementService = fac.AdvancementService;
        }

        [TestMethod]
        public async Task insertAdvancementVanillaTest()
        {
            AdvancedReceivable adReceivable = new AdvancedReceivable();
            adReceivable.advancedAmount = 100L;
            adReceivable.paymentScheme = "VCC";
            adReceivable.settlementObligationDate = DateTime.Parse("2021-01-01T05:00:00Z");
            List<AdvancedReceivable> adReceivables = new List<AdvancedReceivable>();
            adReceivables.Add(adReceivable);
            Advancement adItem = new Advancement();
            adItem.assetHolderDocumentType = DocumentType.CNPJ;
            adItem.assetHolder = "74190072000185";
            adItem.operationValue = 100L;
            adItem.operationExpectedSettlementDate = DateTime.Parse("2021-01-01T05:00:00Z");
            adItem.reference = "RF_01";
            adItem.advancedReceivables = adReceivables;
            List<Advancement> adItems = new List<Advancement>();
            adItems.Add(adItem);
            AdvancementRequest adInput = new AdvancementRequest();
            adInput.advancements = adItems;
            var result = await advacementService.InsertAdvancements(adInput);
        }
    }
}
```