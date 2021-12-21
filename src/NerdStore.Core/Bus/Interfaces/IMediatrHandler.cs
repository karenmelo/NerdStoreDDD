using System.Threading.Tasks;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Bus.Interfaces
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}