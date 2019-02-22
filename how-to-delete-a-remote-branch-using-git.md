# Git删除远程分支

完整的push命令如下

```bash
git push <remote name> <local branch>:<remote branch>
```

push时，忽略本地分支名，这样来告知远程服务器本地分支没有了，删除远程分支

```bash
git push origin :old-state-with-mean-deviation-from-centre
```

> 注意
>
> 使用`git branch -d -r <branch name>`命令仅仅是删除的本地对该远程分支的track

在**Git v1.7.0**版本后，可以使用另一种语法

```bash
git push origin --delete <branch_name>
```

在**Git v2.8.0**版本后，还可以进一步使用缩略语法

```bash
git push origin -d <branch_name>
```

> 注意
>
> 当远程分支被其他人删除后，本地可能还存在此分支，这时需要使用`git fetch --prune`或者缩略形式`git fetch -p`来删除远程已不存在的track分支


[1]: https://makandracards.com/makandra/621-git-delete-a-branch-local-or-remote "Git: Delete a branch (local or remote)"

[2]: https://stackoverflow.com/questions/2003505/how-do-i-delete-a-git-branch-both-locally-and-remotely "How do I delete a Git branch both locally and remotely?"

[3]: https://stackoverflow.com/questions/17546171/how-to-delete-a-remote-branch-using-git "How to delete a remote branch using Git?"
