# EntityFramework.SqlServer 部署时未复制到目标文件夹

问题发生情形为：项目A引用了项目B，项目B复制数据访问，引入了EntityFramework。
当编译或部署项目A时，B中的EntityFramework.dll被复制到了A的生成目录，但是EntityFramework.SqlServer.dll却没能被复制，导致运行时报错。

When a type cannot be loaded for a DLL that is referenced in a project, it usually means that it has not been copied to the output bin/ directory. When we are not using a type from a referenced library, it will not be copied. That's expected behaviour. Usually, we just need to set the dlls Copy Local to be true, however, for the EntityFramework.SqlServer.dll it is not enough, a solution is to set a type reference as:

```csharp
public abstract class DomainContext : DbContext
{
    static DomainContext()
    {
        var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
    }
}
```


[1]: https://social.msdn.microsoft.com/Forums/en-US/b348a0c2-94d9-4db5-a041-b81a97e76b3f/entityframeworksqlserver-not-deploying?forum=adodotnetentityframework "EntityFramework.SqlServer not deploying"
