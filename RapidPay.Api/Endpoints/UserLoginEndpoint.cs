using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Authorization;
using RapidPay.Api.Contracts.Requests;

namespace RapidPay.Api.Endpoints;

[HttpPost("login")]
[AllowAnonymous]
public class UserLoginEndpoint : Endpoint<LoginRequest>
{
    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        if (req.Username == "admin" && req.Password == "pass")
        {
            var jwtToken = JWTBearer.CreateToken(
                "9C5FE0ED928BA25C2D1CDD14071393BB8494DD9F",
                DateTime.UtcNow.AddDays(1),
                claims: new[] {("Username", req.Username), ("UserID", "001")},
                roles: new[] {"Admin"},
                permissions: new[] {"CreateCards", "Payments"});

            await SendAsync(new
            {
                req.Username,
                Token = jwtToken
            }, cancellation: ct);
        }
        else
        {
            ThrowError("The supplied credentials are invalid!");
        }
    }
}