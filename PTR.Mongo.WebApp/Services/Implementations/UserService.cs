
using PTR.Mongo.WebApp.Entities;
using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.Models.Dtos.Responses;
using PTR.Mongo.WebApp.Repositories.Interfaces;
using PTR.Mongo.WebApp.Services.Interfaces;
using AutoMapper;

namespace PTR.Mongo.WebApp.Services.Implementations;

public class UserService(IMapper mapper, IUserRepository userRepository) : IUserService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserResponseDto> Authenticate(AuthenticationRequestDto request)
    {
        User? user = _userRepository.ValidateUser(request);
        if (user is null)
        {
            throw new Exception("Usuario o contraseña incorrecta.");
        }
        return _mapper.Map<UserResponseDto>(user);
    }

    public UserResponseDto CreateUser(CreateUserRequestDto request)
    {
        User requestUser = _mapper.Map<User>(request);
        User createdUser = _userRepository.Create(requestUser);
        return _mapper.Map<UserResponseDto>(createdUser);
    }

    public void DeleteUser(int id)
    {
        _userRepository.Delete(id);
    }

    public IEnumerable<UserResponseDto> GetAll()
    {
        var users = _userRepository.GetAll();
        return _mapper.Map<IEnumerable<UserResponseDto>>(users);
    }

    public UserResponseDto GetById(int id) 
    {
        User? user = _userRepository.GetById(id);
        return _mapper.Map<UserResponseDto>(user);
    }
}