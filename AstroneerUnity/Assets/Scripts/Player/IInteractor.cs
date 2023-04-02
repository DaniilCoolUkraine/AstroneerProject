using System.Collections.Generic;
using Astroneer.Interactable;

namespace Astroneer.Player
{
    public interface IInteractor
    {
        public List<IInteractable> Interactable { get; set; }
    }
}