using WebApplication1.ViewModels;

namespace WebApplication1.Repositories
{
    public interface IPersonRepository
    {
        Task<List<PersonVm>> GetAll();
        Task<PersonVm?> FindById(int personId);
        Task<bool> Add(PersonCreateVm personCreateVm);
        Task<bool> Edit(PersonEditVm personEditVm);
        Task<bool> Delete(int personId);

    }
}
