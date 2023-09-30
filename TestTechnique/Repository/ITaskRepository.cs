

namespace TestTechnique.Repository;

public interface ITaskRepository
{
    Task<IEnumerable<Taches>> GetTask();
    Task<Taches> GetTaskById(int taskId);
    Task<Taches> AddTask(Taches tache);
    Task<Taches> UpdateTask(Taches tache);
    void DeleteTask (int tacheId);
}
