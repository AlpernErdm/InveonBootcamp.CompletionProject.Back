﻿namespace InveonBootcamp.CompletionProject.Core.Dtos.JwtAuth
{
    public class GenerateTokenRequest
    {
        public string Email { get; set; } = default!;
        public Guid UserId { get; set; }
    }
}
