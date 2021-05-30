# EF-Core-Oracle-Web-API
very simple CURD Web API demo With EF Core and Oracle

## 一个非常简单的采用EF core搭配Oracle数据库（大学数据库，移步db-book.com），给出的不标准的CRUD的web API的demo(但修改也很容易，不过测试需要用postman了)

### 使用时，需要添加MicrosoftEntityFramework.tools,MicrosoftEntityFrameworkCore,Oracle.MicrosoftEntityFrameworkCore的Nuget包，并将数据库连接换成自己Tnsname.ora文件中的相关信息

#### 最后需要说明的是，由于浏览器只能get请求，这里就全部写的httpget（很不对），应该根据情况选择http请求。用postman进行截断，然后测试（因为我win的本上忘了下postman了。）
