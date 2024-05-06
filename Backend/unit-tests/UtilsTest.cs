using Xunit;
using Xunit.Abstractions;

namespace WebApp;
public class UtilsTest
{
    // The following lines are needed to get 
    // output to the Console to work in xUnit tests!
    // (also needs the using Xunit.Abstractions)
    // Note: You need to use the following command line command 
    // dotnet test --logger "console;verbosity=detailed"
    // for the logging to work
    private readonly ITestOutputHelper output;
    public UtilsTest(ITestOutputHelper output)
    {
        this.output = output;
    }

    /*
        [Fact]
        // A simple initial example
        public void TestSumInt()
        {
            Assert.Equal(12, Utils.SumInts(7, 5));
            Assert.Equal(-3, Utils.SumInts(6, -9));
        }

        [Fact]
        public void TestCreateMockUsers()
        {
            // Read all mock users from the JSON file
            var read = File.ReadAllText(FilePath("json", "mock-users.json"));
            Arr mockUsers = JSON.Parse(read);
            // Get all users from the database
            Arr usersInDb = SQLQuery("SELECT email FROM users");
            Arr emailsInDb = usersInDb.Map(user => user.email);
            // Only keep the mock users not already in db
            Arr mockUsersNotInDb = mockUsers.Filter(
                mockUser => !emailsInDb.Contains(mockUser.email)
            );
            // Get the result of running the method in our code
            var result = Utils.CreateMockUsers();
            // Assert that the CreateMockUsers only return
            // newly created users in the db
            output.WriteLine($"The test expected that {mockUsersNotInDb.Length} users should be added.");
            output.WriteLine($"And {result.Length} users were added.");
            output.WriteLine("The test also asserts that the users added " +
                "are equivalent (the same) to the expected users!");
            Assert.Equivalent(mockUsersNotInDb, result);
            output.WriteLine("The test passed!");
        }
    /*
        [Fact]
        public void TestIsPasswordGoodEnough()
        {
            bool strongPassword = Utils.IsPasswordGoodEnough("Password1?!");
            Assert.True(strongPassword);
        }


            [Fact]
            public void TestRemoveBadWords()
            {
                var input = ("your asshole");
                var read = File.ReadAllText(FilePath("json", "bad-words.json"));
                Arr badWordsList = JSON.Parse(read);

                var result = Utils.RemoveBadWords();

                output.WriteLine($"{input}");
                output.WriteLine($"And filter text {result}");

                Assert.Equivalent(input, result);
                output.WriteLine("The test passed!");
            }
        

    [Theory]
    [InlineData("Hi your asshole", "[***]", "Hi your [***]")]

    public void RemoveBadWordsAlt(string text, string censor, string expected)
    {
        var result = Utils.RemoveBadWordsAlt(text, censor);
        Assert.Equal(expected, result);
    }
*/


    
        [Fact]
        public void TestRemoveMockUsers()
        {
            //read a JSON-file
            var read = File.ReadAllText(FilePath("json", "mock-users.json"));
            Arr mockUsers = JSON.Parse(read);

            //sql query
            Arr usersInDb = SQLQuery("SELECT email FROM users");

            // Create a list of users based on user-email
            Arr emailsInDb = usersInDb.Map(user => user.email);

            // filter and only keep the mockusers email already in db
            Arr mockUsersInDb = mockUsers.Filter(mockUser => emailsInDb.Contains(mockUser.email));

            Arr mockUserEmail = mockUsersInDb.Map(user => user.email);

            //get result from function
            var result = Utils.RemoveMockUsers();

            //jämför mockUsersInDb med resultatet från Utils.RemoveMockUsers
            Assert.Equivalent(mockUsersInDb, result);
        }
    

}