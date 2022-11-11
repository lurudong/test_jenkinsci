# ����jenkins

### 1������һ��jenkins��Ŀ

**�½���Ŀ**



# docker ��ͨ��ʽ

```shell
#!/bin/bash
#��ȡ�̰汾��
GITHASH=`git rev-parse --short HEAD`
docker stop test_jenkinsci
docker rm test_jenkinsci
echo ---------------Building Docker Image...------------------
docker build -t test_jenkinsci:$GITHASH .
docker tag test_jenkinsci:$GITHASH test_jenkinsci:latest
echo ---------------Launching Container...------------------
docker run -d -p 5001:80 --name=test_jenkinsci test_jenkinsci:latest
```

# ��װdocker-conpose

��Ϊjenkins��Ҫ�õ����ص�docker-compose���������ԣ���װ�����ϲ����jenkins��ʹ��

```bash
docker exec -it jenkins /bin/bash
```

����**�����ڲ�**��װdocker-compose��[��װ����ȥ](https://github.com/yeasy/docker_practice/blob/master/compose/install.md)

# ʾ�������ű���run.bat

```shell
�ýű�����Windows Server����ȡ���´��벢����.Net���񣬿��Խ��ű���ӵ�Windows�ƻ������н��ж�ʱ���·���

cd  ./test_jenkinsci
git pull
cd  ./test_jenkinsci
start dotnet run
```

#   Jenkins����ִ��shell

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



   

# Jenkinsϵͳ�û���Ȩ

```
sudo usermod -a -G docker jenkins
```

# ����Jenkins

```
systemctl restart jenkins
```

