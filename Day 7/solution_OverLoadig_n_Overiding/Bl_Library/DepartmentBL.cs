using DAL_Library;
using Overriding_Overloading_model_library;

namespace Bl_Library
{
    public class DepartmentBL
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }
    }
}
