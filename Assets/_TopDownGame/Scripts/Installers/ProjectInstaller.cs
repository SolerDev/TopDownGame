using Zenject;

namespace TopDownGame
{
    public class ProjectInstaller: Installer
    {
        public override void InstallBindings()
        {
            //todo: add to projet context
            Container.Bind<IVelocityCalculator>()
                     .To<SmoothVelocityCalculator>()
                     .AsSingle()
                     .NonLazy();
        }
    }
}
