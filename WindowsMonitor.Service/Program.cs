﻿using System;
using System.Collections;
using System.Linq;
using System.Management;
using System.Reflection;
using WindowsMonitor.Win32.Hardware;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WindowsMonitor.Service
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
                .Build();
    }
}
