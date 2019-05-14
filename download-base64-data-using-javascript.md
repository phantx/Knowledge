# js 下载base64内容

```js
var blob = new Blob([tdData], { type: 'text/csv' });
if (window.navigator.msSaveBlob) { // // IE hack; see http://msdn.microsoft.com/en-us/library/ie/hh779016.aspx
    window.navigator.msSaveOrOpenBlob(blob, 'exportData' + new Date().toDateString() + '.csv');
}
else {
    var a = window.document.createElement("a");
    a.href = window.URL.createObjectURL(blob, { type: "text/plain" });
    a.download = "exportData" + new Date().toDateString() + ".csv";
    a.click();  // IE: "Access is denied"; see: https://connect.microsoft.com/IE/feedback/details/797361/ie-10-treats-blob-url-as-cross-origin-and-denies-access
}
```

[1]: https://stackoverflow.com/questions/37203771/download-base64-data-using-javascript-ie11
[2]: https://stackoverflow.com/questions/48754185/ie11-downloading-base64-documents
[3]: https://www.jianshu.com/p/cb79c64da33d
