using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Interfaces.Employees;

public interface IEmployeeRepository : IRepository<Employee, Employee>
{
    public Task<int> CountAsync();
}
