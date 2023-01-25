// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace DITest;

public class MyService
{
    private readonly DiagnosticsLogger<DbLoggerCategory.ChangeTracking> _dependency;

    public MyService(DiagnosticsLogger<DbLoggerCategory.ChangeTracking> logger)
    {
        _dependency = logger;
		logger.Log();
    }
}
