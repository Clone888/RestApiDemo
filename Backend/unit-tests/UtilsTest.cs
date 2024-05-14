namespace WebApp;
public class UtilsTest(Xlog output)
{

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


    [Theory]
    [InlineData("abC9#fgh", true)]  // ok
    [InlineData("stU5/xyz", true)]  // ok too
    [InlineData("abC9#fg", false)]  // too short
    [InlineData("abCd#fgh", false)] // no digit
    [InlineData("abc9#fgh", false)] // no capital letter
    [InlineData("abC9efgh", false)] // no special character
    public void IsPasswordGoodEnough(string password, bool expected)
    {
        Assert.Equal(expected, Utils.IsPasswordGoodEnough(password));
    }




    [Theory]
    [InlineData("Hi your asshole", "[***]", "Hi your [***]")]
    [InlineData("Hi your asshole I think you are a bitch", "[***]", "Hi your [***] I think you are a [***]")]


    public void RemoveBadWordsAlt(string text, string censor, string expected)
    {
        var result = Utils.RemoveBadWordsAlt(text, censor);
        Assert.Equal(expected, result);
    }




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

        output.WriteLine($"The test expected that {mockUsersInDb.Length} users should be REMOVED.");
        //Print all users that being removed without password
        output.WriteLine($"And {JSON.Stringify(result)} users were REMOVED.");

        //jämför mockUsersInDb med resultatet från Utils.RemoveMockUsers
        Assert.Equivalent(mockUsersInDb, result);
    }


    /*
        [Fact]
        public void TestCountDomainsFromUserEmails()
        {
            Arr users = SQLQuery("SELECT * FROM users");
            Obj domainsInDB = Obj();

            foreach (var user in users)
            {
                string domain = user.email.Split('@')[1];

                if (!domainsInDB.HasKey(domain))
                {
                    domainsInDB[domain] = 1;
                }
                else
                {
                    domainsInDB[domain]++;
                }
            }
            Assert.Equivalent(domainsInDB, Utils.CountDomainsFromUserEmails());
        }
        */
}