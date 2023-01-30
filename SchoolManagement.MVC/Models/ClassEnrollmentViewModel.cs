﻿using SchoolManagement.MVC.Data;

namespace SchoolManagement.MVC.Models;

public class ClassEnrollmentViewModel
    {
        public Class? Class { get; set; }

    public List<StudentEnrollmentViewModel> Students { get; set; } = new List<StudentEnrollmentViewModel>();
    }
