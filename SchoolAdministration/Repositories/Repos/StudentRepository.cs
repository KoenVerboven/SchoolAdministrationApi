using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Dtos;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

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

    }
}
