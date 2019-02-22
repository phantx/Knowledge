# C#首字母大写方法

```csharp
/// <summary>
/// Returns the input string with the first character converted to uppercase
/// </summary>
public static string FirstLetterToUpperCase(this string s)
{
        if (string.IsNullOrEmpty(s))
                throw new ArgumentException("There is no first letter");

        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
}
```

[1]: https://stackoverflow.com/questions/4135317/make-first-letter-of-a-string-upper-case-with-maximum-performance/27073919#27073919 "Make first letter of a string upper case (with maximum performance)"

