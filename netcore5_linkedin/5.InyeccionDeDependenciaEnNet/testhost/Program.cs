using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
//



namespace testhost
{
    class Program
    {
        static async Task Main(string[] args)
        {
           var hostBuilder = new HostBuilder();
          
          //cuales objectos que se utilicen a travez de la injection de dependencias
          hostBuilder.ConfigureServices((context, services) => {
            //Dependen del ciclo de vida de los objetos que estamos registrando.
                   //addscoped
                   //addsinglenton
                   //addTransient
                //solo va a ver una instancia en todo el ciclo de vida de la app
                services.AddSingleton<ITest, Test>();
                services.AddSingleton<IHostedService, MyService>();


          });

           await hostBuilder.RunConsoleAsync();

        }
    }

    interface ITest {
     void Run();
    }
    class Test : ITest {
        public void Run(){
            System.Console.WriteLine("Hello lim");
        }
    }

    class MyService: IHostedService  {
 
        private readonly ITest test;

        public MyService(ITest test){
                this.test = test;
        }
        public Task StartAsync(CancellationToken cancellationToken) {

            test.Run();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken){
           return Task.CompletedTask;
        }

    }

}
