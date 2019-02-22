# 获取当前域账户的AD信息

> Get the current user's Active Directory details in C# #

```xml
<system.web>
    <authentication mode="Windows" />
</system.web>
```

I can get their pre Windows 2000 user login name (eg: SOMEDOMAIN\someuser) by using
```csharp
string username = HttpContext.Current.Request.ServerVariables["AUTH_USER"];
```

```csharp
System.Security.Principal.WindowsPrincipal p = System.Threading.Thread.CurrentPrincipal as System.Security.Principal.WindowsPrincipal;
string strName = p.Identity.Name;
```

```csharp
string strName = HttpContext.Current.User.Identity.Name.ToString();
```

```csharp
using(DirectoryEntry de = new DirectoryEntry("LDAP://MyDomainController"))
{
    using(DirectorySearcher adSearch = new DirectorySearcher(de))
    {
        adSearch.Filter = "(sAMAccountName=someuser)";
        SearchResult adSearchResult = adSearch.FindOne();
    }
}
```


```csharp
// create a "principal context" - e.g. your domain (could be machine, too)
using(PrincipalContext pc = new PrincipalContext(ContextType.Domain, "YOURDOMAIN"))
{
    // validate the credentials
    bool isValid = pc.ValidateCredentials("myuser", "mypassword");
}
```


[1]: https://stackoverflow.com/questions/637486/how-to-get-the-current-users-active-directory-details-in-c-sharp "How to get the current user's Active Directory details in C#"

[2]: https://stackoverflow.com/questions/290548/validate-a-username-and-password-against-active-directory "Validate a username and password against Active Directory?"

[3]: https://stackoverflow.com/questions/326818/how-to-validate-domain-credentials "How to validate domain credentials?"
