namespace Astroneer.Interactable.Puzzles
{
    public class DrawPuzzle : Puzzle
    {
        public override void Interact()
        {
            _onPuzzleCompleted.ChangeValue(true);
        }
    }
}