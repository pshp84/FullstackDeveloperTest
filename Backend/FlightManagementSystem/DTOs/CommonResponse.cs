﻿using System.ComponentModel.DataAnnotations;

namespace FlightManagementSystem.DTOs
{
    public class CommonResponse
    {
        public Status? Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }

    public enum Status
    { 
        Success = 1, 
        Error = 2
    }
}