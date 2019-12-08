namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bt_cube = new System.Windows.Forms.Button();
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.pyramid = new System.Windows.Forms.Button();
            this.bt_LangTru = new System.Windows.Forms.Button();
            this.bt_texture = new System.Windows.Forms.Button();
            this.bt_pyrtexture = new System.Windows.Forms.Button();
            this.bt_DrawSpace = new System.Windows.Forms.Button();
            this.lb_ListOfImage = new System.Windows.Forms.Label();
            this.lb_NameObject = new System.Windows.Forms.ListBox();
            this.btMauVien = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_cube
            // 
            this.bt_cube.Image = ((System.Drawing.Image)(resources.GetObject("bt_cube.Image")));
            this.bt_cube.Location = new System.Drawing.Point(12, 12);
            this.bt_cube.Name = "bt_cube";
            this.bt_cube.Size = new System.Drawing.Size(47, 39);
            this.bt_cube.TabIndex = 0;
            this.bt_cube.UseVisualStyleBackColor = true;
            this.bt_cube.Click += new System.EventHandler(this.bt_cube_Click);
            // 
            // openGLControl1
            // 
            this.openGLControl1.DrawFPS = false;
            this.openGLControl1.FrameRate = 60;
            this.openGLControl1.Location = new System.Drawing.Point(346, 12);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.FBO;
            this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl1.Size = new System.Drawing.Size(800, 656);
            this.openGLControl1.TabIndex = 1;
            this.openGLControl1.OpenGLInitialized += new System.EventHandler(this.openGLControl1_OpenGLInitialized);
            this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
            this.openGLControl1.Resized += new System.EventHandler(this.openGLControl1_Resized);
            this.openGLControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openGLControl1_KeyDown);
            // 
            // pyramid
            // 
            this.pyramid.Image = ((System.Drawing.Image)(resources.GetObject("pyramid.Image")));
            this.pyramid.Location = new System.Drawing.Point(65, 12);
            this.pyramid.Name = "pyramid";
            this.pyramid.Size = new System.Drawing.Size(47, 39);
            this.pyramid.TabIndex = 2;
            this.pyramid.UseVisualStyleBackColor = true;
            this.pyramid.Click += new System.EventHandler(this.pyramid_Click);
            // 
            // bt_LangTru
            // 
            this.bt_LangTru.Image = ((System.Drawing.Image)(resources.GetObject("bt_LangTru.Image")));
            this.bt_LangTru.Location = new System.Drawing.Point(118, 12);
            this.bt_LangTru.Name = "bt_LangTru";
            this.bt_LangTru.Size = new System.Drawing.Size(46, 39);
            this.bt_LangTru.TabIndex = 3;
            this.bt_LangTru.UseVisualStyleBackColor = true;
            this.bt_LangTru.Click += new System.EventHandler(this.bt_LangTru_Click);
            // 
            // bt_texture
            // 
            this.bt_texture.Location = new System.Drawing.Point(9, 117);
            this.bt_texture.Name = "bt_texture";
            this.bt_texture.Size = new System.Drawing.Size(79, 23);
            this.bt_texture.TabIndex = 4;
            this.bt_texture.Text = "Cube Texture";
            this.bt_texture.UseVisualStyleBackColor = true;
            this.bt_texture.Click += new System.EventHandler(this.bt_texture_Click);
            // 
            // bt_pyrtexture
            // 
            this.bt_pyrtexture.Location = new System.Drawing.Point(93, 117);
            this.bt_pyrtexture.Name = "bt_pyrtexture";
            this.bt_pyrtexture.Size = new System.Drawing.Size(91, 23);
            this.bt_pyrtexture.TabIndex = 5;
            this.bt_pyrtexture.Text = "Pyramid Texture";
            this.bt_pyrtexture.UseVisualStyleBackColor = true;
            this.bt_pyrtexture.Click += new System.EventHandler(this.bt_pyrtexture_Click);
            // 
            // bt_DrawSpace
            // 
            this.bt_DrawSpace.Location = new System.Drawing.Point(266, 117);
            this.bt_DrawSpace.Name = "bt_DrawSpace";
            this.bt_DrawSpace.Size = new System.Drawing.Size(75, 23);
            this.bt_DrawSpace.TabIndex = 6;
            this.bt_DrawSpace.Text = "DrawSpace";
            this.bt_DrawSpace.UseVisualStyleBackColor = true;
            this.bt_DrawSpace.Click += new System.EventHandler(this.bt_DrawSpace_Click);
            // 
            // lb_ListOfImage
            // 
            this.lb_ListOfImage.AutoSize = true;
            this.lb_ListOfImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ListOfImage.Location = new System.Drawing.Point(11, 147);
            this.lb_ListOfImage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_ListOfImage.Name = "lb_ListOfImage";
            this.lb_ListOfImage.Size = new System.Drawing.Size(106, 17);
            this.lb_ListOfImage.TabIndex = 14;
            this.lb_ListOfImage.Text = "List of image:";
            // 
            // lb_NameObject
            // 
            this.lb_NameObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NameObject.FormattingEnabled = true;
            this.lb_NameObject.ItemHeight = 20;
            this.lb_NameObject.Location = new System.Drawing.Point(8, 165);
            this.lb_NameObject.Margin = new System.Windows.Forms.Padding(2);
            this.lb_NameObject.Name = "lb_NameObject";
            this.lb_NameObject.Size = new System.Drawing.Size(333, 144);
            this.lb_NameObject.TabIndex = 13;
            // 
            // btMauVien
            // 
            this.btMauVien.Location = new System.Drawing.Point(188, 117);
            this.btMauVien.Name = "btMauVien";
            this.btMauVien.Size = new System.Drawing.Size(74, 23);
            this.btMauVien.TabIndex = 15;
            this.btMauVien.Text = "Color";
            this.btMauVien.UseVisualStyleBackColor = true;
            this.btMauVien.Click += new System.EventHandler(this.btMauVien_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Texture 3D and color:";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(9, 326);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(331, 53);
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 683);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btMauVien);
            this.Controls.Add(this.lb_ListOfImage);
            this.Controls.Add(this.lb_NameObject);
            this.Controls.Add(this.bt_DrawSpace);
            this.Controls.Add(this.bt_pyrtexture);
            this.Controls.Add(this.bt_texture);
            this.Controls.Add(this.bt_LangTru);
            this.Controls.Add(this.pyramid);
            this.Controls.Add(this.openGLControl1);
            this.Controls.Add(this.bt_cube);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_cube;
        private SharpGL.OpenGLControl openGLControl1;
        private System.Windows.Forms.Button pyramid;
        private System.Windows.Forms.Button bt_LangTru;
        private System.Windows.Forms.Button bt_texture;
        private System.Windows.Forms.Button bt_pyrtexture;
        private System.Windows.Forms.Button bt_DrawSpace;
        private System.Windows.Forms.Label lb_ListOfImage;
        private System.Windows.Forms.ListBox lb_NameObject;
        private System.Windows.Forms.Button btMauVien;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
    }
}

