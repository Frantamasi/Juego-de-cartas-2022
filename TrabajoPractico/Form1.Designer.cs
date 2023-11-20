namespace TrabajoPractico
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.mazopc = new System.Windows.Forms.PictureBox();
            this.mazojug = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.MazoEnMesa = new System.Windows.Forms.PictureBox();
            this.carta3PC = new System.Windows.Forms.PictureBox();
            this.carta2PC = new System.Windows.Forms.PictureBox();
            this.carta1PC = new System.Windows.Forms.PictureBox();
            this.carta3J1 = new System.Windows.Forms.PictureBox();
            this.carta2J1 = new System.Windows.Forms.PictureBox();
            this.carta1J1 = new System.Windows.Forms.PictureBox();
            this.botonRepartir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mazopc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazojug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MazoEnMesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta3PC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta2PC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta1PC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta3J1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta2J1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta1J1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(979, 493);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(36, 20);
            this.textBox1.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(979, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(36, 20);
            this.textBox2.TabIndex = 15;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // mazopc
            // 
            this.mazopc.Location = new System.Drawing.Point(898, 12);
            this.mazopc.Name = "mazopc";
            this.mazopc.Size = new System.Drawing.Size(75, 132);
            this.mazopc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mazopc.TabIndex = 13;
            this.mazopc.TabStop = false;
            // 
            // mazojug
            // 
            this.mazojug.Location = new System.Drawing.Point(898, 399);
            this.mazojug.Name = "mazojug";
            this.mazojug.Size = new System.Drawing.Size(75, 132);
            this.mazojug.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mazojug.TabIndex = 12;
            this.mazojug.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Location = new System.Drawing.Point(484, 212);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(62, 115);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 11;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(579, 212);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(62, 115);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 10;
            this.pictureBox8.TabStop = false;
            // 
            // MazoEnMesa
            // 
            this.MazoEnMesa.Image = global::TrabajoPractico.Properties.Resources.CartaVacia;
            this.MazoEnMesa.Location = new System.Drawing.Point(78, 143);
            this.MazoEnMesa.Name = "MazoEnMesa";
            this.MazoEnMesa.Size = new System.Drawing.Size(148, 260);
            this.MazoEnMesa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MazoEnMesa.TabIndex = 9;
            this.MazoEnMesa.TabStop = false;
            this.MazoEnMesa.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // carta3PC
            // 
            this.carta3PC.Location = new System.Drawing.Point(613, 12);
            this.carta3PC.Name = "carta3PC";
            this.carta3PC.Size = new System.Drawing.Size(75, 132);
            this.carta3PC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta3PC.TabIndex = 8;
            this.carta3PC.TabStop = false;
            this.carta3PC.Click += new System.EventHandler(this.carta3PC_Click);
            // 
            // carta2PC
            // 
            this.carta2PC.Location = new System.Drawing.Point(522, 12);
            this.carta2PC.Name = "carta2PC";
            this.carta2PC.Size = new System.Drawing.Size(75, 132);
            this.carta2PC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta2PC.TabIndex = 7;
            this.carta2PC.TabStop = false;
            this.carta2PC.Click += new System.EventHandler(this.carta2PC_Click);
            // 
            // carta1PC
            // 
            this.carta1PC.Location = new System.Drawing.Point(429, 12);
            this.carta1PC.Name = "carta1PC";
            this.carta1PC.Size = new System.Drawing.Size(75, 132);
            this.carta1PC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta1PC.TabIndex = 6;
            this.carta1PC.TabStop = false;
            this.carta1PC.Click += new System.EventHandler(this.carta1PC_Click);
            // 
            // carta3J1
            // 
            this.carta3J1.Location = new System.Drawing.Point(613, 399);
            this.carta3J1.Name = "carta3J1";
            this.carta3J1.Size = new System.Drawing.Size(75, 132);
            this.carta3J1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta3J1.TabIndex = 5;
            this.carta3J1.TabStop = false;
            this.carta3J1.Click += new System.EventHandler(this.carta3J1_Click);
            // 
            // carta2J1
            // 
            this.carta2J1.Location = new System.Drawing.Point(522, 399);
            this.carta2J1.Name = "carta2J1";
            this.carta2J1.Size = new System.Drawing.Size(75, 132);
            this.carta2J1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta2J1.TabIndex = 3;
            this.carta2J1.TabStop = false;
            this.carta2J1.Click += new System.EventHandler(this.carta2J1_Click);
            // 
            // carta1J1
            // 
            this.carta1J1.Location = new System.Drawing.Point(429, 399);
            this.carta1J1.Name = "carta1J1";
            this.carta1J1.Size = new System.Drawing.Size(75, 132);
            this.carta1J1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta1J1.TabIndex = 1;
            this.carta1J1.TabStop = false;
            this.carta1J1.Click += new System.EventHandler(this.carta1J1_Click);
            // 
            // botonRepartir
            // 
            this.botonRepartir.Location = new System.Drawing.Point(855, 246);
            this.botonRepartir.Name = "botonRepartir";
            this.botonRepartir.Size = new System.Drawing.Size(118, 54);
            this.botonRepartir.TabIndex = 16;
            this.botonRepartir.Text = "REPARTIR";
            this.botonRepartir.UseVisualStyleBackColor = true;
            this.botonRepartir.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1100, 601);
            this.Controls.Add(this.botonRepartir);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.mazopc);
            this.Controls.Add(this.mazojug);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.MazoEnMesa);
            this.Controls.Add(this.carta3PC);
            this.Controls.Add(this.carta2PC);
            this.Controls.Add(this.carta1PC);
            this.Controls.Add(this.carta3J1);
            this.Controls.Add(this.carta2J1);
            this.Controls.Add(this.carta1J1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mazopc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazojug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MazoEnMesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta3PC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta2PC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta1PC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta3J1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta2J1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta1J1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox carta1J1;
        private System.Windows.Forms.PictureBox carta2J1;
        private System.Windows.Forms.PictureBox carta3J1;
        private System.Windows.Forms.PictureBox carta3PC;
        private System.Windows.Forms.PictureBox carta2PC;
        private System.Windows.Forms.PictureBox carta1PC;
        private System.Windows.Forms.PictureBox MazoEnMesa;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox mazojug;
        private System.Windows.Forms.PictureBox mazopc;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button botonRepartir;
    }
}

