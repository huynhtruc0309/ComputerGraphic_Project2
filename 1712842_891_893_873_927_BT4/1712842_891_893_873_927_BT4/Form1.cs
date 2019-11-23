using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();            
        }

        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl1.OpenGL;

            gl.ClearColor(0, 0, 0, 0);            
        }

        private void openGLControl1_Resized(object sender, EventArgs e)
        {

			OpenGL gl = openGLControl1.OpenGL;
            
            //set ma tran viewport
			gl.Viewport(
				0, 0, 
				openGLControl1.Width, 
				openGLControl1.Height);
			
            //set ma tran phep chieu
            gl.MatrixMode(OpenGL.GL_PROJECTION);                        
            gl.Perspective(60, 
            openGLControl1.Width / openGLControl1.Height, 
                1.0, 20.0);

            //set ma tran model view
            gl.MatrixMode(OpenGL.GL_MODELVIEW);            
            gl.LookAt(
                5, 7, 6, 
                0, 0, 0, 
                0, 1, 0);
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openGLControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            // Draw a coloured cube
            drawColouredCube(gl);

            gl.Flush();
        }

       

        private void drawColouredCube(OpenGL gl)
        {
            float a = 2.0f;
            gl.Begin(OpenGL.GL_QUADS);

            gl.Color(0.0f, 1.0f, 0.0f);    // Color Blue
            gl.Vertex(0.0f, 0.0f, 0.0f);    // Top Right Of The Quad (Top)
            gl.Vertex(a, 0.0f, 0.0f);    // Top Left Of The Quad (Top)
            gl.Vertex(a, 0.0f, a);    // Bottom Left Of The Quad (Top)
            gl.Vertex(0.0f, 0.0f, a);    // Bottom Right Of The Quad (Top)

            gl.Color(1.0f, 0.5f, 0.0f);    // Color Orange
            gl.Vertex(0.0f, 0.0f, 0.0f);    // Top Right Of The Quad (Bottom)
            gl.Vertex(0.0f, a, 0.0f);    // Top Left Of The Quad (Bottom)
            gl.Vertex(a, a, 0.0f);    // Bottom Left Of The Quad (Bottom)
            gl.Vertex(a, 0.0f, 0.0f);    // Bottom Right Of The Quad (Bottom)

            gl.Color(1.0f, 0.0f, 0.0f);    // Color Red    
            gl.Vertex(0.0f, 0.0f, 0.0f);    // Top Right Of The Quad (Front)
            gl.Vertex(0.0f, a, 0.0f);    // Top Left Of The Quad (Front)
            gl.Vertex(0.0f, a, a);    // Bottom Left Of The Quad (Front)
            gl.Vertex(0.0f, 0.0f, a);    // Bottom Right Of The Quad (Front)

            gl.Color(1.0f, 1.0f, 0.0f);    // Color Yellow
            gl.Vertex(0.0f, a, a);    // Top Right Of The Quad (Back)
            gl.Vertex(a, a, a);    // Top Left Of The Quad (Back)
            gl.Vertex(a, 0.0f, a);    // Bottom Left Of The Quad (Back)
            gl.Vertex(0.0f, 0.0f, a);    // Bottom Right Of The Quad (Back)

            gl.Color(0.0f, 0.0f, 1.0f);    // Color Blue
            gl.Vertex(a, a, a);    // Top Right Of The Quad (Left)
            gl.Vertex(a, a, 0.0f);    // Top Left Of The Quad (Left)
            gl.Vertex(a, 0.0f, 0.0f);    // Bottom Left Of The Quad (Left)
            gl.Vertex(a, 0.0f, a);    // Bottom Right Of The Quad (Left)

            gl.Color(1.0f, 0.0f, 1.0f);    // Color Violet
            gl.Vertex(0.0f, a, 0.0f);    // Top Right Of The Quad (Right)
            gl.Vertex(a, a, 0.0f);    // Top Left Of The Quad (Right)
            gl.Vertex(a, a, a);    // Bottom Left Of The Quad (Right)
            gl.Vertex(0.0f, a, a);    // Bottom 

            gl.End();
        }


    }
}
