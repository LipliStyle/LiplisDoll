//=======================================================================
//  ClassName : InputWindow
// ■概要      : LiplisDollのメインクラス
//
// Copyright(c) 2014 LipliStyle さちん MITライセンス
//=======================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Liplis.MainSystem
{
    public partial class InputWindow : Form
    {
        ///=====================================
        /// リプリス
        private Liplis lips;

        public InputWindow(Liplis lips)
        {
            this.lips = lips;
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.lips.onRecive(99, txtInput.Text);
        }
    }
}
