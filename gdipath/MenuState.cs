using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace gdipath
{
    class MenuState : GameState
    {
        #region Fields

        #endregion

        public MenuState(GameStateManager manager): base (manager)
        {
            this.manager = manager;
        }

        public override void Load()
        {
            
        }

        public override void Input()
        {
            Input input = manager.Game.Input;
            if (input.Accept)
            {
                Kill();
            }
        }


        public override void Process()
        {
           
        }

        public override void Draw(Graphics g)
        {  
            Image face = Image.FromFile(@"img\butt.gif");
            g.DrawString("Pathfinding Example", new Font("Verdana", 16, FontStyle.Bold), Brushes.White,
                 30, 100);

            g.DrawString("PUSH ENTER TO GO TO THE NEXT THING", new Font("Verdana", 14, FontStyle.Regular), Brushes.White,
                 74, 200);

            g.DrawImage(face, 50, 50);
        }

    }
}
