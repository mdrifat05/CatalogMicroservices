using System.Reflection;


namespace Catalog.ArchitectureTests;

public class BaseTest
{
    protected static Assembly ApplicationAssembly => Assembly.Load("Catalog.Application");
}