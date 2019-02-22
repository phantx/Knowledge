# 在Linux系统安装使用7-zip #

## 安装

### Debian、Ubuntu 或 Linux Mint 系统 ###

在基于的 Debian 的发布系统中存在有三种 7zip 的软件包。

- **p7zip**： 包含 7zr（最小的 7zip 归档工具），仅仅只能处理原生的 7z 格式。

- **p7zip-full**： 包含 7z ，支持 7z、LZMA2、XZ、ZIP、CAB、GZIP、BZIP2、ARJ、TAR、CPIO、RPM、ISO 和 DEB 格式。

- **p7zip-rar**： 包含一个能解压 RAR 文件的插件。

建议安装 p7zip-full 包（不是 p7zip），因为这是最完全的 7zip 程序包，它支持很多归档格式。
此外，如果您想处理 RAR 文件话，还需要安装 p7zip-rar 包，做成一个独立的插件包的原因是因为 RAR 是一种专有格式。

```shell
sudo apt-get install p7zip-full
```

### Fedora 或 CentOS、RHEL 系统 ###

基于红帽的发布系统上提供了两个 7zip 的软件包。

- **p7zip**： 包含 7za 命令，支持 7z、ZIP、GZIP、CAB、ARJ、BZIP2、TAR、CPIO、RPM 和 DEB 格式。

- **p7zip-plugins**： 包含 7z 命令，额外的插件，它扩展了 7za 命令（例如支持 ISO 格式的抽取）。

在 CentOS/RHEL 系统中，在运行下面命令前您需要确保 EPEL 资源库可用。
但在 Fedora 系统中就不需要额外的资源库了。

```shell
sudo yum install p7zip p7zip-plugins
```

## 使用
