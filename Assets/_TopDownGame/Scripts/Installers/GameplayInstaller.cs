using System.Collections;
using System.Collections.Generic;
using TopDownGame.Inputs;
using UnityEngine;
using Zenject;

namespace TopDownGame
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameObject player = GameObject.FindWithTag("Player");
            Container.BindInstance(player)
                     .WithId("Player")
                     .AsSingle()
                     .NonLazy();


            Container.Bind<InputActionsProvider>()
                     .FromComponentInHierarchy()
                     .AsSingle()
                     .NonLazy();
        }
    }
}
