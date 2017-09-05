# MicroNetCore.AspNetCore.Extensions
Extensions for AspNetCore.

## MicroNetCore.AspNetCore.ConfigurationExtensions
### Install
Package Manager:
```
PM> Install-Package MicroNetCore.AspNetCore.ConfigurationExtensions -Version 0.0.1-alpha
```
.NET CLI
```
> dotnet add package MicroNetCore.AspNetCore.ConfigurationExtensions --version 0.0.1-alpha
```

### Usage
Call AddSettingsFolder method on IConfigurationBuilder:

```Csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    ...

    // This method adds all JSON and XML files from the default directory ('../Settings/')
    config.AddSettingsFolder();
    
    // This method adds all JSON and XML files from the given directory ('../SampleSettings/')
    config.AddSettingsFolder("SampleSettings");

    ...
})
```

See MicroNetCore.AspNetCore.ConfigurationExtensions.Sample project in samples for more information.
