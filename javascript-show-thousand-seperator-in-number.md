# Javascript格式化数字显示千分位

## 最简形式，使用内置函数
```javascript
(1234567.89).toLocaleString('en')              // for numeric input
parseFloat("1234567.89").toLocaleString('en')  // for string input

// to display fraction digits
(1234567.00).toLocaleString("en", { minimumFractionDigits: 2 })
```

# 手写格式化
```javascript
function addCommas(nStr) {
    nStr += '';
    var x = nStr.split('.');
    var x1 = x[0];
    var x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
}
```

将格式化后的字符串转为数字
```javascript
parseFloat("1,234,567.89".replace(/,/g,''))
```

[1]: https://stackoverflow.com/questions/3753483/javascript-thousand-separator-string-format "Javascript Thousand Separator / string format"
