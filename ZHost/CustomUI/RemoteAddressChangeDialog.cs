using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ZLibrary;

namespace ZHost.CustomUI
{
    public partial class RemoteAddressChangeDialog : Form
    {
        #region Properties

        string moniker = "Remote address change";
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

        public ZAddress CurrentTargetAddress
        {
            get { return (ZAddress)Enum.Parse(typeof(ZAddress), UIUtils.TryGetCbxItem(currentTargetAddressCbx)); }
            set { UIUtils.TrySetCbxItem(currentTargetAddressCbx, value.ToString()); }
        }

        public ZAddress NewTargetAddress
        {
            get { return (ZAddress)Enum.Parse(typeof(ZAddress), UIUtils.TryGetCbxItem(newTargetAddressCbx)); }
            set { UIUtils.TrySetCbxItem(newTargetAddressCbx, value.ToString()); }
        }
        

        #endregion

        #region Constructor

        public RemoteAddressChangeDialog()
        {
            InitializeComponent();

            var zaddressesList = new List<string>(Enum.GetNames(typeof(ZAddress)));
            zaddressesList.RemoveAt(zaddressesList.Count - 1);
            var zaddresses = zaddressesList.ToArray();
            currentTargetAddressCbx.Items.AddRange(zaddresses);
            newTargetAddressCbx.Items.AddRange(zaddresses);

            CurrentTargetAddress = ZAddress.Responder_1;
            NewTargetAddress = ZAddress.Responder_2;
        }

        #endregion

        #region Handlers
        
        private void targetAddressCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            okBtn.Enabled = (currentTargetAddressCbx.SelectedItem != null) && (newTargetAddressCbx.SelectedItem != null) &&
                CurrentTargetAddress != NewTargetAddress;
        }

        #endregion        
    }
}
