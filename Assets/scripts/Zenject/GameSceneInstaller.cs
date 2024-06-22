using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerController _playerController;

    public override void InstallBindings()
    {
        Container.Bind<IPlayerInput>().FromInstance(_playerInput);
        Container.BindInstance(_playerController);
    }
}