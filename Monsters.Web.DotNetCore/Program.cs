﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Monsters.Web.DotNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseWebRoot("wwwroot")
                .Build();
    }
}
