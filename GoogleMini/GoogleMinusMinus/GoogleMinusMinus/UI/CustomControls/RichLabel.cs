using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GoogleMini.UI.CustomControls
{
    public class RichLabel : RichTextBox
    {
        public RichLabel()
        {
            this.ReadOnly = true;
            this.TabStop = false;
            this.SetStyle(ControlStyles.Selectable, false);
        }

        protected override void OnEnter(EventArgs e)
        {
            if (!DesignMode) this.Parent.SelectNextControl(this, true, true, true, true);
            base.OnEnter(e);
        }

        protected override void WndProc(ref Message m)
        {
            // Send WM_MOUSEWHEEL messages to the parent
            if (m.Msg == 0x20a) SendMessage(this.Parent.Handle, m.Msg, m.WParam, m.LParam);
            if (m.Msg < 0x201 || m.Msg > 0x20e)
                base.WndProc(ref m);
        }
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}
