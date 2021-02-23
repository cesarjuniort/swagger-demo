using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleSwagger.Models
{    
    /// <summary>
    /// Data model / DTO for Day of the Week used in the API for scheduling.
    /// </summary>
    public class TheDayOfTheWeek
    {
        /// <summary>
        /// This is the Name of the day in English.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This is the Ordinal Position of the day of the week as exists in the Microsoft Office Dates funcitons.
        /// </summary>
        public int Number { get; set; }
    }
}
