# Jenkins安装

安装其实很简单，就不多说了，请看[这篇文章](https://www.jenkins.io/zh/doc/book/installing/)，自行选择安装方式 

以上是简单dokcer 安装方式：

```shell
docker run  -u root -d -p 8081:8080 -p 50000:50000   -v jenkins-data:/var/jenkins_home  -v /var/run/docker.sock:/var/run/docker.sock   jenkinsci/blueocean
```

# 配置jenkins

### 1、创建一个jenkins项目

**新建项目**

![新建项目](./images/image-20221112144045809.png)

**构建一个自由风格的软件项目**

![构建一个自由风格的软件项目](./images/image-20221112150539.jpg)

# docker 普通方式

```shell
#!/bin/bash
#获取短版本号
GITHASH=`git rev-parse --short HEAD`
docker stop test_jenkinsci
docker rm test_jenkinsci
echo ---------------Building Docker Image...------------------
docker build -t test_jenkinsci:$GITHASH .
docker tag test_jenkinsci:$GITHASH test_jenkinsci:latest
echo ---------------Launching Container...------------------
docker run -d -p 5001:80 --name=test_jenkinsci test_jenkinsci:latest
```

# 安装docker-conpose

因为jenkins需要用到本地的docker-compose环境，所以，安装完以上步骤的jenkins后，使用

```bash
docker exec -it jenkins /bin/bash
```

进入**容器内部**安装docker-compose，[安装步骤去](https://github.com/yeasy/docker_practice/blob/master/compose/install.md)

# 示例启动脚本：run.bat

```shell
该脚本用于Windows Server中拉取最新代码并启动.Net服务，可以将脚本添加到Windows计划任务中进行定时更新服务。

cd  ./test_jenkinsci
git pull
cd  ./test_jenkinsci
start dotnet run
```

#   Jenkins构建执行shell

```shell
 #!/bin/sh
 cd /var/lib/jenkins/workspace/src/test_jenkinsci
 docker container prune << EOF
 y
EOF
docker container ls -a | grep "test_jenkinsci"
if [ $? -eq 0 ];then
    docker container stop test_jenkinsci
    docker container rm test_jenkinsci
fi
docker image prune << EOF
y
EOF
docker build -t test_jenkinsci .

docker run -d -p 5000:80 --name=test_jenkinsci test_jenkinsci


```



   

# Jenkins系统用户授权

```
sudo usermod -a -G docker jenkins
```

# 重启Jenkins

```
systemctl restart jenkins
```

