using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace gdipath
{
    class GameStateManager
    {
        protected List<GameState> states;
        protected mainForm game;

        public mainForm Game
        {
            get { return game; }
        }

        public GameStateManager(mainForm game)
        {
            this.game = game;
            states = new List<GameState>();
        }

        public void Process()
        {
            foreach (GameState state in states)
            {
                if (!state.IsPaused)
                    state.Process();
            }
        }

        public void Draw(Graphics g)
        {
            foreach (GameState state in states)
            {
                if (state.IsVisible)
                    state.Draw(g);
            }
        }

        public void Add(GameState state)
        {
            states.Add(state);
        }

        public void Remove(GameState state)
        {
            states.Remove(state);
        }

    }
}
