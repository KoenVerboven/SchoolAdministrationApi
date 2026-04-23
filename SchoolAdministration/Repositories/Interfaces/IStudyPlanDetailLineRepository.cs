using SchoolAdministration.Models.Domain.Student;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IStudyPlanDetailLineRepository
    {
        Task<IEnumerable<StudyPlanDetailLine>> GetStudyPlanDetailLinesFilterAsync(DateTime start);
        Task<IEnumerable<StudyPlanDetailLine>> GetAllAsync();
        Task<StudyPlanDetailLine?> GetByIdAsync(int id);
        Task AddStudyPlanDetailLineAsync(StudyPlanDetailLine studyPlanDetailLine);
        Task UpdateStudyPlanDetailLineAsync(StudyPlanDetailLine studyPlanDetailLine);
        Task DeleteStudyPlanDetailLineAsync(int id);
    }
}
