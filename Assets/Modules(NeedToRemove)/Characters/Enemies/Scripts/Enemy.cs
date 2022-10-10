using UnityEngine;
using Zenject;

namespace Fight.Level.Characters.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        [Inject] EnemiesManager enemiesManager;
        private EnemyManager enemyManager;


        private void Awake()
        {
            enemiesManager.AddEnemy(this);
            enemyManager = enemiesManager.GetEnemyManager(this);
            enemyManager.SetHero(GameObject.Find("Hero").GetComponent<Fight.Level.Characters.Heroes.Hero>());
        }


        private void Update()
        {
            if (enemyManager.hero != null)
                transform.position = Vector3.Lerp(transform.position, enemyManager.hero.transform.position, 1 * Time.deltaTime);
        }
    }
}