using SchoolAdministration.Models.Domain;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IStudyPlanPartRepository
    {
        Task<IEnumerable<StudyPlanPart>> GetStudyPlanPartFilterAsync(DateTime start);
        Task<IEnumerable<StudyPlanPart>> GetAllAsync();
        Task<StudyPlanPart?> GetByIdAsync(int id);
        Task AddStudyPlanPartAsync(StudyPlanPart studyPlanPart);
        Task UpdateStudyPlanPartAsync(StudyPlanPart studyPlanPart);
        Task DeleteStudyPlanPartAsync(int id);
    }
}
