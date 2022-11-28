

using BeetleX.FastHttpApi;

var ApiServer = new BeetleX.FastHttpApi.HttpApiServer();
ApiServer.Options.LogLevel = BeetleX.EventArgs.LogType.Debug;
ApiServer.Options.LogToConsole = true;
ApiServer.Options.Debug = true;
ApiServer.Options.CrossDomain = new OptionsAttribute { AllowOrigin = "*", AllowHeaders = "*" };
ApiServer.EnableLog(BeetleX.EventArgs.LogType.Debug);
ApiServer.Register(typeof(Program).Assembly);
ApiServer.Options.Host = "0.0.0.0";
ApiServer.Options.Port = 5080; //set listen port to 8014
ApiServer.Options.MaxBodyLength = 10000000;
ApiServer.Options.BufferPoolMaxMemory = 100000000;

ApiServer.Open();//default listen port 9090
Console.Write(ApiServer.BaseServer);
Console.Read();