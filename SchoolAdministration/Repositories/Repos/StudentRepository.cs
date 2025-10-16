using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Specifications;

namespace SchoolAdministration.Repositories.Repos
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var studentInDb = await _context.Students.FindAsync(id) ?? throw new KeyNotFoundException($"Student with id {id} was not found.");
            _context.Students.Remove(studentInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<IEnumerable<StudentCourseDTO>> GetStudentCoursesAsync(int studentId)                
        {
            var studentCourses = await _context.Students.Include(p => p.Courses)//todo : add inculde for payments
                                                        .Where(p=>p.Id == studentId)
                                                        .ToListAsync();
            var studentCoursesList = new List<StudentCourseDTO>();

            foreach (var studentCourse in studentCourses)
            {
                var studentFirstname = studentCourse.LastName;
                var studentLastname = studentCourse.FirstName;

                foreach (Course course in studentCourse.Courses)
                {
                    var studentCourseDTO = new StudentCourseDTO()
                    {
                        StudentId = studentId,
                        StudentLastName = studentLastname,
                        StudentFirstName = studentFirstname,
                        CourseId = course.Id,
                        CourseName = course.CourseName,
                        CourseStartDate = course.StartDate,
                        CourseEndDate = course.EndDate,
                        TotalAmount = course.CoursePrice,
                        FullyPaid = null
                    };
                    studentCoursesList.Add(studentCourseDTO);
                }
            }
            return studentCoursesList;
        }

        public async Task<IEnumerable<StudentExamsResultDTO>> GetStudentExamResultsAsync()
        {
            var studentExamResults =  await _context.Students.Include(p=>p.ExamResults).ToListAsync();
            var studentExamResultList  = new List<StudentExamsResultDTO>();

            foreach (var studentExamResult in studentExamResults)
            {
                var firstname = studentExamResult.FirstName;
                var lastname = studentExamResult.LastName;
                var studentEmail = studentExamResult.Email;
               
                foreach (ExamResult examResult in studentExamResult.ExamResults)
                {
                    var exam =  _context.Exams.SingleOrDefault(p=>p.Id == examResult.ExamId);
                    var studentExamResultId = examResult.Id;
                    var examResultScore = examResult.ExamenResultScore;
                    var studentExamResul = new StudentExamsResultDTO()
                    {
                        Id = studentExamResultId,
                        StudentLastName = lastname,
                        StudentFirstName = firstname,
                        StudentEmail = studentEmail,
                        ExamName = exam.ExamTitle, 
                        ExamenResult = (double)examResultScore,
                        MaxScore = exam.MaxScore,
                        MinScoreToPassExam = exam.MinScoreToPassExam
                    };
                    studentExamResultList.Add(studentExamResul);
                }

            }
            return studentExamResultList;
        }


        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetByNameStartWithAsync(string name)
        {
            return await _context.Students.Where(p => (p.LastName.ToLower() + " " + p.FirstName).Contains(name.ToLower())).ToListAsync();
        }

        public bool StudentExist(Student student)
        {
            return  _context.Students.Any(p => p.LastName.Trim().ToLower().Equals(student.LastName.Trim().ToLower()) 
                                                                   && p.FirstName.Trim().ToLower().Equals(student.FirstName.Trim().ToLower())
                                                                   && p.DateOfBirth.Equals(student.DateOfBirth)
                                                                   );
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public Task<int> CountAsync()
        {
            return _context.Students.CountAsync();
        }

        public Task<int> CountFilterAsync(string? Name, string? Email, int ZipCode)
        {
            IQueryable<Student> students;

            students = _context.Students;

            if (Name is not null)
            {
                if (Name.Trim() != string.Empty)
                {
                    students = students.Where(p => (p.LastName.ToLower() + " " + p.FirstName).Contains(Name.ToLower())).AsQueryable();
                }
            }

            if (Email is not null)
            {
                if (Email.Trim() != string.Empty)
                {
                    students = students.Where(p => (p.Email.ToLower()).Contains(Email.ToLower())).AsQueryable();
                }
            }

            if (ZipCode > 0)
            {
                students = students.Where(p => p.Zipcode == ZipCode).AsQueryable();
            }

            return students.CountAsync();
        }




        //public async Task<IEnumerable<Student>> GetFilterAsync1(StudentSpecParams studentSpecParams)
        //{
        //    IQueryable<Student> students;

        //    students = _context.Students;

        //    if(studentSpecParams.Name is not null)
        //    {
        //        if (studentSpecParams.Name.Trim() != string.Empty)
        //        {
        //            students = students.Where(p => (p.LastName.ToLower() + " " + p.FirstName).Contains(studentSpecParams.Name.ToLower())).AsQueryable();
        //        }
        //    }

        //    if(studentSpecParams.Email is not null)
        //    {
        //        if (studentSpecParams.Email.Trim() != string.Empty)
        //        {
        //            students = students.Where(p => (p.Email.ToLower()).Contains(studentSpecParams.Email.ToLower())).AsQueryable();
        //        }
        //    }

        //    if (studentSpecParams.ZipCode > 0)
        //    {
        //        students =students.Where(p => p.Zipcode == studentSpecParams.ZipCode).AsQueryable();
        //    }

        //    students = studentSpecParams.Sort.ToLower() switch
        //    {
        //        "id" =>  students.OrderBy(p => p.Id).AsQueryable(),
        //        "id_desc" => students.OrderByDescending(p => p.Id).AsQueryable(),
        //        "name" =>   students.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).AsQueryable(),
        //        "name_desc" => students.OrderByDescending(p => p.LastName).ThenBy(p => p.FirstName).AsQueryable(),
        //        "email" =>  students.OrderBy(p => p.Email).AsQueryable(),
        //        "email_desc" => students.OrderByDescending(p => p.Email).AsQueryable(),
        //        "phone" =>  students.OrderBy(p => p.Phone).AsQueryable(),
        //        "phone_desc" => students.OrderByDescending(p => p.Phone).AsQueryable(),
        //        "zipcode" => students.OrderBy(p => p.Zipcode).AsQueryable(),
        //        "zipcode_desc" => students.OrderByDescending(p => p.Zipcode).AsQueryable(),
        //        "dateofbirth" => students.OrderBy(p => p.DateOfBirth).AsQueryable(),
        //        "dateofbirth_desc" => students.OrderByDescending(p => p.DateOfBirth).AsQueryable(),
        //        "gender" => students.OrderBy(p => p.Gender).AsQueryable(),
        //        "gender_desc" => students.OrderByDescending(p => p.Gender).AsQueryable(),
        //         _ => students.OrderBy(p => p.Id).AsQueryable(),
        //    };

        //    if (studentSpecParams.PageSize > 0)
        //    {
        //        if (studentSpecParams.PageSize > 30)
        //        {
        //            studentSpecParams.PageSize = 30;
        //        }

        //        students = students.Skip(studentSpecParams.PageSize * (studentSpecParams.PageNumber - 1)).Take(studentSpecParams.PageSize);
        //    }

        //    return await students.ToListAsync();
        //}


        public async Task<IEnumerable<Student>> GetFilterAsync(string? Name,string? Email, int ZipCode, string Sort, int PageSize, int PageNumber)
        {
            IQueryable<Student> students;

            students = _context.Students;

            if (Name is not null)
            {
                if (Name.Trim() != string.Empty)
                {
                    students = students.Where(p => (p.LastName.ToLower() + " " + p.FirstName).Contains(Name.ToLower())).AsQueryable();
                }
            }

            if (Email is not null)
            {
                if (Email.Trim() != string.Empty)
                {
                    students = students.Where(p => (p.Email.ToLower()).Contains(Email.ToLower())).AsQueryable();
                }
            }

            if (ZipCode > 0)
            {
                students = students.Where(p => p.Zipcode == ZipCode).AsQueryable();
            }

            students = Sort.ToLower() switch
            {
                "id" => students.OrderBy(p => p.Id).AsQueryable(),
                "id_desc" => students.OrderByDescending(p => p.Id).AsQueryable(),
                "name" => students.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).AsQueryable(),
                "name_desc" => students.OrderByDescending(p => p.LastName).ThenBy(p => p.FirstName).AsQueryable(),
                "email" => students.OrderBy(p => p.Email).AsQueryable(),
                "email_desc" => students.OrderByDescending(p => p.Email).AsQueryable(),
                "phone" => students.OrderBy(p => p.Phone).AsQueryable(),
                "phone_desc" => students.OrderByDescending(p => p.Phone).AsQueryable(),
                "zipcode" => students.OrderBy(p => p.Zipcode).AsQueryable(),
                "zipcode_desc" => students.OrderByDescending(p => p.Zipcode).AsQueryable(),
                "dateofbirth" => students.OrderBy(p => p.DateOfBirth).AsQueryable(),
                "dateofbirth_desc" => students.OrderByDescending(p => p.DateOfBirth).AsQueryable(),
                "gender" => students.OrderBy(p => p.Gender).AsQueryable(),
                "gender_desc" => students.OrderByDescending(p => p.Gender).AsQueryable(),
                _ => students.OrderBy(p => p.Id).AsQueryable(),
            };

            if (PageSize > 0 && PageNumber > 0)
            {
                if (PageSize > 30)
                {
                    PageSize = 30;
                }

                students = students.Skip(PageSize * (PageNumber - 1)).Take(PageSize);
            }

            return await students.ToListAsync();
        }
    }



}
