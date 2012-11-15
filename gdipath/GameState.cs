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
        }
        
        public abstract void Draw(Graphics g);
        public abstract void Process();

        public void Kill()
        {
            manager.Remove(this);
        }
    }
}
