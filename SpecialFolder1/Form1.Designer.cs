namespace SpecialFolder
{
    partial class mainUI
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainUI));
            this.pwTB = new System.Windows.Forms.TextBox();
            this.lockBtn = new System.Windows.Forms.Button();
            this.unlockBtn = new System.Windows.Forms.Button();
            this.pwLabel = new System.Windows.Forms.Label();
            this.pathTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browseBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // pwTB
            // 
            resources.ApplyResources(this.pwTB, "pwTB");
            this.pwTB.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.pwTB.Name = "pwTB";
            // 
            // lockBtn
            // 
            resources.ApplyResources(this.lockBtn, "lockBtn");
            this.lockBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.lockBtn.Name = "lockBtn";
            this.lockBtn.UseVisualStyleBackColor = true;
            this.lockBtn.Click += new System.EventHandler(this.LockBtn_Click);
            // 
            // unlockBtn
            // 
            resources.ApplyResources(this.unlockBtn, "unlockBtn");
            this.unlockBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.unlockBtn.Name = "unlockBtn";
            this.unlockBtn.UseVisualStyleBackColor = true;
            this.unlockBtn.Click += new System.EventHandler(this.UnlockBtn_Click);
            // 
            // pwLabel
            // 
            resources.ApplyResources(this.pwLabel, "pwLabel");
            this.pwLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.pwLabel.Name = "pwLabel";
            // 
            // pathTB
            // 
            resources.ApplyResources(this.pathTB, "pathTB");
            this.pathTB.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.pathTB.Name = "pathTB";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.label1.Name = "label1";
            // 
            // browseBtn
            // 
            resources.ApplyResources(this.browseBtn, "browseBtn");
            this.browseBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // mainUI
            // 
            resources.ApplyResources(this, "$this");
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTB);
            this.Controls.Add(this.pwLabel);
            this.Controls.Add(this.unlockBtn);
            this.Controls.Add(this.lockBtn);
            this.Controls.Add(this.pwTB);
            this.Name = "mainUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pwTB;
        private System.Windows.Forms.Button lockBtn;
        private System.Windows.Forms.Button unlockBtn;
        private System.Windows.Forms.Label pwLabel;
        private System.Windows.Forms.TextBox pathTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

