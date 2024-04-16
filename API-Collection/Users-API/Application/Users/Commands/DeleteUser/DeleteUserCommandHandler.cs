using Commons.Exceptions;
using Commons.Primitives;
using Users_API.Application.Abstractions;
using Users_API.Domain.Abstractions;

namespace Users_API.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<DeleteUserCommand>
{
    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure(new Error(
                "Member.NotFound",
                $"The member with Id {request.UserId} was not found"
            ));
        }

        userRepository.Remove(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}