using DiamondKata;
using DiamondKata.Creators;
using DiamondKata.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services
    .AddSingleton<IShapeCreator, DiamondCreator>()
    .AddSingleton<IConsoleWriter, ConsoleWriter>();

var serviceProvider = services.BuildServiceProvider();

serviceProvider.GetRequiredService<IConsoleWriter>()!.Start();
