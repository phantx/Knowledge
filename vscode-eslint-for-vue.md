# 在VS Code里使用ESLint #

> 以下针对的是使用*vue cli*创建的vue项目

1. 在`vue.config.js`中启用

> Lint-on-save during development with eslint-loader is enabled by default. It can be disabled with the lintOnSave option in vue.config.js:

```js
module.exports = {
  lintOnSave: false
}
```

> When set to true, eslint-loader will emit lint errors as warnings. By default, warnings are only logged to the terminal and does not fail the compilation.

2. 安装扩展`Vetur`和`ESLint`
3. 在VS Code的配置中，将`vue`加入到`eslint.validate`，参见[手册][1]

```json
{
  "eslint.validate": [
    "javascript",
    "javascriptreact",
    {
      "language": "vue",
      "autoFix": true
    }
  ]
}
```
or

```json
{
  "eslint.validate": [
    "javascript",
    "javascriptreact",
    "vue"
  ]
}
```

4. 加入`JavaScript Standard Style`配置项，参见[项目地址][2]

```shell
npm install eslint-config-standard
```   

并在`.eslintrc`中加入以下配置（或者在`package.json`的`eslintConfig`项目下）

```json
{
  "extends": "standard"
}
```

> `eslint-config-`将会自动被ESLint添加

[1]: https://vuejs.github.io/vetur/linting-error.html#error-checking
[2]: https://github.com/standard/eslint-config-standard
