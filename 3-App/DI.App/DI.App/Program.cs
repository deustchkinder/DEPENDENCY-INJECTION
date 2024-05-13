using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

//services.AddSingleton<ITest<int>, Test1<int>>();
//services.AddSingleton<ITest<string>, Test2<string>>();

//SINGLE TYPE GENERIC TYPE
//services.AddScoped(typeof(ITest<int>), typeof(Test1<int>));
//services.AddScoped(typeof(ITest<string>), typeof(Test2<string>));

//services.AddSingleton<ITest<int, string>, Test1<int, string>>();
//services.AddSingleton<ITest<string, DateTime>, Test2<string, DateTime>>();

//MULTIPLE TYPE GENERIC TYPE
services.AddScoped(typeof(ITest<,>), typeof(Test1<,>));
services.AddScoped(typeof(ITest<string, DateTime>), typeof(Test2<string, DateTime>));

var provider = services.BuildServiceProvider();

var test1 = provider.GetService<ITest<int, string>>();
test1!.Test(1,"Güneşi gördüğünde kendini tutmayacaksın");

var test2 = provider.GetService<ITest<string, DateTime>>();
test2!.Test("Ben ayın karanlık yüzünde güneşimi bekliyorum ", DateTime.Now);

Console.Read();

interface ITest<T, Y>
{
    void Test(T t, Y y);
}

class Test1<T, M> : ITest<int, string>
{
    public void Test(int t, string s)
    {
        Console.WriteLine($"Test1 {t} --- {s}");
    }
}


class Test2<T, D> : ITest<string, DateTime>
{
    public void Test(string t, DateTime dt)
    {
        Console.WriteLine($"Test2 {t} ----{dt}");
    }
}





