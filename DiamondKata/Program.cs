using DiamondKata;
using DiamondKata.Creators;
using DiamondKata.Interfaces;
using DiamondKata.Validators;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services
    .AddSingleton<IShapeCreator, DiamondCreator>()
    .AddSingleton<IConsoleWriter, ConsoleWriter>()
    .AddSingleton<IInputValidator, InputValidator>();

var serviceProvider = services.BuildServiceProvider();

serviceProvider.GetRequiredService<IConsoleWriter>()!.Start();
