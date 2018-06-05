# Blue-Spider
红蜘蛛模拟软件

github上传使用步骤
1.首先在本机安装Git-2.17.0-64-bit.exe，然后在c/user/本机名中查看是否有.ssh文件，若有则进入第二步，若无在git bash 中执行ssh-keygen -t rsa -C "youremail@example.com"
2.将.ssh文件中的id_rsa.pub，用记事本打开然后全选复制发送给我（孙浩），我在GitHub上给你们添加私钥（你发给我后我要同意你们才能连接）
3.上述步骤执行完后，你们本地的git就和GitHub连接完成
4.在本地文件夹下右击选择git bash，输入git clone +我们项目的网址（我会传到群里）
5.全部clone后，你们进入自己的分支，
命令：git branch -b sunhao origin/sunhao（sunhao是我们建立的分支名）
6.在里面修改文件后，比如修改了1.doc文件，修改完毕后，在git bash中输入:git add 1.doc
7.然后输入git commit -m "explan you commit"。-m后面的是你的注释，简单说明一下你本次提交的目的或者修改了哪些东西，不写也行
8.输入：git push origin sunhao,origin后的是我们的分支名，一定要把分支名写对，否则会出现不可预测的错误。
9.上述全部执行成功后就完成了上传工作，鉴于我也是初次接触git，应该有部分错误，后期会继续更新，若发现什么问题及时在里面修改。
