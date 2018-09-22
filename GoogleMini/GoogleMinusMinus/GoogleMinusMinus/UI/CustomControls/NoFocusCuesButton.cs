using System.Windows.Forms;

namespace GoogleMini.UI.CustomControls
{
    class NoFocusCuesButton: Button
    {
        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
    }
}
