using NerdStore.Core.Messages;
using System.Threading.Tasks;

namespace NerdStore.Core.Bus.Interfaces
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}