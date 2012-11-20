using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gdipath
{
   public class Input
    {

        #region fields
        protected bool accept;
        #endregion

        #region Keys API
        public bool Accept { get { return accept; } }
        #endregion

        private List<bool> keyArray;

        public Input()
        {
            keyArray = new List<bool>();
            keyArray.Add(accept);
        }
        
        public void KeyDown(object sender, KeyEventArgs e)
        {
        }
        
        public void KeyUp(object sender, KeyEventArgs e)
        {
        }
        
        public void KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                accept = true;
            }
        }

        public void ClearInput()
        {
            accept = false;
        }
    }
}
