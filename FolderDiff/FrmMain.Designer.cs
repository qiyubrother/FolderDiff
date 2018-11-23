namespace FolderDiff
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbA = new System.Windows.Forms.RadioButton();
            this.rbB = new System.Windows.Forms.RadioButton();
            this.btnExcute = new System.Windows.Forms.Button();
            this.txtDirTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDirA = new System.Windows.Forms.TextBox();
            this.txtDirB = new System.Windows.Forms.TextBox();
            this.btnSelA = new System.Windows.Forms.Button();
            this.btnSelB = new System.Windows.Forms.Button();
            this.btnSelTo = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件夹A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "文件夹B";
            // 
            // rbA
            // 
            this.rbA.AutoSize = true;
            this.rbA.Checked = true;
            this.rbA.Location = new System.Drawing.Point(20, 59);
            this.rbA.Name = "rbA";
            this.rbA.Size = new System.Drawing.Size(131, 16);
            this.rbA.TabIndex = 6;
            this.rbA.TabStop = true;
            this.rbA.Text = "A中有B中没有的文件";
            this.rbA.UseVisualStyleBackColor = true;
            // 
            // rbB
            // 
            this.rbB.AutoSize = true;
            this.rbB.Location = new System.Drawing.Point(161, 59);
            this.rbB.Name = "rbB";
            this.rbB.Size = new System.Drawing.Size(131, 16);
            this.rbB.TabIndex = 7;
            this.rbB.Text = "B中有A中没有的文件";
            this.rbB.UseVisualStyleBackColor = true;
            // 
            // btnExcute
            // 
            this.btnExcute.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExcute.Location = new System.Drawing.Point(395, 142);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(75, 21);
            this.btnExcute.TabIndex = 13;
            this.btnExcute.Text = "开始比较";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // txtDirTo
            // 
            this.txtDirTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirTo.Location = new System.Drawing.Point(117, 108);
            this.txtDirTo.Name = "txtDirTo";
            this.txtDirTo.Size = new System.Drawing.Size(668, 21);
            this.txtDirTo.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "保存差异到文件夹";
            // 
            // txtDirA
            // 
            this.txtDirA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirA.Location = new System.Drawing.Point(74, 11);
            this.txtDirA.Name = "txtDirA";
            this.txtDirA.Size = new System.Drawing.Size(711, 21);
            this.txtDirA.TabIndex = 1;
            // 
            // txtDirB
            // 
            this.txtDirB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirB.Location = new System.Drawing.Point(74, 35);
            this.txtDirB.Name = "txtDirB";
            this.txtDirB.Size = new System.Drawing.Size(711, 21);
            this.txtDirB.TabIndex = 4;
            // 
            // btnSelA
            // 
            this.btnSelA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelA.Location = new System.Drawing.Point(786, 11);
            this.btnSelA.Name = "btnSelA";
            this.btnSelA.Size = new System.Drawing.Size(60, 21);
            this.btnSelA.TabIndex = 2;
            this.btnSelA.Text = "选择...";
            this.btnSelA.UseVisualStyleBackColor = true;
            this.btnSelA.Click += new System.EventHandler(this.btnSelA_Click);
            // 
            // btnSelB
            // 
            this.btnSelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelB.Location = new System.Drawing.Point(786, 35);
            this.btnSelB.Name = "btnSelB";
            this.btnSelB.Size = new System.Drawing.Size(60, 21);
            this.btnSelB.TabIndex = 5;
            this.btnSelB.Text = "选择...";
            this.btnSelB.UseVisualStyleBackColor = true;
            this.btnSelB.Click += new System.EventHandler(this.btnSelB_Click);
            // 
            // btnSelTo
            // 
            this.btnSelTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelTo.Location = new System.Drawing.Point(786, 108);
            this.btnSelTo.Name = "btnSelTo";
            this.btnSelTo.Size = new System.Drawing.Size(60, 21);
            this.btnSelTo.TabIndex = 12;
            this.btnSelTo.Text = "选择...";
            this.btnSelTo.UseVisualStyleBackColor = true;
            this.btnSelTo.Click += new System.EventHandler(this.btnSelTo_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 172);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(864, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsbl
            // 
            this.tsbl.Name = "tsbl";
            this.tsbl.Size = new System.Drawing.Size(849, 17);
            this.tsbl.Spring = true;
            this.tsbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(74, 81);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(711, 21);
            this.txtFilter.TabIndex = 9;
            this.txtFilter.Text = "*.*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "文件过滤";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 194);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSelTo);
            this.Controls.Add(this.btnSelB);
            this.Controls.Add(this.btnSelA);
            this.Controls.Add(this.txtDirB);
            this.Controls.Add(this.txtDirA);
            this.Controls.Add(this.txtDirTo);
            this.Controls.Add(this.btnExcute);
            this.Controls.Add(this.rbB);
            this.Controls.Add(this.rbA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件夹差异比较";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbA;
        private System.Windows.Forms.RadioButton rbB;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.TextBox txtDirTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDirA;
        private System.Windows.Forms.TextBox txtDirB;
        private System.Windows.Forms.Button btnSelA;
        private System.Windows.Forms.Button btnSelB;
        private System.Windows.Forms.Button btnSelTo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsbl;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label4;
    }
}

