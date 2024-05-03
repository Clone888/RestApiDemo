using Xunit;
namespace WebApp;

public class UtilsTest
{
    [Fact]
    public void TestSumInt()
    {
        Assert.Equal(12, Utils.SumInts(7, 5));
    }

    [Fact]
    public void TestCreateMockUsers()
    {
        // Read all mock-users from JSON-file
        var read = File.ReadAllText(Path.Combine("json", "mock-users.json"));
        Arr mockUsers = JSON.Parse(read);


        // Get all users from database
        Arr usersInDb = SQLQuery("SELECT email FROM users");

        Arr emailsInDb = usersInDb.Map(user => user.email);

        // Only keep the users not already in DB
        Arr mockUsersNotInDb = mockUsers.Filter(mockUser => !emailsInDb.Contains(mockUser.email));

        // Assert that the CreateMockUsers olny return
        // newly created users in the DB.

        var result = Utils.CreateMockUsers();

        // Log("by test", mockUsersNotInDb);
        // Log("by method", result);

        // Assert the same length

        // Assert.Equal(mockUsersNotInDb.Length, result.Length);

        // Check equal for each user
        for (var i = 0; i < result.Length; i++)
        {
            Assert.Equal
           (
             JSON.Stringify(result[i]),
             JSON.Stringify(mockUsersNotInDb)
            );
        }
    }

    [Fact]
    public void TestIsPasswordGoodEnough()
    {
                bool strongPassword = Utils.IsPasswordGoodEnough("Password1!");
        Assert.True(strongPassword);
    }
}