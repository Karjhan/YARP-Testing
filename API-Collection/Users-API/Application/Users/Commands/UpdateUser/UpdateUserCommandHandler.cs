using Commons.Exceptions;
using Commons.Primitives;
using Reports_API.Application.Abstractions;
using Users_API.Domain.Abstractions;
using Users_API.Domain.Primitives;

namespace Users_API.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserCommand>
{
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure(new Error(
                "Member.NotFound",
                $"The member with Id {request.UserId} was not found"
            ));
        }

        user.Update(
            new Name(request.NewShortName, request.NewLongName), 
            request.NewDescription, 
            request.NewAge);
        userRepository.Update(user);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}