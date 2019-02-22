# 在VS Code里使用StyleLint #

> 以下针对的是使用*vue cli*创建的vue项目

1. 安装组件

```shell
npm i -D stylelint
npm i -D stylelint-config-standard
npm i -D stylelint-selector-bem-pattern
npm i -D stylelint-webpack-plugin
```

其中
  `stylelint-config-standard`用于基本样式lint设置
  `stylelint-selector-bem-pattern`用于BEM样式lint
  `stylelint-webpack-plugin`用于在webpack管道中加入对vue/css等文件的处理

2. 安装扩展`stylelint`

3. 在`vue.config.js`中加入以下配置

```js
const StyleLintPlugin = require('stylelint-webpack-plugin');
module.exports = {
  // ... other options
  configureWebpack: {
    plugins: [
      new StyleLintPlugin({
        files: ['**/*.{vue,htm,html,css,sss,less,scss,sass}']
      })
    ]
  }
}
```

4. 在`.stylelintrc`中加入以下配置（或者在`package.json`的`stylelint`项目下）

```json
{
  "extends": [
    "stylelint-config-standard"
  ],
  "plugins": [
    "stylelint-selector-bem-pattern"
  ],
  "rules": {
    "plugin/selector-bem-pattern": {
      "preset": "bem"
    }
  }
}
```


[1]: https://stackoverflow.com/questions/36889258/how-to-make-to-lint-bem-style-using-stylelint-and-stylelint-selector-bem-pattern "How to make to lint BEM-style using stylelint and stylelint-selector-bem-pattern?"
[2]: https://github.com/simonsmith/stylelint-selector-bem-pattern "stylelint-selector-bem-pattern"
[3]: https://github.com/vuejs/vue-loader/issues/303 "A nice way to lint `.vue` files with Stylelint?"
