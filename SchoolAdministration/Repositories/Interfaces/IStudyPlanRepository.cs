using SchoolAdministration.Models;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IStudyPlanRepository
    {
        Task<IEnumerable<StudyPlan>> GetAllAsync();
        Task<StudyPlan?> GetByIdAsync(int id);
        Task AddStudyPlanAsync(StudyPlan studyPlan);
        Task UpdateStudyPlanAsync(StudyPlan studyPlan);
        Task DeleteStudyPlanAsync(int id);
    }
}
