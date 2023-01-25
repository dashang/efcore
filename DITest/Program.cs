// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using DITest;

var sc = new ServiceCollection();
sc.AddSingleton<MyService>();
sc.AddSingleton(typeof(DiagnosticsLogger<>));
var sp = sc.BuildServiceProvider();

//var t = typeof(LoggerCategory<>);
//Console.WriteLine(t.ToString());

var service = sp.GetRequiredService<MyService>();
