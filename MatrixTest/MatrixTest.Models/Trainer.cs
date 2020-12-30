using System.Collections.Generic;

namespace MatrixTest.Models
{
    /// <summary>
    /// Trainer Model
    /// </summary>
    public class Trainer
    {

        /// <summary>
        /// Unique ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// Email Address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Heroes assigned to trainer
        /// </summary>
        public ICollection<Hero> Heroes { get; set; }
    }
}
