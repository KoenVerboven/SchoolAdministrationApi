using SchoolAdministration.Models;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IStudyPlanPartRepository
    {
        Task<IEnumerable<StudyPlanPart>> GetAllAsync();
        Task<StudyPlanPart?> GetByIdAsync(int id);
        Task AddStudyPlanPartAsync(StudyPlanPart studyPlanPart);
        Task UpdateStudyPlanPartAsync(StudyPlanPart studyPlanPart);
        Task DeleteStudyPlanPartAsync(int id);
    }
}
