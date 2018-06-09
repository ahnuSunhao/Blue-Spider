# 关于类TCP.CS的修改版本以及修改内容
### 版本号：
	version 1.0
#### 修改时间：
	2018-05-29
#### 修改内容： 
	建立多人聊天的connection,实现异步信息的处理。
### 版本号：
	version 1.1
#### 修改时间：
	2018-06-06
#### 修改内容：
	返回多人连接的所有人的socket连接，将所有人的IP地址以及connection保存在directory里，当需要对某个connection建立通信时，在进行调用。
### 版本号：
	version 1.2
#### 修改时间：
	2018-06-09
#### 修改内容：
	增加了IP地址的动态获取方式，避免了在不同的局域网范围内修改服务端的IP地址
#### 接口调用：	
	TCP tcp = new TCP();
	private Dictionary<string, Socket> clientConnectionItems = tcp.GetKeyValuePairs();
