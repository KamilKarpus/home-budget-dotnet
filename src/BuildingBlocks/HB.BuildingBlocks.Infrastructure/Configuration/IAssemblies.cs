using System.Reflection;

namespace HB.BuildingBlocks.Infrastructure.Configuration
{
    public interface IAssemblies
    {
        Assembly Application { get; }
    }
}
