# 20221201 Unity远程连接AWS EC2的MySQL
1. 下载合适的MySQL Connector/NET
问题：Unity 2019不兼容MySQL Connector/NET的最新版本。
原因：最新的MySQL Connector/NET已经不兼容Unity2019使用的.net v4版本。
解决：使用低版本的Connector/NET，我使用的是6.3.9.
https://downloads.mysql.com/archives/c-net/
![image](https://user-images.githubusercontent.com/59216760/204963195-5b47e4e3-d7e9-4d3f-842d-048725a0a5af.png)


2. 找到V4目录下mysql.data.dll，添加入unity项目中
![image](https://user-images.githubusercontent.com/59216760/204963229-602cc8b9-e1f4-447f-9cd0-6f0884cbf1dc.png)


3. 在unity scene中创建一个empty object，将C#脚本添加，后运行game。

![image](https://user-images.githubusercontent.com/59216760/204963255-ae62accc-ac5d-4f2a-a034-6dcee43e60e3.png)



## 效果
应该可以做增删改查（目前只做增和查）

![image](https://user-images.githubusercontent.com/59216760/204963271-19806045-948e-4716-9dd3-647f77cecf43.png)

![image](https://user-images.githubusercontent.com/59216760/204963291-e240c811-e348-4b83-92fb-5fe0c8d61ebf.png)
