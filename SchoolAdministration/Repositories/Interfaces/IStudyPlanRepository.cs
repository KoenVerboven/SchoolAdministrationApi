using SchoolAdministration.Models.Domain.Student;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IStudyPlanRepository
    {
        Task<IEnumerable<StudyPlan>> GetAllAsync();
        Task<StudyPlan?> GetByIdAsync(int id);
        Task<IEnumerable<StudyPlan>> GetStudyPlansByStudentId(int studentId);
        Task AddStudyPlanAsync(StudyPlan studyPlan);
        Task UpdateStudyPlanAsync(StudyPlan studyPlan);
        Task DeleteStudyPlanAsync(int id);
        Task<int> CountAsync();
    }
}
