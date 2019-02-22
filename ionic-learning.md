# Ionic Learning #

- [Ionic Learning](#ionic-learning)
    - [Native - Device](#native---device)
        - [Android](#android)
            - [ANDROID_ID](#android_id)
            - [DEVICE_ID](#device_id)
            - [MAC ADDRESS](#mac-address)
            - [SIM Serial Number](#sim-serial-number)
            - [Serial Number](#serial-number)
            - [Installation ID](#installation-id)
        - [iOS](#ios)

## Native - Device ##

> Refer to **cordova-plugin-device** - [Ionic Document](https://ionicframework.com/docs/native/device/) - [GitHub](https://github.com/apache/cordova-plugin-device)

插件直接返回一个对象，包含设备多项属性。特别对其中的device.uuid进行分析

### Android ###

#### ANDROID_ID ####

这个是插件Native代码的实现

```java
// import android.provider.Settings.Secure;
Secure.getString(getContext().getContentResolver(), Secure.ANDROID_ID);
```

来自[官方文档的描述](https://developer.android.com/reference/android/provider/Settings.Secure.html#ANDROID_ID)

> On Android 8.0 (API level 26) and higher versions of the platform, a 64-bit number (expressed as a hexadecimal string), unique to each combination of app-signing key, user, and device. Values of ANDROID_ID are scoped by signing key and user. The value may change if a factory reset is performed on the device or if an APK signing key changes. For more information about how the platform handles ANDROID_ID in Android 8.0 (API level 26) and higher, see Android 8.0 Behavior Changes.
> 
> In versions of the platform lower than Android 8.0 (API level 26), a 64-bit number (expressed as a hexadecimal string) that is randomly generated when the user first sets up the device and should remain constant for the lifetime of the user's device. On devices that have multiple users, each user appears as a completely separate device, so the ANDROID_ID value is unique to each user.
> 

**注意**

1. 厂商定制系统
    - 不同的设备可能会产生相同的ANDROID_ID: 9774d56d682e549c
    - 有些设备返回的值为null
2. 设备差异
    - 对于CDMA设备，ANDROID_ID和TelephonyManager.getDeviceId() 返回相同的值

其它可以作为设备/应用标识的

#### DEVICE_ID ####

这是Android系统为开发者提供的用于标识手机设备的串号，也是各种方法中普适性较高的，可以说几乎所有的设备都可以返回这个串号，并且唯一性良好。它会根据不同的手机设备返回IMEI，MEID或者ESN码

```java
TelephonyManager tm = (TelephonyManager)getSystemService(Context.TELEPHONY_SERVICE); 
String DEVICE_ID = tm.getDeviceId(); 
```

**注意**

1. 非手机设备
    最开始搭载Android系统都手机设备，而现在也出现了非手机设备：如平板电脑、电子书、电视、音乐播放器等。这些设备没有通话的硬件功能，系统中也就没有TELEPHONY_SERVICE，自然也就无法通过上面的方法获得DEVICE_ID。
2. 权限
    获取DEVICE_ID需要`READ_PHONE_STATE`权限，如果只是为了获取DEVICE_ID而没有用到其他的通话功能，申请这个权限一来大才小用，二来部分用户会怀疑软件的安全性。
3. 厂商定制系统
    少数手机设备上，由于该实现有漏洞，会返回无用信息，如:zeros(全零`0`)或者asterisks(全星号`*`)

#### MAC ADDRESS ####
可以使用手机Wifi或蓝牙的MAC地址作为设备标识，但是并不推荐这么做

**注意**

1. 硬件限制
    并不是所有的设备都有Wifi和蓝牙硬件，硬件不存在自然也就得不到这一信息。
2. 获取的限制
    如果Wifi没有打开过，是无法获取其Mac地址的；而蓝牙是只有在打开的时候才能获取到其Mac地址。

#### SIM Serial Number ####

装有SIM卡的设备，可以通过下面的方法获取

```java
TelephonyManager tm = (TelephonyManager)getSystemService(Context.TELEPHONY_SERVICE); 
String SimSerialNumber = tm.getSimSerialNumber(); 
```

**注意**

1. 对于CDMA设备，返回的是一个空值

#### Serial Number ####

Android系统2.3版本以上可以得到Serial Number，且非手机设备也可以通过该接口获取

```java
String serialNumber = android.os.Build.SERIAL;
```

来自[官方文档的描述](https://developer.android.com/reference/android/os/Build.html#SERIAL)

> A hardware serial number, if available. Alphanumeric only, case-insensitive. For apps targeting SDK higher than [O_MR1](https://developer.android.com/reference/android/os/Build.VERSION_CODES.html#O_MR1) this field is set to [UNKNOWN](https://developer.android.com/reference/android/os/Build.html#UNKNOWN).
> 

**注意**

1. SERIAL字段在API level 26中被废弃

**替代**

```java
String serialNumber = android.os.Build.getSerial();
```

**注意**

1. 需要`READ_PHONE_STATE`权限
2. Root后将可以更改设备标识符，包括硬件序号

#### Installation ID ####

如果并不是确实需要对硬件本身进行绑定，使用自己生成的UUID也是一个不错的选择。这种方式的原理是在程序安装后第一次运行时生成一个ID，该方式和设备唯一标识不一样，不同的应用程序会产生不同的ID，同一个程序重新安装也会不同。所以这不是设备的唯一ID，但是可以保证每个用户的ID是不同的。可以说是用来标识每一份应用程序的唯一ID（即Installtion ID），可以用来跟踪应用的安装数量等。

```java
public class Installation {
    private static String sID = null;
    private static final String INSTALLATION = "INSTALLATION";

    public synchronized static String id(Context context) {
        if (sID == null) {  
            File installation = new File(context.getFilesDir(), INSTALLATION);
            try {
                if (!installation.exists())
                    writeInstallationFile(installation);
                sID = readInstallationFile(installation);
            } catch (Exception e) {
                throw new RuntimeException(e);
            }
        }
        return sID;
    }

    private static String readInstallationFile(File installation) throws IOException {
        RandomAccessFile f = new RandomAccessFile(installation, "r");
        byte[] bytes = new byte[(int) f.length()];
        f.readFully(bytes);
        f.close();
        return new String(bytes);
    }

    private static void writeInstallationFile(File installation) throws IOException {
        FileOutputStream out = new FileOutputStream(installation);
        String id = UUID.randomUUID().toString();
        out.write(id.getBytes());
        out.close();
    }
}
```

### iOS ###


[1]: https://android-developers.googleblog.com/2011/03/identifying-app-installations.html "Identifying App Installations"

[2]: https://stackoverflow.com/questions/2785485/is-there-a-unique-android-device-id "Is there a unique Android device ID?"

[3]: http://www.cnblogs.com/lvcha/p/3721091.html "获取Android设备唯一标识码"
