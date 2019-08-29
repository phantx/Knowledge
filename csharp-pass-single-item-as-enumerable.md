# 如何将单个对象转换为IEnumerable<T>

```csharp
public static class IEnumerableExt
{
    /// <summary>
    /// Wraps this object instance into an IEnumerable&lt;T&gt;
    /// consisting of a single item.
    /// </summary>
    /// <typeparam name="T"> Type of the object. </typeparam>
    /// <param name="item"> The instance that will be wrapped. </param>
    /// <returns> An IEnumerable&lt;T&gt; consisting of a single item. </returns>
    public static IEnumerable<T> Yield<T>(this T item)
    {
        yield return item;
    }
}
```


```csharp
new T[] { item }
// or
new [] { item }
```


```csharp
public static IEnumerable<T> ToEnumerable<T>(params T[] items)
{
    return items;
}  
```

[1]: https://stackoverflow.com/questions/1577822/passing-a-single-item-as-ienumerablet "Passing a single item as IEnumerable<T>"
