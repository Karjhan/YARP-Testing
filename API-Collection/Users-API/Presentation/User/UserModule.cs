using Carter;
using MediatR;
using Users_API.Application.Users.Commands.CreateUser;
using Users_API.Application.Users.Commands.DeleteUser;
using Users_API.Application.Users.Commands.UpdateUser;
using Users_API.Application.Users.Queries.GetAllUsers;
using Users_API.Application.Users.Queries.GetUserById;
using Users_API.Presentation.User.DTOs;

namespace Users_API.Presentation.User;

public class UserModule : CarterModule
{
    public UserModule() : base("/users")
    {
        
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (CreateUserRequest request, ISender sender) =>
        {
            CreateUserCommand command = request.ToCreateUserCommand();

            var result = await sender.Send(command);

            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
        }).WithTags("user");

        app.MapGet("/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            GetUserByIdQuery query = new GetUserByIdQuery(id);

            var response = await sender.Send(query, cancellationToken);

            return response.IsSuccess ? Results.Ok(response.Value) : Results.BadRequest(response.Error);
        }).WithTags("user");
        
        app.MapGet("/all", async (ISender sender, CancellationToken cancellationToken) =>
        {
            GetAllUsersQuery query = new GetAllUsersQuery();

            var response = await sender.Send(query, cancellationToken);

            return response.IsSuccess ? Results.Ok(response.Value) : Results.BadRequest(response.Error);
        }).WithTags("user");
        
        app.MapDelete("/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            DeleteUserCommand command = new DeleteUserCommand(id);

            var response = await sender.Send(command, cancellationToken);

            return response.IsSuccess ? Results.Ok() : Results.BadRequest(response.Error);
        }).WithTags("user");
        
        app.MapPut("/{id}", async (Guid id, UpdateUserRequest request, ISender sender, CancellationToken cancellationToken) =>
        {
            UpdateUserCommand command = new UpdateUserCommand(
                id,
                request.NewShortName,
                request.NewLongName,
                request.NewDescription,
                request.NewAge
            );

            var response = await sender.Send(command, cancellationToken);

            return response.IsSuccess ? Results.Ok() : Results.BadRequest(response.Error);
        }).WithTags("user");
    }
}