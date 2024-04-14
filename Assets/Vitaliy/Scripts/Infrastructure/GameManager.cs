using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Infrastructure
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] 
        private EntityFactory _entityFactory;
        /*[SerializeField] 
        private CinemachineVirtualCamera _camera;
        [SerializeField] 
        private GameObject _hud;
        [SerializeField] 
        private Transform _playerSpavnPoint;*/
        [SerializeField] 
        private Spawner _spawner;
        /*[SerializeField]
        private List<Item> _items;*/

        private DependencyInjection _container;
        private IInputSystem _inputSystem;

        private void Awake()
        {
            _container = new DependencyInjection();
            _inputSystem = _container.RegisterDependency<IInputSystem>(new InputSystemKeyboardMouse());
            AudioManager audioManager = _container.RegisterDependency(new AudioManager());
            StaticDataService staticDataService = _container.RegisterDependency(new StaticDataService());
            _entityFactory.Construct(_container, staticDataService);
            EntityFactory entityFactory = _container.RegisterDependency(_entityFactory);
            // entityFactory.CreatePlayer(_playerSpavnPoint.position, _camera);
            WindowManager windowManager = _container.RegisterDependency(new WindowManager(_container, staticDataService, _inputSystem));
            _spawner.Construct(entityFactory, audioManager);
            /*Hud hud = Instantiate(_hud).GetComponent<Hud>();
            hud.Construct(_container);
            _container.RegisterDependency(hud);*/

            windowManager.OpenWindow(typeof(GameMenu));
            windowManager.CloseWindow();

        }

        private void Update()
        {
            _inputSystem.Update();
        }
    }
}
