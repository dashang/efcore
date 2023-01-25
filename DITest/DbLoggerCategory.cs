// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

public static class DbLoggerCategory
{
    public class ChangeTracking : LoggerCategory<ChangeTracking>
    {
    }
}

public abstract class LoggerCategory<T>
{
    public static string Name { get; } = ToName(typeof(T));

    public override string ToString()
        => Name;
		
    private static string ToName(Type loggerCategoryType)
    {
        const string outerClassName = "." + nameof(DbLoggerCategory);

        var name = loggerCategoryType.FullName!.Replace('+', '.');
        var index = name.IndexOf(outerClassName, StringComparison.Ordinal);
        if (index >= 0)
        {
            name = name[..index] + name[(index + outerClassName.Length)..];
        }

        return name;
    }
}

public class DiagnosticsLogger<TLoggerCategory> : IDiagnosticsLogger<TLoggerCategory>
    where TLoggerCategory : LoggerCategory<TLoggerCategory>, new()
{
	public void Log()
	{
		//var c = new TLoggerCategory();
		//c.ToString();
	}
}

public interface IDiagnosticsLogger<TLoggerCategory> : IDiagnosticsLogger
    where TLoggerCategory : LoggerCategory<TLoggerCategory>, new()
{
	public void Log();
}

public interface IDiagnosticsLogger
{
}