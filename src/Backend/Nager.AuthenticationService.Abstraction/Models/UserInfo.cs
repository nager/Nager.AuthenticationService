﻿using System;

namespace Nager.AuthenticationService.Abstraction.Models
{
    public class UserInfo
    {
        public string Id { get; set; }

        public string EmailAddress { get; set; }

        public string[]? Roles { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public DateTime? LastFailedValidationTimestamp { get; set; }

        public DateTime? LastSuccessfulValidationTimestamp { get; set; }

        public bool MfaActive { get; set; }
    }
}
