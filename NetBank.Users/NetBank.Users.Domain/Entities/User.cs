using NetBank.Users.Domain.Enums;

namespace NetBank.Users.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool Status { get; set; }
        public long DocumentNumber { get; set; }
        public RequestType RequestType { get; set; }
        public Address? Address { get; set; }
        public int AddressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        /// <summary>
        /// If is fullage returns true.
        /// If is 17 years old but the anniversary is this month we consider as fullage.
        /// </summary>
        /// <returns></returns>
        public bool IsFullAge() 
        {
            var isSeventen = DateTime.Now.Year - BirthDate.Year == 17;

            if (!isSeventen)
                return DateTime.Now.Year - BirthDate.Year >= 18;

            if (BirthDate.Month >= DateTime.Now.Month)
                return true;

            return false;
        }

    }
}
