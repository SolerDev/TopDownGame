using System.Collections;
using System.Collections.Generic;
using TopDownGame.Inputs;
using UnityEngine;
using Zenject;

namespace TopDownGame
{

    public class GameplayInstaller : MonoInstaller
    {
        public const int PLAYER_ID = 01;

        public override void InstallBindings()
        {
            //todo: bind every component on player with id PLAYER_ID for ease of access
            var player = GameObject.FindWithTag("Player");
            Container.BindInstance(player)
                     .WithId(PLAYER_ID)
                     .AsSingle()
                     .NonLazy();

            Container.BindInstance(new PlayerInputActions()).AsSingle().NonLazy();
            Container.Bind<InputActionsProvider>().FromComponentInHierarchy().AsSingle().NonLazy();


            Container.Bind<Animator>()
                     .FromComponentInChildren()
                     .AsTransient()
                     .Lazy();

            Container.Bind<AnimatorParametersController>()
                     .FromComponentInChildren()
                     .AsTransient()
                     .Lazy();

            Container.Bind<IMove>()
                     .FromComponentInParents()
                     .AsTransient()
                     .Lazy();

            Container.Bind<Rigidbody2D>()
                     .FromComponentInChildren()
                     .AsTransient()
                     .Lazy();
        }
    }
}
