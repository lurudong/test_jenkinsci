docker build -t test_jenkinsci .
docker run --name helloworldcontainer -p 9000:80 -d test_jenkinsci


#!/bin/bash
# 获取短版本号
GITHASH=`git rev-parse --short HEAD`
docker stop test_jenkinsci
docker rm test_jenkinsci
echo ---------------Building Docker Image...------------------
docker build -t test_jenkinsci:$GITHASH .
docker tag test_jenkinsci:$GITHASH test_jenkinsci:latest
echo ---------------Launching Container...------------------
docker run -d -p 5001:80 --name=test_jenkinsci test_jenkinsci:latest


1.示例启动脚本：run.bat

该脚本用于Windows Server中拉取最新代码并启动.Net服务，可以将脚本添加到Windows计划任务中进行定时更新服务。

cd  ./test_jenkinsci
git pull
cd  ./test_jenkinsci
start dotnet run

2.Jenkins构建执行shell

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
3. Jenkins系统用户授权

sudo usermod -a -G docker jenkins
4. 重启Jenkins

systemctl restart jenkins