# Javascript在Enter按下时处理为Tab的行为

```javascript
// Works in IE 9+ and modern browsers.
document.addEventListener('keydown', function (event) {
  if (event.keyCode === 13 && event.target.nodeName === 'INPUT') {
    var form = event.target.form;
    var index = Array.prototype.indexOf.call(form, event.target);
    form.elements[index + 1].focus();
    event.preventDefault();
  }
});
```

[1]: https://stackoverflow.com/questions/1009808/enter-key-press-behaves-like-a-tab-in-javascript "Enter key press behaves like a Tab in Javascript"

