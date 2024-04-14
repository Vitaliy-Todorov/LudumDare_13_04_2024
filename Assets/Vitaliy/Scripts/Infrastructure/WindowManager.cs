using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure
{
    public class WindowManager
    {
        private string MEMU_CANVAS_PATH = "Prefabs/UI/Menu/MenuCanvas";
    
        private Dictionary<Type, Window> _windows;
        private readonly Transform _menuCanvas;

        private WindowMessage _windowMessage;
        private StaticDataService _staticDataService;
        private DependencyInjection _diContainer;

        public Window CurrenWindow { get; private set; }

        public WindowManager(DependencyInjection diContainer, StaticDataService staticDataService, IInputSystem inputSystem)
        {
            _staticDataService = staticDataService;
            _diContainer = diContainer;
        
            GameObject menuCanvasPrefab = (GameObject) Resources.Load(MEMU_CANVAS_PATH);
            _menuCanvas = GameObject.Instantiate(menuCanvasPrefab).transform;

            _windows = new Dictionary<Type, Window>();

            inputSystem.OnEscClicked += ClickOnEsc;
        }

        private void ClickOnEsc(){
        
            if (CurrenWindow?.GetType() != typeof(GameMenu)) 
                OpenWindow(typeof(GameMenu));
            else 
                CloseWindow();
        }

        public Window OpenWindow(Type type)
        {
            if (_windows.TryGetValue(type, out Window window))
            {
                CurrenWindow = window;
                CurrenWindow.Activate();
            }
            else
                CreatWindow(type);

            return CurrenWindow;
        }

        public void CloseWindow()
        {
            if(CurrenWindow != null) 
                CurrenWindow.Close();
            CurrenWindow = null;
        }

        private void CreatWindow(Type type)
        {
            GameObject windowPrefab = _staticDataService.GetWindow(type).gameObject;
            CurrenWindow = GameObject.Instantiate(windowPrefab, _menuCanvas).GetComponent<Window>();
            CurrenWindow.Construct(_diContainer);
            _windows.Add(CurrenWindow.GetType(), CurrenWindow);
        }
    }
}