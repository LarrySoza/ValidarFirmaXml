namespace ValidarFirmaXml
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnValidarXml = new System.Windows.Forms.Button();
            this.btnValidarXmlDeZip = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnValidarXml
            // 
            this.btnValidarXml.Location = new System.Drawing.Point(12, 12);
            this.btnValidarXml.Name = "btnValidarXml";
            this.btnValidarXml.Size = new System.Drawing.Size(102, 23);
            this.btnValidarXml.TabIndex = 2;
            this.btnValidarXml.Text = "Validar XML";
            this.btnValidarXml.UseVisualStyleBackColor = true;
            this.btnValidarXml.Click += new System.EventHandler(this.btnValidarXml_Click);
            // 
            // btnValidarXmlDeZip
            // 
            this.btnValidarXmlDeZip.Location = new System.Drawing.Point(120, 12);
            this.btnValidarXmlDeZip.Name = "btnValidarXmlDeZip";
            this.btnValidarXmlDeZip.Size = new System.Drawing.Size(102, 23);
            this.btnValidarXmlDeZip.TabIndex = 4;
            this.btnValidarXmlDeZip.Text = "Validar XML ZIP";
            this.btnValidarXmlDeZip.UseVisualStyleBackColor = true;
            this.btnValidarXmlDeZip.Click += new System.EventHandler(this.btnValidarXmlDeZip_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.Location = new System.Drawing.Point(14, 41);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(632, 193);
            this.txtInfo.TabIndex = 5;
            this.txtInfo.Text = "";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 246);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnValidarXmlDeZip);
            this.Controls.Add(this.btnValidarXml);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validar Xml";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnValidarXml;
        private System.Windows.Forms.Button btnValidarXmlDeZip;
        private System.Windows.Forms.RichTextBox txtInfo;
    }
}

