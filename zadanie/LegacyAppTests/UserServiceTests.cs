using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]//@Test
    public void AddUser_Should_Return_False_When_Email_Without_At_Or_Dot()
    {
        //arrange
        string firstName = "John";
        string lastName = "Doe";
        DateTime birthdate = new DateTime(1998, 1, 1);
        int clientId = 1;
        string email = "doe";
        var service = new UserService();
        //act
        bool result = service.AddUser(firstName, lastName, email, birthdate, clientId);
        //assert
        Assert.Equal(false,result);

    }
    [Fact]
    public void AddUser_Should_Return_False_When_Name_Is_Null()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser(null, null, "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }
    [Fact]
    public void AddUser_Should_Return_False_When_Younger_Than_21()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Doe", "kowalski@wp.pl", new DateTime(2010, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }
    [Fact]
    public void AddUser_Should_Return_True_When_Important_Client()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Smith", "smith@gmail.pl", new DateTime(1980, 1, 1), 3);

        //Assert
        Assert.Equal(true, result);
    }
    [Fact]
    public void AddUser_Should_Return_True_When_Normal_Client()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Kwiatkowski", "kwiatkowski@wp.pl", new DateTime(1980, 1, 1), 5);

        //Assert
        Assert.Equal(true, result);
    }
    [Fact]
    public void AddUser_Should_Return_True_When_Very_Important_Client()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Malewski", "kowalski@wp.pl", new DateTime(1980, 1, 1), 2);

        //Assert
        Assert.Equal(true, result);
    }
    [Fact]
    public void AddUser_Should_Throw_Exception_When_User_Does_Not_Exist()
    {
        //Arrange
        var service = new UserService();

        Assert.Throws<ArgumentException>(() =>
        {
            service.AddUser("John", "Doe", "johndoe@gmail.com", new DateTime(1980, 1, 1), 100);
        });
    }
    [Fact]
    public void AddUser_Should_Throw_Exception_When_User_Has_No_Credit_Limit()
    {
        //Arrange
        var service = new UserService();

        Assert.Throws<ArgumentException>(() =>
        {
            service.AddUser("John", "Andrzejewicz", "andrzejewicz@wp.pl", new DateTime(1980, 1, 1), 6);
        });
    }
}