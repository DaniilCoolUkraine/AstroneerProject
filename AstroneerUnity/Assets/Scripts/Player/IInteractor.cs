using Astroneer.Interactable;

namespace Astroneer.Player
{
    public interface IInteractor
    {
        public IInteractable Interactable { get; set; }
    }
}