using System;
using System.Windows.Forms;

namespace GoogleMini.UI.CustomControls
{
    public class NoMouseEventsControl : Control
    {
        public NoMouseEventsControl()
        {
            DoubleBuffered = true;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = (-1);

            if (m.Msg == WM_NCHITTEST && !DesignMode)
            {
                m.Result = (IntPtr)HTTRANSPARENT;
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
