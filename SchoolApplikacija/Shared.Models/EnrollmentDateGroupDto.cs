﻿using System;

namespace SharedModels
{
    public class EnrollmentDateGroupDto
    {
        public DateTime? EnrollmentDate { get; set; }

        public string EnrollmentDateString
        {
            get
            {
                return EnrollmentDate.Value.ToString("MM/dd/yy");
            }
        }

        public int StudentCount { get; set; }
    }
}