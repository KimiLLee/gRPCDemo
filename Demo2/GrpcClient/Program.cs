using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer.Web.Protos;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        private static string _token;
        private static DateTime _expiration = DateTime.MinValue;

        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("Client starting");

            using var channel = GrpcChannel.ForAddress("https://localhost:5001",
                new GrpcChannelOptions
                {
                    LoggerFactory = new SerilogLoggerFactory()
                });
            var client = new EmployeeService.EmployeeServiceClient(channel);

            var option = 1;//int.Parse(args[0]);

            switch (option)
            {
                case 1://jwt验证，数据中心对外
                    await GetByNoAsync(client);
                    break;
                case 2:
                    await GetAllAsync(client);
                    break;
                case 3:
                    await AddPhotoAsync(client);
                    break;
                case 5:
                    await SaveAllAsync(client);
                    break;
            }

            Console.ReadKey();

            Log.CloseAndFlush();
        }

        //判断是否需要获取token
        private static bool NeedToken() => string.IsNullOrEmpty(_token) || _expiration > DateTime.UtcNow;


        public static async Task GetByNoAsync(EmployeeService.EmployeeServiceClient client)
        {
            try//异常处理
            {
                if (!NeedToken() || await GetTokenAsync(client))
                {
                    var headers = new Metadata
                    {
                        {"Authorization", $"Bearer {_token}" }
                    };

                    var response = await client.GetByNoAsync(new GetByNoRequest
                    {
                        No = 1994
                    }, headers);
                    Console.WriteLine($"Response messages: {response}");
                }

            }
            catch (RpcException e)
            {
                if (e.StatusCode == StatusCode.DataLoss)
                {
                    Log.Logger.Error($"{e.Trailers}");
                }
                Log.Logger.Error(e.Message);
            }
        }

        private static async Task<bool> GetTokenAsync(EmployeeService.EmployeeServiceClient client)
        {
            var request = new TokenRequest
            {
                Username = "admin",
                Password = "1234"
            };
            var response = await client.CreateTokenAsync(request);
            if (response.Succes)
            {
                _token = response.Token;
                _expiration = response.Expiration.ToDateTime();
                return true;
            }
            return false;
        }



        public static async Task GetAllAsync(EmployeeService.EmployeeServiceClient client)
        {
            using var call = client.GetAll(new GetAllRequest());
            var responseStream = call.ResponseStream;
            while (await responseStream.MoveNext())
            {
                Console.WriteLine(responseStream.Current.Employee);
            }
        }



        public static async Task AddPhotoAsync(EmployeeService.EmployeeServiceClient client)
        {
            var md = new Metadata
            {
                {"username", "dave" },
                {"role", "administrator" }
            };
            FileStream fs = File.OpenRead("1.jpg");
            using var call = client.AddPhoto(md);

            var stream = call.RequestStream;

            while (true)
            {
                byte[] buffer = new byte[2048];
                int numRead = await fs.ReadAsync(buffer, 0, buffer.Length);
                if (numRead == 0)
                {
                    break;
                }
                if (numRead < buffer.Length)
                {
                    Array.Resize(ref buffer, numRead);
                }
                await stream.WriteAsync(new AddPhotoRequest()
                {
                    Data = ByteString.CopyFrom(buffer)
                });
            }

            await stream.CompleteAsync();
            var res = await call.ResponseAsync;

            Console.WriteLine(res.IsOk);
        }



        public static async Task SaveAllAsync(EmployeeService.EmployeeServiceClient client)
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    No = 111,
                    FirstName = "CC",
                    LastName = "DD",
                MonthSalary = new MonthSalary
                {
                    Basic = 5000f,
                    Bouns = 125.5f
                },
                Status = EmployeeStatus.Normal,
                LastModified = Timestamp.FromDateTime(DateTime.UtcNow)
                },
                new Employee
                {
                    No = 222,
                    FirstName = "CAC",
                    LastName = "DDT",
                MonthSalary = new MonthSalary
                {
                    Basic = 5000f,
                    Bouns = 125.5f
                },
                Status = EmployeeStatus.Normal,
                LastModified = Timestamp.FromDateTime(DateTime.UtcNow)
                }
            };

            using var call = client.SaveAll();
            var requestStream = call.RequestStream;
            var responseStream = call.ResponseStream;

            var responseTask = Task.Run(async () =>
            {
                while (await responseStream.MoveNext())
                {
                    Console.WriteLine($"Saved: {responseStream.Current.Employee}");
                }
            });

            foreach (var employee in employees)
            {
                await requestStream.WriteAsync(new EmployeeRequest
                {
                    Employee = employee
                }); ;
            }

            await requestStream.CompleteAsync();
            await responseTask;
        }
    }
}
