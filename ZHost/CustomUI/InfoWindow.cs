using System.Windows.Forms;

namespace ZHost.CustomUI
{
    public partial class InfoWindow : Form
    {
        #region Properties

        string moniker = "Remote command";
        public string Moniker
        {
            get { return moniker; }
            set
            {
                moniker = value;
                this.Text = string.Format("{0} - {1}", hostMoniker, moniker);
            }
        }

        string hostMoniker = string.Empty;
        public string HostMoniker
        {
            set
            {
                hostMoniker = value;
                this.Text = string.Format("{0} - {1}", hostMoniker, moniker);
            }
            get
            {
                return hostMoniker;
            }
        }

        public string InfoText
        {
            get { return infoTxb.Text; }
            set { infoTxb.Text = value; }
        }

        #endregion

        #region Constructor

        public InfoWindow()
        {
            InitializeComponent();
        }

        #endregion
    }
}
