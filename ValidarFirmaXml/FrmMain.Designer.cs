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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnValidarXml = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            this.btnExtraerClavePublica = new System.Windows.Forms.Button();
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
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.Location = new System.Drawing.Point(14, 41);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(632, 241);
            this.txtInfo.TabIndex = 5;
            this.txtInfo.Text = "";
            // 
            // btnExtraerClavePublica
            // 
            this.btnExtraerClavePublica.Location = new System.Drawing.Point(513, 12);
            this.btnExtraerClavePublica.Name = "btnExtraerClavePublica";
            this.btnExtraerClavePublica.Size = new System.Drawing.Size(133, 23);
            this.btnExtraerClavePublica.TabIndex = 6;
            this.btnExtraerClavePublica.Text = "Guardar Clave Publica";
            this.btnExtraerClavePublica.UseVisualStyleBackColor = true;
            this.btnExtraerClavePublica.Visible = false;
            this.btnExtraerClavePublica.Click += new System.EventHandler(this.btnExtraerClavePublica_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 294);
            this.Controls.Add(this.btnExtraerClavePublica);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnValidarXml);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(674, 333);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validar Xml";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnValidarXml;
        private System.Windows.Forms.RichTextBox txtInfo;
        private System.Windows.Forms.Button btnExtraerClavePublica;
    }
}

