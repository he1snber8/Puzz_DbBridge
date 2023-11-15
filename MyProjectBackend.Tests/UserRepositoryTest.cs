using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;
using MyProjectBackend.Tests.AdditionalLogic.EqualityComparers;

namespace MyProjectBackend.Tests

{
    public class UserRepositoryTest : RepositoryBaseTest<User,IUserRepository>
    {
        public UserRepositoryTest(IUnitOfWork unitOfWork, IUserRepository repository) : base(unitOfWork, repository) { }

        protected override User CreateEntity() {

            int indx = Random.Shared.Next(5, 1000);

            return new User()
            {
                Username = $"testUsername{indx}",
                Email = $"testMail{indx}",
                Password = $"testPswrd{indx}"
            };
                
         }

        protected override User UpdateEntity(User user)
        {
            int indx = Random.Shared.Next(5, 1000);

            user.Username = $"testUsername{indx} updated!!";

            return user;
             
        }

        protected override void DeleteEntityTest() => base.DeleteEntityTest();

        public override void InsertEntityTest() => base.InsertEntityTest();

        protected override void UpdateEntityTest() => base.UpdateEntityTest();

    }
}


