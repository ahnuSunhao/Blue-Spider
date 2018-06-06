#  版本号：version 1.1
## 修改时间：2018-06-06
## 修改内容：返回多人连接的所有人的socket连接，将所有人的IP地址以及connection保存在directory里，当需要对某个connection建立通信时，在进行调用。
## 接口调用：	
	TCP tcp = new TCP();
	private Dictionary<string, Socket> clientConnectionItems = tcp.GetKeyValuePairs();
