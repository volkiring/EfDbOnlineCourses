﻿using EfDbOnlineCourses;
using Microsoft.AspNetCore.Mvc;

namespace DbWebApplication.Controllers
{
	public class CourseTeachersController : Controller
	{
		private readonly ICoursesRepository coursesRepository;
		private readonly ITeachersRepository teachersRepository;

		public CourseTeachersController(ICoursesRepository coursesRepository, ITeachersRepository teachersRepository)
		{
			this.coursesRepository = coursesRepository;
			this.teachersRepository = teachersRepository;
		}

		public IActionResult Index(int courseId)
		{
			var course = coursesRepository.TryGetById(courseId);
			return View(course);
		}
		public IActionResult AddTeacherToCourse(int courseId)
		{
			var course = coursesRepository.TryGetById(courseId);
			var teachers = teachersRepository.GetAll().Where(t => !t.Courses.Contains(course)).ToList();
			return View((course, teachers));
		}

		public IActionResult ConfirmAddTeacherToCourse(int courseId, int teacherId)
		{
			var teacher = coursesRepository.TryGetById(courseId);
			var student = teachersRepository.TryGetById(teacherId);
			coursesRepository.AddTeacherToCourse(teacher, student);
			return RedirectToAction("Index", new { courseId });
		}

		public IActionResult DeleteTeacherToCourse(int courseId, int teacherId)
		{
			var course = coursesRepository.TryGetById(courseId);
			var teacher = teachersRepository.TryGetById(teacherId);
			coursesRepository.DeleteTeacherToCourse(course, teacher);
			return RedirectToAction("Index", new { courseId });
		}
	}
}
