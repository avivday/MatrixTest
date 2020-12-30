

using MatrixTest.Models.Enums;
using System;

namespace MatrixTest.Models
{
    /// <summary>
    /// Hero Model
    /// </summary>
    public class Hero
    {
        /// <summary>
        /// unique ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Hero Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Guid
        /// </summary>
        public Guid GuidID { get; set; }

        /// <summary>
        /// Ability
        /// </summary>
        public Ability Ability { get; set; }

        /// <summary>
        /// Suit color
        /// </summary>
        public string SuitColor { get; set; }

        /// <summary>
        /// Starting Power
        /// </summary>
        public decimal StartingPower { get; set; }

        /// <summary>
        /// Current Power
        /// </summary>
        public decimal CurrentPower { get; set; }

        /// <summary>
        /// First Training Date
        /// </summary>
        public DateTimeOffset? FirstTrainingDate { get; set; }

        /// <summary>
        /// Last Time Trained
        /// </summary>
        public DateTimeOffset? LastTrainingDate { get; set; }

        /// <summary>
        /// Number of training sessions today
        /// </summary>
        public byte? TrainingSessionsToday { get; set; }

        /// <summary>
        /// Trainer
        /// </summary>
        public Trainer Trainer { get; set; }

        /// <summary>
        /// Trainer ID FK
        /// </summary>
        public int TrainerID { get; set; }
    }
}

