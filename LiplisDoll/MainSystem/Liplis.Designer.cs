namespace Liplis.MainSystem
{
    partial class Liplis
    {

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        protected void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Liplis));
            this.SuspendLayout();
            // 
            // Liplis
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Liplis";
            this.Text = "Liplis";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Liplis_FormClosing);
            this.Load += new System.EventHandler(this.Liplis_Load);
            this.Click += new System.EventHandler(this.Liplis_Click);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Liplis_DragEnter);
            this.DoubleClick += new System.EventHandler(this.Liplis_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Liplis_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Liplis_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Liplis_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Liplis_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Liplis_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Liplis_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Liplis_MouseUp);
            this.Resize += new System.EventHandler(this.Liplis_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
    }
}

