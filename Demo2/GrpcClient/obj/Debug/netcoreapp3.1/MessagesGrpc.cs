// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Messages.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcServer.Web.Protos {
  public static partial class EmployeeService
  {
    static readonly string __ServiceName = "EmployeeService";

    static readonly grpc::Marshaller<global::GrpcServer.Web.Protos.GetByNoRequest> __Marshaller_GetByNoRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.Web.Protos.GetByNoRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcServer.Web.Protos.EmployeeResponse> __Marshaller_EmployeeResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.Web.Protos.EmployeeResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcServer.Web.Protos.GetAllRequest> __Marshaller_GetAllRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.Web.Protos.GetAllRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcServer.Web.Protos.AddPhotoRequest> __Marshaller_AddPhotoRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.Web.Protos.AddPhotoRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcServer.Web.Protos.AddPhotoResponse> __Marshaller_AddPhotoResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.Web.Protos.AddPhotoResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcServer.Web.Protos.EmployeeRequest> __Marshaller_EmployeeRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.Web.Protos.EmployeeRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcServer.Web.Protos.TokenRequest> __Marshaller_TokenRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.Web.Protos.TokenRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcServer.Web.Protos.TokenResponse> __Marshaller_TokenResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.Web.Protos.TokenResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::GrpcServer.Web.Protos.GetByNoRequest, global::GrpcServer.Web.Protos.EmployeeResponse> __Method_GetByNo = new grpc::Method<global::GrpcServer.Web.Protos.GetByNoRequest, global::GrpcServer.Web.Protos.EmployeeResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetByNo",
        __Marshaller_GetByNoRequest,
        __Marshaller_EmployeeResponse);

    static readonly grpc::Method<global::GrpcServer.Web.Protos.GetAllRequest, global::GrpcServer.Web.Protos.EmployeeResponse> __Method_GetAll = new grpc::Method<global::GrpcServer.Web.Protos.GetAllRequest, global::GrpcServer.Web.Protos.EmployeeResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetAll",
        __Marshaller_GetAllRequest,
        __Marshaller_EmployeeResponse);

    static readonly grpc::Method<global::GrpcServer.Web.Protos.AddPhotoRequest, global::GrpcServer.Web.Protos.AddPhotoResponse> __Method_AddPhoto = new grpc::Method<global::GrpcServer.Web.Protos.AddPhotoRequest, global::GrpcServer.Web.Protos.AddPhotoResponse>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "AddPhoto",
        __Marshaller_AddPhotoRequest,
        __Marshaller_AddPhotoResponse);

    static readonly grpc::Method<global::GrpcServer.Web.Protos.EmployeeRequest, global::GrpcServer.Web.Protos.EmployeeResponse> __Method_Save = new grpc::Method<global::GrpcServer.Web.Protos.EmployeeRequest, global::GrpcServer.Web.Protos.EmployeeResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Save",
        __Marshaller_EmployeeRequest,
        __Marshaller_EmployeeResponse);

    static readonly grpc::Method<global::GrpcServer.Web.Protos.EmployeeRequest, global::GrpcServer.Web.Protos.EmployeeResponse> __Method_SaveAll = new grpc::Method<global::GrpcServer.Web.Protos.EmployeeRequest, global::GrpcServer.Web.Protos.EmployeeResponse>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "SaveAll",
        __Marshaller_EmployeeRequest,
        __Marshaller_EmployeeResponse);

    static readonly grpc::Method<global::GrpcServer.Web.Protos.TokenRequest, global::GrpcServer.Web.Protos.TokenResponse> __Method_CreateToken = new grpc::Method<global::GrpcServer.Web.Protos.TokenRequest, global::GrpcServer.Web.Protos.TokenResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateToken",
        __Marshaller_TokenRequest,
        __Marshaller_TokenResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcServer.Web.Protos.MessagesReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for EmployeeService</summary>
    public partial class EmployeeServiceClient : grpc::ClientBase<EmployeeServiceClient>
    {
      /// <summary>Creates a new client for EmployeeService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public EmployeeServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for EmployeeService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public EmployeeServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected EmployeeServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected EmployeeServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::GrpcServer.Web.Protos.EmployeeResponse GetByNo(global::GrpcServer.Web.Protos.GetByNoRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetByNo(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::GrpcServer.Web.Protos.EmployeeResponse GetByNo(global::GrpcServer.Web.Protos.GetByNoRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetByNo, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcServer.Web.Protos.EmployeeResponse> GetByNoAsync(global::GrpcServer.Web.Protos.GetByNoRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetByNoAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcServer.Web.Protos.EmployeeResponse> GetByNoAsync(global::GrpcServer.Web.Protos.GetByNoRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetByNo, null, options, request);
      }
      /// <summary>
      ///ServerStreaming
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncServerStreamingCall<global::GrpcServer.Web.Protos.EmployeeResponse> GetAll(global::GrpcServer.Web.Protos.GetAllRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAll(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///ServerStreaming
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncServerStreamingCall<global::GrpcServer.Web.Protos.EmployeeResponse> GetAll(global::GrpcServer.Web.Protos.GetAllRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetAll, null, options, request);
      }
      /// <summary>
      ///ClientStreaming
      /// </summary>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncClientStreamingCall<global::GrpcServer.Web.Protos.AddPhotoRequest, global::GrpcServer.Web.Protos.AddPhotoResponse> AddPhoto(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddPhoto(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///ClientStreaming
      /// </summary>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncClientStreamingCall<global::GrpcServer.Web.Protos.AddPhotoRequest, global::GrpcServer.Web.Protos.AddPhotoResponse> AddPhoto(grpc::CallOptions options)
      {
        return CallInvoker.AsyncClientStreamingCall(__Method_AddPhoto, null, options);
      }
      public virtual global::GrpcServer.Web.Protos.EmployeeResponse Save(global::GrpcServer.Web.Protos.EmployeeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Save(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::GrpcServer.Web.Protos.EmployeeResponse Save(global::GrpcServer.Web.Protos.EmployeeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Save, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcServer.Web.Protos.EmployeeResponse> SaveAsync(global::GrpcServer.Web.Protos.EmployeeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SaveAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcServer.Web.Protos.EmployeeResponse> SaveAsync(global::GrpcServer.Web.Protos.EmployeeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Save, null, options, request);
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::GrpcServer.Web.Protos.EmployeeRequest, global::GrpcServer.Web.Protos.EmployeeResponse> SaveAll(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SaveAll(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::GrpcServer.Web.Protos.EmployeeRequest, global::GrpcServer.Web.Protos.EmployeeResponse> SaveAll(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_SaveAll, null, options);
      }
      public virtual global::GrpcServer.Web.Protos.TokenResponse CreateToken(global::GrpcServer.Web.Protos.TokenRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateToken(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::GrpcServer.Web.Protos.TokenResponse CreateToken(global::GrpcServer.Web.Protos.TokenRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateToken, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcServer.Web.Protos.TokenResponse> CreateTokenAsync(global::GrpcServer.Web.Protos.TokenRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateTokenAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcServer.Web.Protos.TokenResponse> CreateTokenAsync(global::GrpcServer.Web.Protos.TokenRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateToken, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override EmployeeServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new EmployeeServiceClient(configuration);
      }
    }

  }
}
#endregion