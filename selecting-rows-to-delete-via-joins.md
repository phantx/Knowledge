# MSSQL根据多表联查结果删除数据

```sql
DELETE FROM TableA 
FROM
   TableA a
   INNER JOIN TableB b
      ON b.BId = a.BId
      AND [my filter condition]
```

[1]: https://stackoverflow.com/questions/439750/t-sql-selecting-rows-to-delete-via-joins "T-SQL: Selecting rows to delete via joins"
