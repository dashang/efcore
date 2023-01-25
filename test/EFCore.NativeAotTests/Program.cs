// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore.NativeAotTests;

using var context = new NativeAotContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

context.Add(new User { Name = "John" });
context.SaveChanges();

#pragma warning disable IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
Console.WriteLine("Hello, World! " + context.Users.First().Id);
#pragma warning restore IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
