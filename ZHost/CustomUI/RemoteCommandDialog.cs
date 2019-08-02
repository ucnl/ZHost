using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using ZLibrary;

namespace ZHost.CustomUI
{
    public partial class RemoteCommandDialog : Form
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

        public ZAddress TargetAddress
        {
            get { return (ZAddress)Enum.Parse(typeof(ZAddress), UIUtils.TryGetCbxItem(targetAddressCbx)); }
            set { UIUtils.TrySetCbxItem(targetAddressCbx, value.ToString()); }
        }

        public CDS_NODE_CMD_Enum RemoteCmdID
        {
            get { return (CDS_NODE_CMD_Enum)Enum.Parse(typeof(CDS_NODE_CMD_Enum), UIUtils.TryGetCbxItem(remoteCommandCbx)); }
            set { UIUtils.TrySetCbxItem(remoteCommandCbx, value.ToString()); }
        }

        #endregion

        #region Constructor

        public RemoteCommandDialog()
        {
            InitializeComponent();

            var zaddressesList = new List<string>(Enum.GetNames(typeof(ZAddress)));
            zaddressesList.RemoveAt(zaddressesList.Count - 1);
            var zaddresses = zaddressesList.ToArray();
            targetAddressCbx.Items.AddRange(zaddresses);
            TargetAddress = ZAddress.Responder_1;

            remoteCommandCbx.Items.AddRange(ZMA.Select_USR_CMDs_Names());          
            RemoteCmdID = CDS_NODE_CMD_Enum.CDS_USR_CMD_0;
        }

        #endregion

        #region Methods

        public void SetCommandsList(IEnumerable<CDS_NODE_CMD_Enum> commands)
        {
            remoteCommandCbx.Items.Clear();
            foreach (var cmd in commands)
                remoteCommandCbx.Items.Add(cmd.ToString());

            if (remoteCommandCbx.Items.Count > 0)
            {
                remoteCommandCbx.SelectedIndex = 0;
            }

            remoteCommandCbx.Enabled = remoteCommandCbx.Items.Count > 1;
        }

        #endregion
    }
}
