using App.Databases;
using App.Models;
using App.Repository;
using App.Tables;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<UsersTbl>();
services.AddSingleton<MyDbContext>();
services.AddSingleton<IUserxRepo, UserxRepo>();

var provider = services.BuildServiceProvider();
IUserxRepo userRepo = provider.GetRequiredService<IUserxRepo>();

Userx user1 = new() { Id = 1, Name = "Emre Demirkan" };
Userx user2 = new() { Id = 2, Name = "Züleyha Şen" };

var usr = userRepo.Add(user1);
Console.WriteLine(usr.Name);

usr = userRepo.Add(user2);
Console.WriteLine(usr.Name);

var user = userRepo.GetUserx(1);
Console.WriteLine(user?.Name);

var users = userRepo.GetAll();

foreach(var u in users)
{
    Console.WriteLine(u.Name);
}


Console.Read();

//EFCORE ilkel olarak model oluştur,tablolar haline getir ve veritabanına pasla.
/*
MyDbContext myDbContext = new(new App.Tables.UsersTbl());

Userx user1 = new Userx { Id = 1, Name = "Emre Demirkan" };
Userx user2 = new Userx { Id = 2, Name = "Züleyha Şen" };

var usr = myDbContext.Add(user1);
Console.WriteLine(usr.Name);

usr=myDbContext.Add(user2);
Console.WriteLine(usr.Name);

var user = myDbContext.Get(1);
Console.WriteLine(user?.Name);

var users = myDbContext.GetAll();
foreach(var u in users)
{
    Console.WriteLine(u.Name);
}
*/
//DEPENDENCY INJECTION:sınıflar arasındaki bağımlılığı yönet,modülerlik kazandır,ihtiyaç duydukları bağımlılıkları servisler ya da veritabanı bağlantılarından otomatik olarak sağla.
/*
ITest testx = new YourTest();
TestFabric testFabric = new TestFabric(testx,new BaskaClass("VERECEGIM DEGERI BURADA TANIMLADIM,MODULERLIK",new BambaskaClass("UNIT TEST denemesidir")));
testFabric.Test1();


Console.Read();

interface ITest
{
    void Test();
}

class MyTest : ITest
{
    public void Test() 
    {
        Console.WriteLine("MYTEST");
    }
}

class YourTest : ITest
{
    public void Test()
    {
        Console.WriteLine("YOURTEST");
    }
}

//Test işlemlerini bir sınıf halinde yazdıralım,sadece parametreli değil de
//TestFabric sınıfı ile yazdırılması planlanan işi bir kere de halledebildim, olmasa her defasında yazdırmak durumunda idim. MODÜLERLİK
class TestFabric(ITest test,BaskaClass baskaClass)
{
    public void Test1() 
    {
        Console.WriteLine("TEST1 test edilebilirlik");
        baskaClass.Test2();
        test.Test();

    }
}

class BaskaClass(string str,BambaskaClass bambaskaClass)
{
    public void Test2()
    {
        Console.WriteLine(str);
        bambaskaClass.Test3();
    }
}

class BambaskaClass(string str)
{
    public void Test3()
    {
        Console.WriteLine(str);
    }
}
*/

//Containers modern olarak instance'leri servis üzerinden çağırmak,provider üzerineden fazla bi şeilde hazır olarak verilmek.
/*
var services = new ServiceCollection();
services.AddSingleton<UsersTbl>();
services.AddSingleton<MyDbContext>();

var provider = services.BuildServiceProvider();
MyDbContext myDbContext = provider.GetRequiredService<MyDbContext>();

Userx user1 = new() { Id = 1, Name = "Emre Demirkan" };
Userx user2 = new() { Id = 2, Name = "Züleyha Şen" };

var usr = myDbContext.Add(user1);
Console.WriteLine(usr.Name);

usr = myDbContext.Add(user2);
Console.WriteLine(usr.Name);

var user = myDbContext.Get(1);
Console.WriteLine(user?.Name);

var users = myDbContext.GetAll();
foreach (var u in users)
{
    Console.WriteLine(u.Name);
}
*/