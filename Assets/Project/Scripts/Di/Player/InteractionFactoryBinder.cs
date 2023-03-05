using Invaders.Factories;
using Invaders.Gear;
using Zenject;

namespace Invaders.Di
{
    public class InteractionFactoryBinder : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindFactory<IItem, IPlayerInteractableHandler, InteractionFactory>()
                .FromFactory<InteractionFactory>();
        }
    }
}