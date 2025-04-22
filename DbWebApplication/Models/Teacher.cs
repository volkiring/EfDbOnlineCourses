﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDbOnlineCourses
{
	public class Teacher
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Email { get; set; }
		public string? Specialty { get; set; }
		public List<CourseViewModel> Courses { get; set; } = new();
	}
}
