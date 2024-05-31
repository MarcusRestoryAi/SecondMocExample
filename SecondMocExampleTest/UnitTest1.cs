using Moq;
using SecondMocExample;

namespace SecondMocExampleTest
{
    public class UserManagerTest
    {

        Mock<IUserDatabase> _dbMock;
        UserManager _manager;

        public UserManagerTest()
        {
            //Skapa ett Mock Repo
            MockRepository mockRepository = new MockRepository(MockBehavior.Strict);

            //Skapa Mock-objekt
            _dbMock = mockRepository.Create<IUserDatabase>();
            _manager = new UserManager(_dbMock.Object);
        }


        [Fact]
        public void GetUserByIdTest()
        {
            //Skapa UserManager
            //UserManager userManager = new UserManager(_dbMock.Object);

            //Setup
            _dbMock.Setup(_dbMock => _dbMock.GetUser(1)).
                Returns(new User(1, "marcus"));

            //Utföra testet
            User response = _manager.GetUserById(1);

            //Assert result
            Assert.Equal("marcus", response.Name);
            Assert.Equal(1, response.Id);
            Assert.Equal("marcus", _manager.CurrentUser.Name);
        }

        [Fact]
        public void SaveUser()
        {
            //setup
            User mockedUser = new User(2, "niklas");
            _dbMock.Setup(_dbMock => _dbMock.SaveUser(mockedUser));

            //Utföra testet
            _manager.SaveUser(mockedUser);

            _dbMock.Verify(_dbMock => _dbMock.SaveUser(mockedUser), Times.Once ); 
        }
    }
}