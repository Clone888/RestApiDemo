// Global settings

Globals = Obj(new
{
    debugOn = true,
    detailedAclDebug = false,
    aclOn = true,
    isSpa = true,
    port = 3001,
    serverName = "Ironboy's Minimal API Server",
    frontendPath = FilePath("..", "Frontend"),
    sessionLifeTimeHours = 2
});

//Server.Start();
WebApp.Utils.RemoveMockUsers();
//WebApp.Utils.CreateMockUsers();
//new WebApp.UtilsTest.TestCreateMockUsers();
//WebApp.Utils.CountDomainsFromUserEmails();


