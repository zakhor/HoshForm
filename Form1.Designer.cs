using System.Configuration;

namespace HoshForm
{
    partial class HoshForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUrlBoard = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblTimeInterval = new System.Windows.Forms.Label();
            this.lblHN = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tbUrlBoard = new System.Windows.Forms.TextBox();
            this.tbTarget = new System.Windows.Forms.TextBox();
            this.tbHN = new System.Windows.Forms.TextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.numTimeInterval = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUrlBoard
            // 
            this.lblUrlBoard.AutoSize = true;
            this.lblUrlBoard.Location = new System.Drawing.Point(50, 50);
            this.lblUrlBoard.Name = "lblUrlBoard";
            this.lblUrlBoard.Size = new System.Drawing.Size(40, 15);
            this.lblUrlBoard.TabIndex = 0;
            this.lblUrlBoard.Text = "板URL";
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(50, 90);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(92, 15);
            this.lblTarget.TabIndex = 1;
            this.lblTarget.Text = "スレタイ検索ワード";
            // 
            // lblTimeInterval
            // 
            this.lblTimeInterval.AutoSize = true;
            this.lblTimeInterval.Location = new System.Drawing.Point(50, 130);
            this.lblTimeInterval.Name = "lblTimeInterval";
            this.lblTimeInterval.Size = new System.Drawing.Size(91, 15);
            this.lblTimeInterval.TabIndex = 2;
            this.lblTimeInterval.Text = "投稿間隔（秒）";
            // 
            // lblHN
            // 
            this.lblHN.AutoSize = true;
            this.lblHN.Location = new System.Drawing.Point(50, 170);
            this.lblHN.Name = "lblHN";
            this.lblHN.Size = new System.Drawing.Size(31, 15);
            this.lblHN.TabIndex = 3;
            this.lblHN.Text = "名前";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(50, 210);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(89, 30);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "本文\r\n改行で複数登録";
            // 
            // tbUrlBoard
            // 
            this.tbUrlBoard.Location = new System.Drawing.Point(186, 47);
            this.tbUrlBoard.Name = "tbUrlBoard";
            this.tbUrlBoard.Size = new System.Drawing.Size(370, 23);
            this.tbUrlBoard.TabIndex = 5;
            this.tbUrlBoard.Text = ConfigurationManager.AppSettings["DefaultUrlBoard"];
            // 
            // tbTarget
            // 
            this.tbTarget.Location = new System.Drawing.Point(186, 87);
            this.tbTarget.Name = "tbTarget";
            this.tbTarget.Size = new System.Drawing.Size(370, 23);
            this.tbTarget.TabIndex = 6;
            this.tbTarget.Text = ConfigurationManager.AppSettings["DefaultTarget"];
            // 
            // tbHN
            // 
            this.tbHN.Location = new System.Drawing.Point(186, 167);
            this.tbHN.Name = "tbHN";
            this.tbHN.Size = new System.Drawing.Size(370, 23);
            this.tbHN.TabIndex = 8;
            this.tbHN.Text = ConfigurationManager.AppSettings["DefaultHN"];
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(186, 207);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(370, 300);
            this.tbMessage.TabIndex = 9;
            this.tbMessage.Text = ConfigurationManager.AppSettings["DefaultMessage"];
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(270, 540);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "開始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // numTimeInterval
            // 
            this.numTimeInterval.Location = new System.Drawing.Point(186, 128);
            this.numTimeInterval.Name = "numTimeInterval";
            this.numTimeInterval.Size = new System.Drawing.Size(370, 23);
            this.numTimeInterval.TabIndex = 7;
            this.numTimeInterval.Maximum = 10000;
            this.numTimeInterval.Minimum = 10;
            this.numTimeInterval.Value = decimal.Parse(ConfigurationManager.AppSettings["TimeInterval"]);
            // 
            // HoshForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 601);
            this.Controls.Add(this.numTimeInterval);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.tbHN);
            this.Controls.Add(this.tbTarget);
            this.Controls.Add(this.tbUrlBoard);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblHN);
            this.Controls.Add(this.lblTimeInterval);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblUrlBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HoshForm";
            this.Text = "HoshForm";
            ((System.ComponentModel.ISupportInitialize)(this.numTimeInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUrlBoard;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblTimeInterval;
        private System.Windows.Forms.Label lblHN;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox tbUrlBoard;
        private System.Windows.Forms.TextBox tbTarget;
        private System.Windows.Forms.TextBox tbHN;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown numTimeInterval;
    }
}

