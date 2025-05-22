using Grpc.Core;
using System.Text;
using UserService.Domain.Repositories;

namespace UserService.Application.Services;

public class UserServiceGrpc : UserService.UserServiceBase
{
    private readonly IUserRepository _userRepository;

    public UserServiceGrpc(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task<GetUserByLoginResponse> GetUserByLogin(GetUserByLoginRequest request, ServerCallContext context)
    {
        var user = await _userRepository.GetByLoginAsync(request.Login) 
            ?? throw new RpcException(new Status(StatusCode.NotFound, "User not found"));

        return new GetUserByLoginResponse
        {
            Id = user.Id.ToString(),
            Login = user.Login,
            PasswordHash = Encoding.UTF8.GetString(user.Password),
            CreatedAt = user.CreateDateTime.ToString("o"),
            UpdatedAt = user.EditDateTime.ToString("o")
        };
    }
}
