# C#获取枚举值的DescriptionAttribute内容

```csharp
public static string GetDescription<T>(this T source)
{
    FieldInfo fi = source.GetType().GetField(source.ToString());

    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
        typeof(DescriptionAttribute), false);

    if (attributes != null && attributes.Length > 0) 
        return attributes[0].Description;
    else 
        return source.ToString();
}
```

```csharp
// In Enums.NET you'd use:

string description = ((MyEnum)value).AsString(EnumFormat.Description);
```

[1]: https://stackoverflow.com/questions/2650080/how-to-get-c-sharp-enum-description-from-value "How to get C# Enum description from value? "
[2]: https://stackoverflow.com/questions/1799370/getting-attributes-of-enums-value "Getting attributes of Enum's value"
[3]: https://github.com/TylerBrinkley/Enums.NET "Enums.NET is a high-performance type-safe .NET enum utility library"

