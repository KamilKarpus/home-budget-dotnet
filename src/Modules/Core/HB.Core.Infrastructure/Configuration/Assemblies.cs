namespace HB.Core.Infrastructure.Configuration
{
    internal class Assemblies : IAssemblies
    {
        public static readonly Assembly Application = typeof(ICommand).Assembly;

        Assembly IAssemblies.Application => typeof(ICommand).Assembly;
    }
}
