﻿using MassTransit;
using MassTransit.Testing;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Moq;

using SFC.Data.Contracts.Events;
using SFC.Players.Application.Interfaces.Persistence;
using SFC.Players.Domain.Common;
using SFC.Players.Domain.Entities;
using SFC.Players.Domain.Entities.Data;
using SFC.Players.Infrastructure.Consumers;

namespace SFC.Players.Infrastructure.UnitTests.Consumers;
public class DataInitializationEventConsumerTests
{
    [Fact]
    [Trait("Consumer", "DataInitializationEvent")]
    public async Task Consumer_DataInitializationEvent_ShouldResetAllRepositories()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        Mock<IHostEnvironment> hostEnvironmentMock = new();
        hostEnvironmentMock.Setup(m => m.EnvironmentName).Returns("Prouction");
        services.AddSingleton(hostEnvironmentMock.Object);

        List<Mock> mocks = SetUpRepositories(services);

        Mock<IPlayerRepository> playerRepositoryMock = new();
        playerRepositoryMock.Setup(m => m.AddAsync(It.IsAny<Player>())).Verifiable();
        services.AddSingleton(playerRepositoryMock.Object);

        await using ServiceProvider provider = services
            .AddMassTransitTestHarness(x => x.AddConsumer<DataInitializationEventConsumer>())
            .BuildServiceProvider(true);

        // Act
        ITestHarness harness = provider.GetRequiredService<ITestHarness>();
        await harness.Start();
        await harness.Bus.Publish(new DataInitializationEvent());

        // Assert
        Assert.True((await harness.Consumed.Any<DataInitializationEvent>()));
        Mock.VerifyAll(mocks.AsEnumerable().ToArray());
        playerRepositoryMock.Verify(m => m.AddAsync(It.IsAny<Player>()), Times.Never);
    }

    [Fact]
    [Trait("Consumer", "DataInitializationEvent")]
    public async Task Consumer_DataInitializationEvent_ShouldAddTestPlayers()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        Mock<IHostEnvironment> hostEnvironmentMock = new();
        hostEnvironmentMock.Setup(m => m.EnvironmentName).Returns("Development");
        services.AddSingleton(hostEnvironmentMock.Object);

        List<Mock> mocks = SetUpRepositories(services);

        Mock<IPlayerRepository> playerRepositoryMock = new();
        playerRepositoryMock.Setup(m => m.AddRangeAsync(It.IsAny<Player[]>())).Verifiable();
        services.AddSingleton(playerRepositoryMock.Object);
        mocks.Add(playerRepositoryMock);

        await using ServiceProvider provider = services
            .AddMassTransitTestHarness(x => x.AddConsumer<DataInitializationEventConsumer>())
            .BuildServiceProvider(true);

        // Act
        ITestHarness harness = provider.GetRequiredService<ITestHarness>();
        await harness.Start();
        await harness.Bus.Publish(new DataInitializationEvent());

        // Assert
        Assert.True((await harness.Consumed.Any<DataInitializationEvent>()));
        Mock.VerifyAll(mocks.AsEnumerable().ToArray());
    }

    private static List<Mock> SetUpRepositories(IServiceCollection services)
    {
        List<Mock> mocks = new();

        SetUpRepository<FootballPosition>(services, mocks);
        SetUpRepository<GameStyle>(services, mocks);
        SetUpRepository<StatCategory>(services, mocks);
        SetUpRepository<StatSkill>(services, mocks);
        SetUpRepository<StatType>(services, mocks);
        SetUpRepository<WorkingFoot>(services, mocks);

        return mocks;
    }

    private static void SetUpRepository<T>(IServiceCollection services, List<Mock> mocks) where T : BaseDataEntity
    {
        Mock<IDataRepository<T>> mock = new();
        mock.Setup(m => m.ResetAsync(It.IsAny<IEnumerable<T>>())).Verifiable();
        services.AddSingleton(mock.Object);
        mocks.Add(mock);
    }
}
