﻿using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;

namespace WebCors.Example.Client.Utils
{
    public static class RefreshTokenMonitor
    {
        public static async Task ValidateAsync(CookieValidatePrincipalContext context)
        {
            // Find issued datetime
            var issuedClaim = context.Principal.FindFirst(c => c.Type == JwtRegisteredClaimNames.Iat)?.Value;
            var issuedAt = issuedClaim.ToInt64().ToUnixEpochDate();

            // Find expiration datetime
            var expiresClaim = context.Principal.FindFirst(c => c.Type == JwtRegisteredClaimNames.Exp)?.Value;
            var expiresAt = expiresClaim.ToInt64().ToUnixEpochDate();

            // Calculate how many minutes the token is valid
            var validWindow = (expiresAt - issuedAt).TotalMinutes;

            // Refresh token half way the expiration
            var refreshDateTime = issuedAt.AddMinutes(0.5 * validWindow);

            // Refresh JWT token if needed
            if (DateTime.UtcNow > refreshDateTime)
            {
                // Get original token from claims
                var jwtToken = context.Principal.FindFirst("jwt")?.Value;

                // Pull ClaimManager from Dependency Injection
                var claimPrincipalManager = context.HttpContext.RequestServices.GetService<IClaimPrincipalManager>();

                // Refresh token and claims and expire times
                await claimPrincipalManager.RenewTokenAsync(jwtToken);
            }
        }
    }
}
