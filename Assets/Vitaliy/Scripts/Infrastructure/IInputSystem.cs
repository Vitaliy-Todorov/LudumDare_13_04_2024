using System;

namespace Infrastructure
{
    public interface IInputSystem
    {
        public event Action OnEscClicked;
        public void Update();
    }
}