using Zenject;
using Fight.Level.Characters.Heroes;
using Fight.Level.Characters.Enemies;

namespace Fight.Installers.Level
{
    public sealed class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Gameplay.GameplayManager>().AsSingle();
            Container.Bind<HeroManager>().AsSingle();
            Container.Bind<ITickable>().To<HeroManager>().FromResolve();
            Container.Bind<EnemiesManager>().AsSingle();
        }
    }
}