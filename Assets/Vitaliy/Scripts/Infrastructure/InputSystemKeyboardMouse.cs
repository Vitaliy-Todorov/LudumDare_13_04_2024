using System;
using UnityEngine;

namespace Infrastructure
{
    public class InputSystemKeyboardMouse : IInputSystem
    {
        public event Action OnEscClicked;
        public void Update()
        {
            ClickOnEsc();
        }

        private void ClickOnEsc()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
                OnEscClicked?.Invoke();
        }
    }
}