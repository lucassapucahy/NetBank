﻿namespace NetBank.Users.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public int Number { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
    }
}
