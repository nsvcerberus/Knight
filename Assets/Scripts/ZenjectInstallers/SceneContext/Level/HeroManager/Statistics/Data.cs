using System;

namespace Fight.Level.Characters.Heroes
{
    public class Data
    {
        public event Action<int> HealthUpdated;

        public int Health { get; private set; }


        public void OnHealthUpdated(int value) => HealthUpdated?.Invoke(Health = value);
    }
}