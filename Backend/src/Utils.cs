using System.Security.Cryptography.X509Certificates;

namespace WebApp;
public static class Utils
{
    public static int SumInts(int a, int b)
    {
        return a + b;
    }

    public static Arr CreateMockUsers()
    {
        // Read all mock users from the JSON file
        var read = File.ReadAllText(FilePath("json", "mock-users.json"));
        Arr mockUsers = JSON.Parse(read);
        Arr successFullyWrittenUsers = Arr();
        foreach (var user in mockUsers)
        {
            var result = SQLQueryOne(
                @"INSERT INTO users(firstName,lastName,email,password)
                VALUES($firstName, $lastName, $email, $password)
            ", user);
            // If we get an error from the DB then we haven't added
            // the mock users, if not we have so add to the successful list
            if (!result.HasKey("error"))
            {
                // The specification says return the user list without password
                user.Delete("password");
                successFullyWrittenUsers.Push(user);
            }
        }
        return successFullyWrittenUsers;
    }


    public static bool IsPasswordGoodEnough(string password)
    {
        bool strongPassword = false;
        if (password.Length > 7)
        {
            if (password.ToCharArray().Any(char.IsSymbol) || password.ToCharArray().Any(char.IsPunctuation)
            && password.ToCharArray().Any(char.IsUpper)
            && password.ToCharArray().Any(char.IsLower)
            && password.ToCharArray().Any(char.IsDigit))
            {
                strongPassword = true;
            }
        }
        else
        {
            strongPassword = false;
        }
        return strongPassword;
    }




    public record TestBadWords(List<string> badwords);

    public static string RemoveBadWordsAlt(string inputWord, string replacementWord)
    {
        var readBadWords = File.ReadAllText(FilePath("json", "bad-words.json"));
        var badwords = JsonSerializer.Deserialize<TestBadWords>(readBadWords);

        foreach (var word in badwords.badwords.OrderByDescending(x => x.Length))
        {
            inputWord = inputWord.Replace(word, replacementWord, StringComparison.InvariantCultureIgnoreCase);
        }

        return inputWord;
    }


    public static Arr RemoveMockUsers()
    {
        // Read all mock users from the JSON file
        var read = File.ReadAllText(FilePath("json", "mock-users.json"));
        Arr mockUsers = JSON.Parse(read);
        Arr successRemovedUsers = Arr();

        Arr usersInDb = SQLQuery("SELECT email FROM users");

        // Create a list of users based on user-email
        Arr emailsInDb = usersInDb.Map(user => user.email);

        // filter and only keep the mockusers email already in db
        Arr mockUsersInDb = mockUsers.Filter(mockUser => emailsInDb.Contains(mockUser.email));

        foreach (var user in mockUsersInDb)
        {
            var removeUser = SQLQuery(
                @"DELETE FROM users WHERE
                email = $email
                ", user);

            successRemovedUsers.Push(user);
        }
        return successRemovedUsers;
    }

    /*
        public static Obj CountDomainsFromUserEmails()
        {
            Arr domainsInDB = SQLQueryOne("SELECT SUBSTR(email, INSTR(email, '@') + 1) AS domain,COUNT(id) AS count FROM users GROUP BY domain;");
            Obj domainsCounted = Obj();

            foreach (var email in domainsInDB)
            {
                if (email.domain != null)
                {
                domainsCounted[email.domain] = email.id;
                }
            }
            Log(domainsInDB);
            return domainsCounted;
        }
    
    public static Obj CountDomainsFromUserEmails()
    {
        Arr users = SQLQueryOne("SELECT SUBSTRING(email, INSTR(email, '@') + 1, length(email) AS domain, count(id) AS id FROM users GROUP BY domain");
        Obj domainsCounted = new Obj();
        foreach (var email in users)
        {
            domainsCounted[email.domain] = email.id;
        }
        return domainsCounted;
    }

*/

}