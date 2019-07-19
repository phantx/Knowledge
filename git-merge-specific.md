# 从一个分支将特定的commits合并到另一个分支

1. 合并某个分支上的单个commit

```shell
git cherry-pick <commit>
```

> 将指定commit复制到当前分支作为一个新的commit
> `cherry-pick`和`merge`类似，如果git不能合并代码改动，比如遇到冲突，需要手动解决冲突再添加commit


2. 合并某个分支上的一系列commits

```shell
git rebase --onto <branch> <commit>
```

> (待研究)
