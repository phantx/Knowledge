# Windows WSL 配置SFTP Server

如下环境
> Windows 1803 (OS Build 17134.829)
> WSL Ubuntu 18.04 LTS

## FTP服务

1. 安装FTP服务

```shell
sudo apt-get install vsftpd
```

2. 配置FTP服务

如果需要，可以先备份安装时自动生成的配置文件
```shell
sudo mv /etc/vsftpd.conf /etc/vsftpd.conf_orig
```

然后创建/修改配置
```shell
sudo vim /etc/vsftpd.conf
```

将配置文件内容改为如下
```ini
listen=NO
listen_ipv6=YES
anonymous_enable=NO
local_enable=YES
write_enable=YES
local_umask=022
dirmessage_enable=YES
use_localtime=YES
xferlog_enable=YES
connect_from_port_20=YES
chroot_local_user=YES
secure_chroot_dir=/var/run/vsftpd/empty
pam_service_name=vsftpd
rsa_cert_file=/etc/ssl/certs/ssl-cert-snakeoil.pem
rsa_private_key_file=/etc/ssl/private/ssl-cert-snakeoil.key
ssl_enable=NO
pasv_enable=Yes
pasv_min_port=10000
pasv_max_port=10100
allow_writeable_chroot=YES
```

3. 如果需要，可以开启防火墙端口

```shell
sudo ufw allow from any to any port 20,21,10000:10100 proto tcp
```
> 10000:10100 与配置文件中的`pasv_min_port`和`pasv_max_port`对应

4. 重启服务

```shell
sudo service vsftpd restart
```

## SSH服务

1. 安装SSH服务

```shell
sudo apt-get install openssh-server
```

2. 配置SSH服务

```shell
sudo vim /etc/ssh/sshd_config
```

在配置文件最后添加如下内容
```bash
Match group sftp
ForceCommand internal-sftp
PasswordAuthentication yes
ChrootDirectory /home
PermitTunnel no
AllowAgentForwarding no
AllowTcpForwarding no
X11Forwarding no
```

3. 创建SFTP用户

```shell
sudo addgroup sftp
sudo useradd -m sftpuser -g sftp
sudo passwd sftpuser
sudo chmod 700 /home/sftpuser/
```

## 使用KEY无密码登录SFTP

1. 生成SSH公钥和私钥

```shell
ssh-keygen -t rsa -b 4096 -f wsl_ssh_key
```

2. 将生成的私钥`wsl_ssh_key`存放在客户端，比如`~/.ssh/wsl_ssh_key`

3. 将生成的公钥`wsl_ssh_key.pub`更名为`authorized_keys`放到服务器的`/home/sftpuser/.ssh/`目录下，并限制访问权限

```shell
chmod 0600 ~/.ssh/authorized_keys
```

4. 通过SSH命令访问

```shell
ssh -i ~/.ssh/wsl_ssh_key sftpuser@server.example.com
```


## 问题解决

1. 在Windows命令行下运行`ssh 127.0.0.1`显示如下内容

> Connection closed by 127.0.0.1 port 22

或者运行`sftp 127.0.0.1`显示如下内容

> Connection closed by 127.0.0.1 port 22
> Connection closed

**解决方法**

- 在`/etc/hosts.allow`文件中添加以下两行

> ssh:ALL:allow
> sshd:ALL:allow

- 并且重新安装 openssh-server

```shell
sudo apt-get remove --purge openssh-server
sudo apt-get install openssh-server
```

[1]: https://blog.tinned-software.net/ssh-passwordless-login-with-ssh-key/ "SSH passwordless login with SSH-key"
[2]: https://blog.tinned-software.net/setup-sftp-only-account-using-openssh-and-ssh-key/ "Setup sftp only account using openssh and ssh-key"
[3]: https://linuxconfig.org/how-to-setup-ftp-server-on-ubuntu-18-04-bionic-beaver-with-vsftpd "How to setup FTP server on Ubuntu 18.04 Bionic Beaver with VSFTPD"
[4]: https://linuxconfig.org/how-to-setup-sftp-server-on-ubuntu-18-04-bionic-beaver-with-vsftpd "How to setup SFTP server on Ubuntu 18.04 Bionic Beaver with VSFTPD"
[5]: https://github.com/Microsoft/WSL/issues/3173 "Failed to ssh localhost"
[6]: http://stupidstuffihadtofix.blogspot.com/2016/08/ubuntu-on-windows-10-getting-openssh.html "Ubuntu on Windows 10 - Getting OpenSSH Server running properly"
[7]: https://www.digitalocean.com/community/tutorials/how-to-enable-sftp-without-shell-access-on-ubuntu-18-04 "How To Enable SFTP Without Shell Access on Ubuntu 18.04"
