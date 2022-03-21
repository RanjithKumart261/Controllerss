using Solution.Models;

namespace Solution.Repositories
{
    public class UserRepository : userRepository<User>
    {
        

        public UserRepository(string connectionString)
            : base(Helper.OpenSession(connectionString))
        {

        }

        public new IEnumerable<User> GetAll()
        {
            var data = Session.Query<User>().ToList();
            return data;
        }

        public new void Update(User user)
        {
            user.IsUpdated = true;
            Session.Update(user);
            Session.Flush();
        }

        public new User Create(User user)
        {
            Session.Save(user);
            Session.Flush();
            return user;
        }

        public new bool Delete(int id)
        {
            var user = Session.Query<User>().FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                Session.Delete(user);
                Session.Flush();
                return true;
            }

            throw new Exception("Invalid 'UserId' provided");
        }
    }
 }

