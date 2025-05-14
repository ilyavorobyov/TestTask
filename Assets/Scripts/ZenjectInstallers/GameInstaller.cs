using Particles;
using PlayerCharacter;
using ScoreTimer;
using UnityEngine;
using Zenject;

namespace ZenjectInstallers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerInteractableDetector _playerInteractableDetector;
        [SerializeField] private HideObjectEffect _hideObjectEffect;
        [SerializeField] private ScoreTimerView _scoreTimerView;
        [SerializeField] private ScoreTimerViewObject _scoreTimerViewObject;
        [SerializeField] private ScoreTimerLogic _scoreTimerLogic;

        public override void InstallBindings()
        {
            Container.Bind<PlayerInteractableDetector>().FromInstance(_playerInteractableDetector).AsSingle();
            Container.Bind<HideObjectEffect>().FromInstance(_hideObjectEffect).AsSingle();
            Container.Bind<ScoreTimerView>().FromInstance(_scoreTimerView).AsSingle();
            Container.Bind<ScoreTimerViewObject>().FromInstance(_scoreTimerViewObject).AsSingle();
            Container.Bind<ScoreTimerLogic>().FromInstance(_scoreTimerLogic).AsSingle();
        }
    }
}