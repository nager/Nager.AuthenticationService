﻿namespace Nager.AuthenticationService.WebApi.Dtos
{
    /// <summary>
    /// Authentication Mfa Token Request Dto
    /// </summary>
    public class AuthenticationMfaTokenRequestDto
    {
        /// <summary>
        /// Mfa Identifier from Authenticate request
        /// </summary>
        public required string MfaIdentifier { get; set; }

        /// <summary>
        /// The one Time Token
        /// </summary>
        public required string Token { get; set; }
    }
}
