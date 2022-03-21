using Solution.Models;

namespace Solution.BusinessEntities
{
    public class UserBe
    {
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual bool? IsUpdated { get; set; }
        public int EmployeeId { get; set; }
    }
}
