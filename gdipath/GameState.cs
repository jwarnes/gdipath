
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace gdipath
{
    abstract class GameState
    {
        public bool IsPaused
        {
            get;
            set;
        }
        public bool IsVisible
        {
            get;
            set;
        }

        protected GameStateManager manager;

        public GameState(GameStateManager manager)
        {
            this.manager = manager;
            IsPaused = false;
            IsVisible = true;

            this.Load();
        }

        public abstract void Load();
        public abstract void Input();
        public abstract void Process();
        public abstract void Draw(Graphics g);
        

        public void Kill()
        {
            manager.Remove(this);
        }

        public void ChangeState(GameState state)
        {
            manager.Add(state);
            this.Kill();
        }
    }
}
