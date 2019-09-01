# CSS在设置背景图片的同时设置背景透明度


## 利用渐变函数

```css
background-image: url(IMAGE_URL); /* fallback for older browsers */

background-image: linear-gradient(to bottom, rgba(0,0,0,0.6) 0%,rgba(0,0,0,0.6) 100%), url(IMAGE_URL);

/* OR */
background: linear-gradient(rgba(255,255,255,.5), rgba(255,255,255,.5)), url("https://i.imgur.com/xnh5x47.jpg");

```

## 对不同浏览器的前缀兼容

```css
background: -moz-linear-gradient(top, rgba(0, 0, 0, 0.7) 0%, rgba(0, 0, 0, 0.7) 100%), url(bg.png) repeat 0 0, url(https://cdn.sstatic.net/stackoverflow/img/apple-touch-icon.png) repeat 0 0;

background: -moz-linear-gradient(top, rgba(255,255,255,0.7) 0%, rgba(255,255,255,0.7) 100%), url(https://cdn.sstatic.net/stackoverflow/img/apple-touch-icon.png) repeat 0 0;

background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(255,255,255,0.7)), color-stop(100%,rgba(255,255,255,0.7))), url(https://cdn.sstatic.net/stackoverflow/img/apple-touch-icon.png) repeat 0 0;

background: -webkit-linear-gradient(top, rgba(255,255,255,0.7) 0%,rgba(255,255,255,0.7) 100%), url(https://cdn.sstatic.net/stackoverflow/img/apple-touch-icon.png) repeat 0 0;

background: -o-linear-gradient(top, rgba(255,255,255,0.7) 0%,rgba(255,255,255,0.7) 100%), url(https://cdn.sstatic.net/stackoverflow/img/apple-touch-icon.png) repeat 0 0;

background: -ms-linear-gradient(top, rgba(255,255,255,0.7) 0%,rgba(255,255,255,0.7) 100%), url(https://cdn.sstatic.net/stackoverflow/img/apple-touch-icon.png) repeat 0 0;

background: linear-gradient(to bottom, rgba(255,255,255,0.7) 0%,rgba(255,255,255,0.7) 100%), url(https://cdn.sstatic.net/stackoverflow/img/apple-touch-icon.png) repeat 0 0;
```

## 利用伪类的方式避免透明背景影响内容

```css
#main {
    position: relative;
}
#main:after {
    content : "";
    display: block;
    position: absolute;
    top: 0;
    left: 0;
    background-image: url(/wp-content/uploads/2010/11/tandem.jpg); 
    width: 100%;
    height: 100%;
    opacity : 0.2;
    z-index: -1;
}
```

[1]: https://stackoverflow.com/questions/4183948/can-i-set-background-image-and-opacity-in-the-same-property "Can I set background image and opacity in the same property?"
[2]: https://stackoverflow.com/questions/4997493/set-opacity-of-background-image-without-affecting-child-elements "Set opacity of background image without affecting child elements"
