namespace Proyecto_TopFilter
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.Video_pictureBox = new System.Windows.Forms.PictureBox();
            this.cargarVideo_btn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TinteAzulBtn = new System.Windows.Forms.Button();
            this.TinteVerdeBtn = new System.Windows.Forms.Button();
            this.TinteRojoBtn = new System.Windows.Forms.Button();
            this.InvertirBtn = new System.Windows.Forms.Button();
            this.OjodePezBtn = new System.Windows.Forms.Button();
            this.RelieveBtn = new System.Windows.Forms.Button();
            this.RuidoBtn = new System.Windows.Forms.Button();
            this.PixeladoBtn = new System.Windows.Forms.Button();
            this.ContrasteBtn = new System.Windows.Forms.Button();
            this.AberracionBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button14 = new System.Windows.Forms.Button();
            this.detectarColor_menuBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.editarImagen_menuBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Salir_pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.revertirCambios_btn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.HistoRojo_pictureBox = new System.Windows.Forms.PictureBox();
            this.HistoRGB_pictureBox = new System.Windows.Forms.PictureBox();
            this.HistoVerde_pictureBox = new System.Windows.Forms.PictureBox();
            this.HistoAzul_pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Video_pictureBox)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Salir_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistoRojo_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistoRGB_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistoVerde_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistoAzul_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // Video_pictureBox
            // 
            this.Video_pictureBox.BackColor = System.Drawing.Color.Black;
            this.Video_pictureBox.Location = new System.Drawing.Point(276, 245);
            this.Video_pictureBox.Name = "Video_pictureBox";
            this.Video_pictureBox.Size = new System.Drawing.Size(540, 405);
            this.Video_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Video_pictureBox.TabIndex = 45;
            this.Video_pictureBox.TabStop = false;
            // 
            // cargarVideo_btn
            // 
            this.cargarVideo_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.cargarVideo_btn.FlatAppearance.BorderSize = 0;
            this.cargarVideo_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cargarVideo_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cargarVideo_btn.ForeColor = System.Drawing.Color.White;
            this.cargarVideo_btn.Image = ((System.Drawing.Image)(resources.GetObject("cargarVideo_btn.Image")));
            this.cargarVideo_btn.Location = new System.Drawing.Point(276, 194);
            this.cargarVideo_btn.Name = "cargarVideo_btn";
            this.cargarVideo_btn.Size = new System.Drawing.Size(133, 42);
            this.cargarVideo_btn.TabIndex = 44;
            this.cargarVideo_btn.Text = "   Cargar";
            this.cargarVideo_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cargarVideo_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cargarVideo_btn.UseVisualStyleBackColor = false;
            this.cargarVideo_btn.Click += new System.EventHandler(this.cargarVideo_btn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TinteAzulBtn);
            this.panel3.Controls.Add(this.TinteVerdeBtn);
            this.panel3.Controls.Add(this.TinteRojoBtn);
            this.panel3.Controls.Add(this.InvertirBtn);
            this.panel3.Controls.Add(this.OjodePezBtn);
            this.panel3.Controls.Add(this.RelieveBtn);
            this.panel3.Controls.Add(this.RuidoBtn);
            this.panel3.Controls.Add(this.PixeladoBtn);
            this.panel3.Controls.Add(this.ContrasteBtn);
            this.panel3.Controls.Add(this.AberracionBtn);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 698);
            this.panel3.TabIndex = 38;
            // 
            // TinteAzulBtn
            // 
            this.TinteAzulBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TinteAzulBtn.FlatAppearance.BorderSize = 0;
            this.TinteAzulBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TinteAzulBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TinteAzulBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TinteAzulBtn.ForeColor = System.Drawing.Color.White;
            this.TinteAzulBtn.Location = new System.Drawing.Point(37, 528);
            this.TinteAzulBtn.Name = "TinteAzulBtn";
            this.TinteAzulBtn.Size = new System.Drawing.Size(180, 42);
            this.TinteAzulBtn.TabIndex = 10;
            this.TinteAzulBtn.Text = "Azul";
            this.TinteAzulBtn.UseVisualStyleBackColor = false;
            this.TinteAzulBtn.Click += new System.EventHandler(this.TinteAzulBtn_Click);
            // 
            // TinteVerdeBtn
            // 
            this.TinteVerdeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TinteVerdeBtn.FlatAppearance.BorderSize = 0;
            this.TinteVerdeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TinteVerdeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TinteVerdeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TinteVerdeBtn.ForeColor = System.Drawing.Color.White;
            this.TinteVerdeBtn.Location = new System.Drawing.Point(37, 480);
            this.TinteVerdeBtn.Name = "TinteVerdeBtn";
            this.TinteVerdeBtn.Size = new System.Drawing.Size(180, 42);
            this.TinteVerdeBtn.TabIndex = 9;
            this.TinteVerdeBtn.Text = "Verde";
            this.TinteVerdeBtn.UseVisualStyleBackColor = false;
            this.TinteVerdeBtn.Click += new System.EventHandler(this.TinteVerdeBtn_Click);
            // 
            // TinteRojoBtn
            // 
            this.TinteRojoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TinteRojoBtn.FlatAppearance.BorderSize = 0;
            this.TinteRojoBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TinteRojoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TinteRojoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TinteRojoBtn.ForeColor = System.Drawing.Color.White;
            this.TinteRojoBtn.Location = new System.Drawing.Point(37, 432);
            this.TinteRojoBtn.Name = "TinteRojoBtn";
            this.TinteRojoBtn.Size = new System.Drawing.Size(180, 42);
            this.TinteRojoBtn.TabIndex = 8;
            this.TinteRojoBtn.Text = "Rojo";
            this.TinteRojoBtn.UseVisualStyleBackColor = false;
            this.TinteRojoBtn.Click += new System.EventHandler(this.TinteRojoBtn_Click);
            // 
            // InvertirBtn
            // 
            this.InvertirBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.InvertirBtn.FlatAppearance.BorderSize = 0;
            this.InvertirBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.InvertirBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InvertirBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvertirBtn.ForeColor = System.Drawing.Color.White;
            this.InvertirBtn.Location = new System.Drawing.Point(37, 384);
            this.InvertirBtn.Name = "InvertirBtn";
            this.InvertirBtn.Size = new System.Drawing.Size(180, 42);
            this.InvertirBtn.TabIndex = 7;
            this.InvertirBtn.Text = "Invertir";
            this.InvertirBtn.UseVisualStyleBackColor = false;
            this.InvertirBtn.Click += new System.EventHandler(this.InvertirBtn_Click);
            // 
            // OjodePezBtn
            // 
            this.OjodePezBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.OjodePezBtn.FlatAppearance.BorderSize = 0;
            this.OjodePezBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OjodePezBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OjodePezBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OjodePezBtn.ForeColor = System.Drawing.Color.White;
            this.OjodePezBtn.Location = new System.Drawing.Point(37, 336);
            this.OjodePezBtn.Name = "OjodePezBtn";
            this.OjodePezBtn.Size = new System.Drawing.Size(180, 42);
            this.OjodePezBtn.TabIndex = 6;
            this.OjodePezBtn.Text = "Ojo de pez";
            this.OjodePezBtn.UseVisualStyleBackColor = false;
            this.OjodePezBtn.Click += new System.EventHandler(this.OjodePezBtn_Click);
            // 
            // RelieveBtn
            // 
            this.RelieveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.RelieveBtn.FlatAppearance.BorderSize = 0;
            this.RelieveBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RelieveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RelieveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RelieveBtn.ForeColor = System.Drawing.Color.White;
            this.RelieveBtn.Location = new System.Drawing.Point(37, 144);
            this.RelieveBtn.Name = "RelieveBtn";
            this.RelieveBtn.Size = new System.Drawing.Size(180, 42);
            this.RelieveBtn.TabIndex = 5;
            this.RelieveBtn.Text = "Relieve";
            this.RelieveBtn.UseVisualStyleBackColor = false;
            this.RelieveBtn.Click += new System.EventHandler(this.RelieveBtn_Click);
            // 
            // RuidoBtn
            // 
            this.RuidoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.RuidoBtn.FlatAppearance.BorderSize = 0;
            this.RuidoBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RuidoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RuidoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RuidoBtn.ForeColor = System.Drawing.Color.White;
            this.RuidoBtn.Location = new System.Drawing.Point(37, 240);
            this.RuidoBtn.Name = "RuidoBtn";
            this.RuidoBtn.Size = new System.Drawing.Size(180, 42);
            this.RuidoBtn.TabIndex = 4;
            this.RuidoBtn.Text = "Ruido";
            this.RuidoBtn.UseVisualStyleBackColor = false;
            this.RuidoBtn.Click += new System.EventHandler(this.RuidoBtn_Click);
            // 
            // PixeladoBtn
            // 
            this.PixeladoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PixeladoBtn.FlatAppearance.BorderSize = 0;
            this.PixeladoBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PixeladoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PixeladoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PixeladoBtn.ForeColor = System.Drawing.Color.White;
            this.PixeladoBtn.Location = new System.Drawing.Point(37, 288);
            this.PixeladoBtn.Name = "PixeladoBtn";
            this.PixeladoBtn.Size = new System.Drawing.Size(180, 42);
            this.PixeladoBtn.TabIndex = 3;
            this.PixeladoBtn.Text = "Pixelado";
            this.PixeladoBtn.UseVisualStyleBackColor = false;
            this.PixeladoBtn.Click += new System.EventHandler(this.PixeladoBtn_Click);
            // 
            // ContrasteBtn
            // 
            this.ContrasteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ContrasteBtn.FlatAppearance.BorderSize = 0;
            this.ContrasteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ContrasteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContrasteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContrasteBtn.ForeColor = System.Drawing.Color.White;
            this.ContrasteBtn.Location = new System.Drawing.Point(37, 192);
            this.ContrasteBtn.Name = "ContrasteBtn";
            this.ContrasteBtn.Size = new System.Drawing.Size(180, 42);
            this.ContrasteBtn.TabIndex = 2;
            this.ContrasteBtn.Text = "Contraste";
            this.ContrasteBtn.UseVisualStyleBackColor = false;
            this.ContrasteBtn.Click += new System.EventHandler(this.ContrasteBtn_Click);
            // 
            // AberracionBtn
            // 
            this.AberracionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.AberracionBtn.FlatAppearance.BorderSize = 0;
            this.AberracionBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AberracionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AberracionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AberracionBtn.ForeColor = System.Drawing.Color.White;
            this.AberracionBtn.Location = new System.Drawing.Point(37, 96);
            this.AberracionBtn.Name = "AberracionBtn";
            this.AberracionBtn.Size = new System.Drawing.Size(180, 42);
            this.AberracionBtn.TabIndex = 1;
            this.AberracionBtn.Text = "Aberración cromática";
            this.AberracionBtn.UseVisualStyleBackColor = false;
            this.AberracionBtn.Click += new System.EventHandler(this.AberracionBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtros:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.panel2.Controls.Add(this.button14);
            this.panel2.Controls.Add(this.detectarColor_menuBtn);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.editarImagen_menuBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 61);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1366, 61);
            this.panel2.TabIndex = 37;
            // 
            // button14
            // 
            this.button14.FlatAppearance.BorderSize = 0;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.Black;
            this.button14.Location = new System.Drawing.Point(1123, 0);
            this.button14.Margin = new System.Windows.Forms.Padding(2);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(205, 61);
            this.button14.TabIndex = 5;
            this.button14.Text = "Manual de usuario";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // detectarColor_menuBtn
            // 
            this.detectarColor_menuBtn.FlatAppearance.BorderSize = 0;
            this.detectarColor_menuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detectarColor_menuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detectarColor_menuBtn.ForeColor = System.Drawing.Color.Black;
            this.detectarColor_menuBtn.Location = new System.Drawing.Point(388, 0);
            this.detectarColor_menuBtn.Margin = new System.Windows.Forms.Padding(2);
            this.detectarColor_menuBtn.Name = "detectarColor_menuBtn";
            this.detectarColor_menuBtn.Size = new System.Drawing.Size(172, 61);
            this.detectarColor_menuBtn.TabIndex = 4;
            this.detectarColor_menuBtn.Text = "Cámara";
            this.detectarColor_menuBtn.UseVisualStyleBackColor = true;
            this.detectarColor_menuBtn.Click += new System.EventHandler(this.detectarColor_menuBtn_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(212, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 61);
            this.button2.TabIndex = 3;
            this.button2.Text = "Editar vídeo";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // editarImagen_menuBtn
            // 
            this.editarImagen_menuBtn.FlatAppearance.BorderSize = 0;
            this.editarImagen_menuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editarImagen_menuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editarImagen_menuBtn.ForeColor = System.Drawing.Color.Black;
            this.editarImagen_menuBtn.Location = new System.Drawing.Point(40, 0);
            this.editarImagen_menuBtn.Margin = new System.Windows.Forms.Padding(2);
            this.editarImagen_menuBtn.Name = "editarImagen_menuBtn";
            this.editarImagen_menuBtn.Size = new System.Drawing.Size(172, 61);
            this.editarImagen_menuBtn.TabIndex = 2;
            this.editarImagen_menuBtn.Text = "Editar imagen";
            this.editarImagen_menuBtn.UseVisualStyleBackColor = true;
            this.editarImagen_menuBtn.Click += new System.EventHandler(this.editarImagen_menuBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(142)))), ((int)(((byte)(148)))));
            this.panel1.Controls.Add(this.Salir_pictureBox);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 61);
            this.panel1.TabIndex = 36;
            // 
            // Salir_pictureBox
            // 
            this.Salir_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Salir_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("Salir_pictureBox.Image")));
            this.Salir_pictureBox.Location = new System.Drawing.Point(1288, 12);
            this.Salir_pictureBox.Name = "Salir_pictureBox";
            this.Salir_pictureBox.Size = new System.Drawing.Size(40, 40);
            this.Salir_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Salir_pictureBox.TabIndex = 2;
            this.Salir_pictureBox.TabStop = false;
            this.Salir_pictureBox.Click += new System.EventHandler(this.Salir_pictureBox_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1366, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "MP4 File|*.mp4|All File|*.*";
            this.openFileDialog1.Title = "Cargar Video";
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.Location = new System.Drawing.Point(477, 671);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(133, 42);
            this.btnPlay.TabIndex = 46;
            this.btnPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ForeColor = System.Drawing.Color.White;
            this.btnPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.Image")));
            this.btnPause.Location = new System.Drawing.Point(329, 671);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(133, 42);
            this.btnPause.TabIndex = 47;
            this.btnPause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPause.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(625, 671);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(133, 42);
            this.btnStop.TabIndex = 48;
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // revertirCambios_btn
            // 
            this.revertirCambios_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(105)))), ((int)(((byte)(110)))));
            this.revertirCambios_btn.FlatAppearance.BorderSize = 0;
            this.revertirCambios_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.revertirCambios_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.revertirCambios_btn.ForeColor = System.Drawing.Color.White;
            this.revertirCambios_btn.Image = ((System.Drawing.Image)(resources.GetObject("revertirCambios_btn.Image")));
            this.revertirCambios_btn.Location = new System.Drawing.Point(683, 194);
            this.revertirCambios_btn.Name = "revertirCambios_btn";
            this.revertirCambios_btn.Size = new System.Drawing.Size(133, 42);
            this.revertirCambios_btn.TabIndex = 49;
            this.revertirCambios_btn.Text = "   Revertir";
            this.revertirCambios_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.revertirCambios_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.revertirCambios_btn.UseVisualStyleBackColor = false;
            this.revertirCambios_btn.Click += new System.EventHandler(this.revertirCambios_btn_Click);
            // 
            // HistoRojo_pictureBox
            // 
            this.HistoRojo_pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(171)))), ((int)(((byte)(173)))));
            this.HistoRojo_pictureBox.Location = new System.Drawing.Point(1093, 245);
            this.HistoRojo_pictureBox.Name = "HistoRojo_pictureBox";
            this.HistoRojo_pictureBox.Size = new System.Drawing.Size(256, 170);
            this.HistoRojo_pictureBox.TabIndex = 54;
            this.HistoRojo_pictureBox.TabStop = false;
            this.HistoRojo_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.HistoRojo_pictureBox_Paint);
            // 
            // HistoRGB_pictureBox
            // 
            this.HistoRGB_pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(171)))), ((int)(((byte)(173)))));
            this.HistoRGB_pictureBox.Location = new System.Drawing.Point(831, 245);
            this.HistoRGB_pictureBox.Name = "HistoRGB_pictureBox";
            this.HistoRGB_pictureBox.Size = new System.Drawing.Size(256, 170);
            this.HistoRGB_pictureBox.TabIndex = 55;
            this.HistoRGB_pictureBox.TabStop = false;
            this.HistoRGB_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.HistoRGB_pictureBox_Paint);
            // 
            // HistoVerde_pictureBox
            // 
            this.HistoVerde_pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(171)))), ((int)(((byte)(173)))));
            this.HistoVerde_pictureBox.Location = new System.Drawing.Point(831, 462);
            this.HistoVerde_pictureBox.Name = "HistoVerde_pictureBox";
            this.HistoVerde_pictureBox.Size = new System.Drawing.Size(256, 170);
            this.HistoVerde_pictureBox.TabIndex = 56;
            this.HistoVerde_pictureBox.TabStop = false;
            this.HistoVerde_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.HistoVerde_pictureBox_Paint);
            // 
            // HistoAzul_pictureBox
            // 
            this.HistoAzul_pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(171)))), ((int)(((byte)(173)))));
            this.HistoAzul_pictureBox.Location = new System.Drawing.Point(1093, 462);
            this.HistoAzul_pictureBox.Name = "HistoAzul_pictureBox";
            this.HistoAzul_pictureBox.Size = new System.Drawing.Size(256, 170);
            this.HistoAzul_pictureBox.TabIndex = 57;
            this.HistoAzul_pictureBox.TabStop = false;
            this.HistoAzul_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.HistoAzul_pictureBox_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(831, 201);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(74, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1093, 199);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(74, 55);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 59;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(831, 416);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(74, 55);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 60;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(1093, 416);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(74, 55);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 61;
            this.pictureBox5.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(204)))), ((int)(((byte)(207)))));
            this.ClientSize = new System.Drawing.Size(1366, 820);
            this.Controls.Add(this.HistoAzul_pictureBox);
            this.Controls.Add(this.HistoVerde_pictureBox);
            this.Controls.Add(this.HistoRGB_pictureBox);
            this.Controls.Add(this.HistoRojo_pictureBox);
            this.Controls.Add(this.revertirCambios_btn);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.Video_pictureBox);
            this.Controls.Add(this.cargarVideo_btn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Video_pictureBox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Salir_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistoRojo_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistoRGB_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistoVerde_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistoAzul_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Video_pictureBox;
        private System.Windows.Forms.Button cargarVideo_btn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button TinteAzulBtn;
        private System.Windows.Forms.Button TinteVerdeBtn;
        private System.Windows.Forms.Button TinteRojoBtn;
        private System.Windows.Forms.Button InvertirBtn;
        private System.Windows.Forms.Button OjodePezBtn;
        private System.Windows.Forms.Button RelieveBtn;
        private System.Windows.Forms.Button RuidoBtn;
        private System.Windows.Forms.Button PixeladoBtn;
        private System.Windows.Forms.Button ContrasteBtn;
        private System.Windows.Forms.Button AberracionBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button detectarColor_menuBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button editarImagen_menuBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Salir_pictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button revertirCambios_btn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox HistoRojo_pictureBox;
        private System.Windows.Forms.PictureBox HistoRGB_pictureBox;
        private System.Windows.Forms.PictureBox HistoVerde_pictureBox;
        private System.Windows.Forms.PictureBox HistoAzul_pictureBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}