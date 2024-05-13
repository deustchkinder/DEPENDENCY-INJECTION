using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

//services.AddSingleton<Test1>();
//services.AddScoped<Test1>();

//services.AddSingleton<LıfeTıme>();
//services.AddScoped<Test1>(); //nesnelerin farklı olmasını arzu ediyorsan.
services.AddScoped<LıfeTıme>();
services.AddTransient<Test1>();

//var provider = services.BuildServiceProvider();
var provider = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();

using (var scope = provider.CreateScope())
{
    var test1 = scope.ServiceProvider.GetRequiredService<Test1>();
    test1.Test();
    //COPY-PASTE ile id çoğaltma her istekte aynı scope'ta olup olmamamıza bakılmaksızın yeni bir nesne türetir.
    test1 = scope.ServiceProvider.GetRequiredService<Test1>();
    test1.Test();
}

Console.WriteLine();

//provider = services.BuildServiceProvider();

using (var scope = provider.CreateScope())
{
    var test1 = scope.ServiceProvider.GetRequiredService<Test1>();
    test1.Test();
}

Console.Read();

class Test1(LıfeTıme lıfeTıme)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public void Test()
    {
        Console.WriteLine($"Test {Id}");
        lıfeTıme.Lıfe();
    }
}

class LıfeTıme
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public void Lıfe()
    {
        Console.WriteLine($"BELLEKTE YASAM SURESI {Id}");
    }
}