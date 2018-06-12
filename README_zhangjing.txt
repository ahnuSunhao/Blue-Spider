对于线程的IsBackground的理解：

1、当在主线程中创建了一个线程，那么该线程的IsBackground默认是设置为FALSE的。

2、当主线程退出的时候，IsBackground=FALSE的线程还会继续执行下去，直到线程执行结束。

3、只有IsBackground=TRUE的线程才会随着主线程的退出而退出。

4、当初始化一个线程，把Thread.IsBackground=true的时候，指示该线程为后台线程。后台线程将会随着主线程的退出而退出。

5、原理：只要所有前台线程都终止后，CLR就会对每一个活在的后台线程调用Abort（）来彻底终止应用程序。


