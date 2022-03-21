using Solution.Models;

namespace Solution.Repositories
{
    public class EmployeeRepository : userRepository<User>
    {
        private string v;
        public EmployeeRepository(string connectionString)
           : base(Helper.OpenSession(connectionString))
        {

        }

        public EmployeeRepository(NHibernate.ISession session) : base(session)
        {

        }

 
        public new IEnumerable<User> GetAll()
        {
            var data = Session.Query<User>()
                .Where(u => u.IsUpdated == null || u.IsUpdated == false);
            return data;
        }

        public new void Update(User user)
        {
            user.IsUpdated = true;
            Session.Update(user);
            Session.Flush();
        }

        internal Task CreateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        internal Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        internal Task UpdateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        internal Task DeleteAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        internal Task<Employee> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
