using BuildingBlocks.CQRS;
using FluentAssertions;
using FluentValidation;
using NetArchTest.Rules;
namespace Catalog.ArchitectureTests.Applications;

public class ApplicationTests : BaseTest
{
    [Fact]
    public void CommandHandler_Should_HaveNameEndingWith_CommandHandler()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<>))
            .Or()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should().HaveNameEndingWith("CommandHandler")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    //[Fact]
    //public void CommandHandler_Should_HaveNameEndingWith_CommandHandler1()
    //{
    //    var result = Types.InAssembly(ApplicationAssembly)
    //        .That()
    //        .ImplementInterface(typeof(ICommandHandler<>))
    //        .Or()
    //        .ImplementInterface(typeof(ICommandHandler<,>))
    //        .Should().HaveNameEndingWith("CommandHandler1")
    //        .GetResult();

    //    if (!result.IsSuccessful)
    //    {
    //        foreach (var failingType in result.FailingTypes)
    //        {
    //            Console.WriteLine($"Handler '{failingType.FullName}' does not end with 'CommandHandler'.");
    //        }
    //    }

    //    result.IsSuccessful.Should().BeTrue();
    //}

    [Fact]
    public void QueryHandler_Should_HaveNameEndingWith_QueryHandler()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Validator_Should_HaveNameEndingWith_Validator()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .Inherit(typeof(AbstractValidator<>))
            .Should()
            .HaveNameEndingWith("Validator")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
