using System;

namespace Fight.Installers.Level.Gameplay
{
    public sealed class States
    {
        public event Action<Types> StateUpdated;

        public enum Types
        {
            Start,
            Play,
            End
        }
        public Types State { get; private set; }


        public void SetStateStart() => OnStateUpdated(State = Types.Start);
        public void SetStatePlay() => OnStateUpdated(State = Types.Play);
        public void SetStateEnd() => OnStateUpdated(State = Types.End);

        public void OnStateUpdated(Types state) => StateUpdated?.Invoke(State = state);
    }
}