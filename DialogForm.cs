using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace i8008_emu_GUI
{
    public partial class DialogForm : Form
    {
        public DialogForm(string title, string invitation)
        {
            InitializeComponent();
            this.Text = title;
            InvitationLabel.Text = invitation;
        }

        public string InputValue
        {
            get
            {
                return InputBox.Text;
            }
        }

        private void OK_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
