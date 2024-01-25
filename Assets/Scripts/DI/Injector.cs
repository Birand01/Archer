using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Injector : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ScoreManager>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}
