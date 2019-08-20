# .NET 自动版本

## .NET Framework 

## .NET Core

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.2</TargetFramework>
    <Deterministic>False</Deterministic>
    <AssemblyVersion>2.0.*</AssemblyVersion>
    <FileVersion>3.0.0.0</FileVersion>
  </PropertyGroup>

</Project>
```

## 获取版本

* Assembly Version

```csharp
Version version = Assembly.GetEntryAssembly().GetName().Version;
```

* File Version

```csharp
System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
string version = fvi.FileVersion;
```

[1]: https://github.com/dotnet/sdk/issues/1098 "Question: How to version dotnet core assemblies"
[2]: https://stackoverflow.com/questions/909555/how-can-i-get-the-assembly-file-version "How can I get the assembly file version"
[3]: https://stackoverflow.com/questions/42138418/equivalent-to-assemblyinfo-in-dotnet-core-csproj "Equivalent to AssemblyInfo in dotnet core/csproj"
