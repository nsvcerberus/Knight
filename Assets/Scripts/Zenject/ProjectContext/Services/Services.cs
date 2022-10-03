using Zenject;

namespace Fight.Zenject.ProjectContext.Services
{
    public class Services : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DirectionsDeterminant>().AsSingle();
        }
    }
}