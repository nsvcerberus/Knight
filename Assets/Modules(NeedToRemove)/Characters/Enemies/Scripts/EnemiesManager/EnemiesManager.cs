using System.Collections.Generic;

namespace Fight.Level.Characters.Enemies
{
    public class EnemiesManager
    {
        private Dictionary<IEnemy, EnemyManager> enemies = new Dictionary<IEnemy, EnemyManager>();


        public void AddEnemy(IEnemy enemy) => enemies.Add(enemy, new EnemyManager());
        public EnemyManager GetEnemyManager(IEnemy enemy) => enemies[enemy];
    }
}