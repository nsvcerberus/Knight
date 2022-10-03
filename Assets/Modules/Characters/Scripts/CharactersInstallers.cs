using Fight.Gameplay.Hero;
using Zenject;

namespace Fight.Gameplay
{
    public class CharactersInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<HeroManager>().AsSingle();
            Container.Bind<ITickable>().To<HeroManager>().FromResolve();
        }
    }
}