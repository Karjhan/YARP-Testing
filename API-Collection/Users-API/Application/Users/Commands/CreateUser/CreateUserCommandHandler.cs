using Commons.Primitives;
using Reports_API.Application.Abstractions;
using Users_API.Domain.Abstractions;
using Users_API.Domain.Entities;
using Users_API.Domain.Primitives;

namespace Users_API.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateUserCommand>
{
    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Guid userId = Guid.NewGuid();
        Name userName = new Name(request.ShortName, request.LongName);

        User newUser = User.Create(userId, userName, request.Description ?? string.Empty, request.Age);
        userRepository.Add(newUser);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}