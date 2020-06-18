using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcServer.Web.Data;
using GrpcServer.Web.Protos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Google.Protobuf.WellKnownTypes;

namespace GrpcServer.Web.Services
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MyEmployeeService : EmployeeService.EmployeeServiceBase
    {
        private readonly ILogger<MyEmployeeService> _logger;
        private readonly JwtTokenValidationService _jwtTokenValidationService;

        public MyEmployeeService(ILogger<MyEmployeeService> logger, JwtTokenValidationService jwtTokenValidationService)
        {
            _logger = logger;
            _jwtTokenValidationService = jwtTokenValidationService;
        }
        
        [AllowAnonymous]//允许匿名访问
        public override async Task<TokenResponse> CreateToken(
            TokenRequest request, ServerCallContext context)
        {
            var userModel = new UserModel 
            { 
                UserName = request.Username,
                Password = request.Password
            };
            var response = await _jwtTokenValidationService.GenerateTokenAsync(userModel);

            if (response.Succes)
            {
                return new TokenResponse 
                {
                    Token = response.Token,
                    Expiration = Timestamp.FromDateTime(response.Expiration),
                    Succes = true
                };
            }
            return new TokenResponse
            {
                Succes = false
            };
        }

        public override Task<EmployeeResponse> GetByNo(
            GetByNoRequest request, ServerCallContext context)
        {
            try//异常处理
            {
                //if (true)
                //{
                //    var trailer = new Metadata 
                //    {
                //        {"Field", "No"},
                //        {"Message", "Something wnt wrong"}
                //    };
                //    throw new RpcException(new Status(StatusCode.DataLoss, "Data is lost"),
                //        trailer);
                //}

                var md = context.RequestHeaders;
                foreach (var pair in md)
                {
                    _logger.LogInformation($"{ pair.Key}: { pair.Value}");
                }

                var employee = InMemoryData.Employees.SingleOrDefault(x => x.No == request.No);
                if (employee != null)
                {
                    var response = new EmployeeResponse
                    {
                        Employee = employee
                    };

                    return Task.FromResult(response);
                }
            }
            catch (RpcException re)
            {
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new RpcException(Status.DefaultCancelled, e.Message);               
            }

            throw new Exception($"Employee not found with no: {request.No}");
        }

        public override async Task GetAll(
            GetAllRequest request,
            IServerStreamWriter<EmployeeResponse> responseStream,
            ServerCallContext context)
        {
            foreach (var employee in InMemoryData.Employees)
            {
                await responseStream.WriteAsync(new EmployeeResponse
                {
                    Employee = employee
                });
            }
        }

        public override async Task<AddPhotoResponse> AddPhoto(
            IAsyncStreamReader<AddPhotoRequest> requestStream,
            ServerCallContext context)
        {
            Metadata md = context.RequestHeaders;
            foreach (var pair in md)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            var data = new List<byte>();
            while (await requestStream.MoveNext())
            {
                Console.WriteLine($"Received: {requestStream.Current.Data.Length} bytes");
                data.AddRange(requestStream.Current.Data);
            }

            Console.WriteLine($"Received file with {data.Count} bytes");
            return new AddPhotoResponse
            {
                IsOk = true
            };
        }

        public override async Task SaveAll(
            IAsyncStreamReader<EmployeeRequest> requestStream,
            IServerStreamWriter<EmployeeResponse> responseStream,
            ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                var employee = requestStream.Current.Employee;

                lock (this)
                {
                    InMemoryData.Employees.Add(employee);
                }
                await responseStream.WriteAsync(new EmployeeResponse
                {
                    Employee = employee
                });
            }

            Console.WriteLine("Employees:");
            foreach (var employee in InMemoryData.Employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
