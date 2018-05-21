﻿using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using WindowsMonitor.Hardware.Processors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class WmiBulkTest
    {
        [TestMethod]
        public void TestNoEmptyClasses()
        {
            var types = typeof(Win32Processor).Assembly.GetTypes();

            foreach (var type in types)
            {
                if(type.GetProperties().Length == 0)
                    throw new Exception(type.Name);
            }
        }

        [TestMethod]
        public void BulkTest()
        {
            var types = typeof(Win32Processor).Assembly.GetTypes();

            foreach (var type in types)
            {
                var info = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                var method = info.FirstOrDefault(x => x.Name == "Retrieve" && x.GetParameters().Length == 0);

                try
                {
                    if (method == null) continue;
                    var res = method.Invoke(null, new object[] { }) as IEnumerable;

                    foreach (var item in res)
                    {
                        //Empty beacusa here we don't care of the actual value, just the fact that method success
                    }
                    System.Diagnostics.Debug.WriteLine(type.Name);
                }
                catch (InvalidCastException)
                {
                    throw new Exception(type.Name);
                }
                catch (Exception e)
                {
                    var n = e.GetType().Name;
                    throw new Exception(n);
                }
            }
        }
    }
}
