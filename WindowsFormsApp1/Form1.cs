using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public struct Point3d
        {
            public int x;
            public int y;
            public int z;
        }
        int shShape = 0;

        public Form1()
        {
            pointControl.x = pointControl.y = pointControl.z = 0;
            InitializeComponent();
            shShape = 1;
            object3D = new Shape[100];
        }

        public class Camera
        {
            public double eyex;
            public double eyey;
            public double eyez;

            public double upx;
            public double upy;
            public double upz;

            double degree;

            public double centerx;
            public double centery;
            public double centerz;

            public Camera()
            {
                eyex = 10;
                eyey = 10;
                eyez = 10;

            }

            public void NhinGan(double khoangCach)
            {
                eyex /= khoangCach;
                eyey /= khoangCach;
                eyez /= khoangCach;

                /* centerx -= khoangCach;
                 centery -= khoangCach;
                 centerz -= khoangCach;*/
            }
            public void NhinXa(double khoangCach)
            {
                eyex *= khoangCach;
                eyey *= khoangCach;
                eyez *= khoangCach;

                /*centerx += khoangCach;
                centery += khoangCach;
                centerz += khoangCach;*/
            }
            public void Ngang(double degree)// xoay quanh z
            {



                degree = degree * Math.PI / 180;
                double x = eyex;
                double y = eyey;

                eyex = x * Math.Cos(degree) - y * Math.Sin(degree);
                eyey = x * Math.Sin(degree) + y * Math.Cos(degree);



            }

            public void Doc(double degree)// xoay quanh x
            {
                //double t = (eyex * Math.Abs(eyex) + eyez * Math.Abs(eyez)) / Math.Sqrt(eyex * eyex + eyey * eyey + eyez * eyez) / Math.Sqrt(eyex * eyex + eyez * eyez);

                double x = 0, z = 0, y = 0;
                if (eyex <= 1 && eyey <= 1)
                {
                    x = 0;
                }

                int flag = 1;
                //if(eyex <=0 )flag = -1;
                double t = (1 * eyex) / Math.Sqrt(eyex * eyex + eyey * eyey);
                double alpha = Math.Acos(t);



                //double sina = Math.Sqrt(1 - cosa * cosa);
                if ((eyex >= 0 && eyey >= 0 || eyex < 0 && eyey >= 0))
                {
                    if (flag == 1)
                        alpha = 2 * Math.PI - alpha;
                }

                x = eyex;
                y = eyey;


                eyex = x * Math.Cos(alpha) - y * Math.Sin(alpha);
                eyey = x * Math.Sin(alpha) + y * Math.Cos(alpha);




                //quay quanh y
                degree = degree * Math.PI / 180;
                z = eyez;
                x = eyex;

                eyex = x * Math.Cos(degree) + z * Math.Sin(degree);
                eyez = -x * Math.Sin(degree) + z * Math.Cos(degree);

                alpha = -alpha;

                x = eyex;
                y = eyey;


                eyex = x * Math.Cos(alpha) - y * Math.Sin(alpha);
                eyey = x * Math.Sin(alpha) + y * Math.Cos(alpha);



            }


        }

        public abstract class Shape
        {
            public Point3d Center;
            public int Radius;
            public Color color;
            public Color selectedColor;

            public Shape()
            {
                Center.x = Center.y = Center.z = 0;
                Radius = 3;
                color = Color.White;
                selectedColor = Color.Orange;
            }
            public void Set(Point3d pt, int Radius)
            {
                this.Center = pt;
                this.Radius = Radius;
            }
            public void SetColor(Color cl)
            {
                this.color = cl;
            }
            public virtual void drawObject(OpenGL gl) { }
            public virtual void viewControlPoint(OpenGL gl) { }
        }
        public class cube : Shape
        {
            public Point3d A, B, C, D, E, F, G, H;
            public cube() : base()
            {

            }
            public void initPoint()
            {
                A.x = Center.x + Radius;
                A.y = Center.y + Radius;
                A.z = Center.z + Radius;

                B.x = Center.x + Radius;
                B.y = Center.y - Radius;
                B.z = Center.z + Radius;

                C.x = Center.x - Radius;
                C.y = Center.y - Radius;
                C.z = Center.z + Radius;

                D.x = Center.x - Radius;
                D.y = Center.y + Radius;
                D.z = Center.z + Radius;

                E.x = Center.x + Radius;
                E.y = Center.y + Radius;
                E.z = Center.z - Radius;

                F.x = Center.x + Radius;
                F.y = Center.y - Radius;
                F.z = Center.z - Radius;

                G.x = Center.x - Radius;
                G.y = Center.y - Radius;
                G.z = Center.z - Radius;

                H.x = Center.x - Radius;
                H.y = Center.y + Radius;
                H.z = Center.z - Radius;

            }
            public override void drawObject(OpenGL gl)
            {
                initPoint();
                base.drawObject(gl);
                // đỉnh
                gl.Begin(OpenGL.GL_QUADS);//GL_QUADS là tứ giác
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 1.0);
                gl.Vertex(A.x, A.y, A.z);
                gl.Vertex(B.x, B.y, B.z);
                gl.Vertex(C.x, C.y, C.z);
                gl.Vertex(D.x, D.y, D.z);
                gl.End();

                //đáy

                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(color.R / 265.0, color.G / 265.0, color.B / 265.0, 1.0);
                gl.Vertex(E.x, E.y, E.z);
                gl.Vertex(F.x, F.y, F.z);
                gl.Vertex(G.x, G.y, G.z);
                gl.Vertex(H.x, H.y, H.z);
                gl.End();

                // mặt trước

                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(color.R / 275.0, color.G / 275.0, color.B / 275.0, 1.0);
                gl.Vertex(A.x, A.y, A.z);
                gl.Vertex(B.x, B.y, B.z);
                gl.Vertex(F.x, F.y, F.z);
                gl.Vertex(E.x, E.y, E.z);

                gl.End();

                //sau
                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(color.R / 285.0, color.G / 285.0, color.B / 285.0, 1.0);
                gl.Vertex(D.x, D.y, D.z);
                gl.Vertex(C.x, C.y, C.z);
                gl.Vertex(G.x, G.y, G.z);
                gl.Vertex(H.x, H.y, H.z);
                gl.End();

                //trái
                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(color.R / 295.0, color.G / 295.0, color.B / 295.0, 1.0);
                gl.Vertex(B.x, B.y, B.z);
                gl.Vertex(C.x, C.y, C.z);
                gl.Vertex(G.x, G.y, G.z);
                gl.Vertex(F.x, F.y, F.z);
                gl.End();

                //phải
                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(color.R / 305.0, color.G / 305.0, color.B / 305.0, 1.0);
                gl.Vertex(A.x, A.y, A.x);
                gl.Vertex(D.x, D.y, D.z);
                gl.Vertex(H.x, H.y, H.z);
                gl.Vertex(E.x, E.y, E.z);
                gl.End();
            }

            public override void viewControlPoint(OpenGL gl)
            {
                gl.Begin(OpenGL.GL_LINE_LOOP);

                gl.LineWidth(5);
                gl.Color(selectedColor.R / 255.0, selectedColor.G / 255.0, selectedColor.B / 255.0, 0);

                gl.Vertex(A.x, A.y, A.z);
                gl.Vertex(B.x, B.y, B.z);
                gl.Vertex(C.x, C.y, C.z);
                gl.Vertex(G.x, G.y, G.z);
                gl.Vertex(H.x, H.y, H.z);

                gl.End();
            }
        }

        public class Pyramid : Shape
        {
            public Point3d O, A, B, C, D;
            public Pyramid() : base()
            {
                color = Color.Green;
            }
            public void InitPoint()
            {
                A.x = Center.x + Radius; A.y = Center.y + Radius; A.z = Center.z - Radius;
                B.x = Center.x + Radius; B.y = Center.y - Radius; B.z = Center.z - Radius;
                C.x = Center.x - Radius; C.y = Center.y - Radius; C.z = Center.z - Radius;
                D.x = Center.x - Radius; D.y = Center.y + Radius; D.z = Center.z - Radius;

                O.x = Center.x; O.y = Center.y; O.z = Center.z + Radius;
            }
            public override void drawObject(OpenGL gl)
            {
                InitPoint();
                //đáy
                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 1.0);
                gl.Vertex(A.x, A.y, A.z);
                gl.Vertex(B.x, B.y, B.z);
                gl.Vertex(C.x, C.y, C.z);
                gl.Vertex(D.x, D.y, D.z);
                gl.End();

                //trước
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(color.R / 265.0, color.G / 265.0, color.B / 265.0, 1.0);
                gl.Vertex(A.x, A.y, A.z);
                gl.Vertex(B.x, B.y, B.z);
                gl.Vertex(O.x, O.y, O.z);
                gl.End();

                //sau
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(color.R / 275.0, color.G / 275.0, color.B / 275.0, 1.0);
                gl.Vertex(C.x, C.y, C.z);
                gl.Vertex(D.x, D.y, D.z);
                gl.Vertex(O.x, O.y, O.z);
                gl.End();

                //trái
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(color.R / 285.0, color.G / 285.0, color.B / 285.0, 1.0);
                gl.Vertex(B.x, B.y, B.z);
                gl.Vertex(C.x, C.y, C.z);
                gl.Vertex(O.x, O.y, O.z);
                gl.End();

                //phải
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(color.R / 295.0, color.G / 295.0, color.B / 295.0, 1.0);
                gl.Vertex(D.x, D.y, D.z);
                gl.Vertex(A.x, A.y, A.z);
                gl.Vertex(O.x, O.y, O.z);
                gl.End();
            }
        }

        public class LangTru : Shape
        {
            public LangTru() : base()
            {
                Center.x = Center.y = Center.z = 0;
                color = Color.Brown;
            }
            public override void drawObject(OpenGL gl)
            {
                //đỉnh
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 1.0);
                gl.Vertex(Center.x + Radius, Center.y, Center.z + Radius);
                gl.Vertex(Center.x - Radius, Center.y - Radius, Center.z + Radius);
                gl.Vertex(Center.x - Radius, Center.y + Radius, Center.z + Radius);
                gl.End();

                //đáy
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(color.R / 265.0, color.G / 265.0, color.B / 265.0, 1.0);
                gl.Vertex(Center.x + Radius, Center.y, Center.z - Radius);
                gl.Vertex(Center.x - Radius, Center.y - Radius, Center.z - Radius);
                gl.Vertex(Center.x - Radius, Center.y + Radius, Center.z - Radius);
                gl.End();

                //left
                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(color.R / 275.0, color.G / 275.0, color.B / 275.0, 1.0);
                gl.Vertex(Center.x + Radius, Center.y, Center.z - Radius);
                gl.Vertex(Center.x - Radius, Center.y - Radius, Center.z - Radius);
                gl.Vertex(Center.x - Radius, Center.y - Radius, Center.z + Radius);
                gl.Vertex(Center.x + Radius, Center.y, Center.z + Radius);
                gl.End();

                //back
                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(color.R / 285.0, color.G / 285.0, color.B / 285.0, 1.0);
                gl.Vertex(Center.x - Radius, Center.y - Radius, Center.z - Radius);
                gl.Vertex(Center.x - Radius, Center.y - Radius, Center.z + Radius);
                gl.Vertex(Center.x - Radius, Center.y + Radius, Center.z + Radius);
                gl.Vertex(Center.x - Radius, Center.y + Radius, Center.z - Radius);
                gl.End();

                //right
                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(color.R / 295.0, color.G / 295.0, color.B / 295.0, 1.0);
                gl.Vertex(Center.x + Radius, Center.y, Center.z - Radius);
                gl.Vertex(Center.x - Radius, Center.y + Radius, Center.z - Radius);
                gl.Vertex(Center.x - Radius, Center.y + Radius, Center.z + Radius);
                gl.Vertex(Center.x + Radius, Center.y, Center.z + Radius);
                gl.End();
            }
        }

        public class cubTexture : Shape
        {
            Texture textureObj;
            string filepath;

            public Point3d A, B, C, D, E, F, G, H;

            public cubTexture(OpenGL gl)
            {
                textureObj = new Texture();
                filepath = "Crate.bmp";
                textureObj.Create(gl, filepath);

            }
            public void initPoint()
            {
                A.x = Center.x + Radius;
                A.y = Center.y + Radius;
                A.z = Center.z + Radius;

                B.x = Center.x + Radius;
                B.y = Center.y - Radius;
                B.z = Center.z + Radius;

                C.x = Center.x - Radius;
                C.y = Center.y - Radius;
                C.z = Center.z + Radius;

                D.x = Center.x - Radius;
                D.y = Center.y + Radius;
                D.z = Center.z + Radius;

                E.x = Center.x + Radius;
                E.y = Center.y + Radius;
                E.z = Center.z - Radius;

                F.x = Center.x + Radius;
                F.y = Center.y - Radius;
                F.z = Center.z - Radius;

                G.x = Center.x - Radius;
                G.y = Center.y - Radius;
                G.z = Center.z - Radius;

                H.x = Center.x - Radius;
                H.y = Center.y + Radius;
                H.z = Center.z - Radius;
            }

            public override void drawObject(OpenGL gl)
            {
                initPoint();
                base.drawObject(gl);
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                textureObj.Bind(gl);


                // đỉnh
                gl.Begin(OpenGL.GL_QUADS);//GL_QUADS là tứ giác
                gl.Color(1.0, 1.0, 1.0, 0.0);
                gl.TexCoord(0, 0);
                gl.Vertex(A.x, A.y, A.z);
                gl.TexCoord(1, 0);
                gl.Vertex(B.x, B.y, B.z);
                gl.TexCoord(1, 1);
                gl.Vertex(C.x, C.y, C.z);
                gl.TexCoord(0, 1);
                gl.Vertex(D.x, D.y, D.z);
                gl.End();

                //đáy

                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(1.0, 1.0, 1.0, 0.0);
                gl.TexCoord(0, 0);
                gl.Vertex(E.x, E.y, E.z);
                gl.TexCoord(1, 0);
                gl.Vertex(F.x, F.y, F.z);
                gl.TexCoord(1, 1);
                gl.Vertex(G.x, G.y, G.z);
                gl.TexCoord(0, 1);
                gl.Vertex(H.x, H.y, H.z);
                gl.End();

                // mặt trước

                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(1.0, 1.0, 1.0, 0.0);
                gl.TexCoord(0, 0);
                gl.Vertex(A.x, A.y, A.z);
                gl.TexCoord(1, 0);
                gl.Vertex(B.x, B.y, B.z);
                gl.TexCoord(1, 1);
                gl.Vertex(F.x, F.y, F.z);
                gl.TexCoord(0, 1);
                gl.Vertex(E.x, E.y, E.z);

                gl.End();

                //sau
                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(1.0, 1.0, 1.0, 0.0);
                gl.TexCoord(0, 0);
                gl.Vertex(D.x, D.y, D.z);
                gl.TexCoord(1, 0);
                gl.Vertex(C.x, C.y, C.z);
                gl.TexCoord(1, 1);
                gl.Vertex(G.x, G.y, G.z);
                gl.TexCoord(0, 1);
                gl.Vertex(H.x, H.y, H.z);
                gl.End();

                //trái
                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(1.0, 1.0, 1.0, 0.0);
                gl.TexCoord(0, 0);
                gl.Vertex(B.x, B.y, B.z);
                gl.TexCoord(1, 0);
                gl.Vertex(C.x, C.y, C.z);
                gl.TexCoord(1, 1);
                gl.Vertex(G.x, G.y, G.z);
                gl.TexCoord(0, 1);
                gl.Vertex(F.x, F.y, F.z);
                gl.End();

                //phải
                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(1.0, 1.0, 1.0, 0.0);
                gl.TexCoord(0, 0);
                gl.Vertex(A.x, A.y, A.x);
                gl.TexCoord(1, 0);
                gl.Vertex(D.x, D.y, D.z);
                gl.TexCoord(1, 1);
                gl.Vertex(H.x, H.y, H.z);
                gl.TexCoord(0, 1);
                gl.Vertex(E.x, E.y, E.z);
                gl.End();
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            }
        }

        public class pyrTexture : Shape
        {
            Texture textureObj;
            string filepath;

            public Point3d O, A, B, C, D;
            public pyrTexture(OpenGL gl)
            {
                textureObj = new Texture();
                filepath = "Crate.bmp";

                textureObj.Create(gl, filepath);

            }
            public void InitPoint()
            {
                A.x = Center.x + Radius; A.y = Center.y + Radius; A.z = Center.z - Radius;
                B.x = Center.x + Radius; B.y = Center.y - Radius; B.z = Center.z - Radius;
                C.x = Center.x - Radius; C.y = Center.y - Radius; C.z = Center.z - Radius;
                D.x = Center.x - Radius; D.y = Center.y + Radius; D.z = Center.z - Radius;

                O.x = Center.x; O.y = Center.y; O.z = Center.z + Radius;
            }
            public override void drawObject(OpenGL gl)
            {
                InitPoint();
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                textureObj.Bind(gl);

                //đáy
                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(1.0, 1.0, 1.0, 0.0);
                gl.TexCoord(0, 0);
                gl.Vertex(A.x, A.y, A.z);
                gl.TexCoord(1, 0);
                gl.Vertex(B.x, B.y, B.z);
                gl.TexCoord(1, 1);
                gl.Vertex(C.x, C.y, C.z);
                gl.TexCoord(0, 1);
                gl.Vertex(D.x, D.y, D.z);
                gl.End();

                //trước
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(1.0, 1.0, 1.0, 0.0);
                gl.TexCoord(0, 0);
                gl.Vertex(A.x, A.y, A.z);
                gl.TexCoord(1, 0);
                gl.Vertex(B.x, B.y, B.z);
                gl.TexCoord(0.5, 1);
                gl.Vertex(O.x, O.y, O.z);
                gl.End();

                //sau
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(1.0, 1.0, 1.0, 0.0);
                gl.TexCoord(0, 0);
                gl.Vertex(C.x, C.y, C.z);
                gl.TexCoord(1, 0);
                gl.Vertex(D.x, D.y, D.z);
                gl.TexCoord(0.5, 1);
                gl.Vertex(O.x, O.y, O.z);
                gl.End();

                //trái
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(1.0, 1.0, 1.0, 0.0);
                gl.TexCoord(0, 0);
                gl.Vertex(B.x, B.y, B.z);
                gl.TexCoord(1, 0);
                gl.Vertex(C.x, C.y, C.z);
                gl.TexCoord(0.5, 1);
                gl.Vertex(O.x, O.y, O.z);
                gl.End();

                //phải
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(1.0, 1.0, 1.0, 0.0);
                gl.TexCoord(0, 0);
                gl.Vertex(D.x, D.y, D.z);
                gl.TexCoord(1, 0);
                gl.Vertex(A.x, A.y, A.z);
                gl.TexCoord(0.5, 1);
                gl.Vertex(O.x, O.y, O.z);
                gl.End();
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            }
        }

        private int numOfObject = 0;
        private int numOfCube = 0;
        private int numOfPyr = 0;
        private int numOfPrism = 0;
        private int numOfCubeTex = 0;
        private int numOfPyrTex = 0;

        Shape[] object3D = new Shape[100];
        private Point3d pointControl;
        private int bankinh = 2;
        Camera camera;
        bool vekhonggian;
        Color userColor = Color.White;
        int idViewPoint = -1;

        void showSpaceGrid(OpenGL gl, int Radius)
        {
            gl.LineWidth(1.0f);
            int size = Radius * 4;
            for (int i = 0; i < size; i++)
            {
                gl.Begin(OpenGL.GL_LINES);
                gl.Color(1.0, 1.0, 1.0, 1.0);
                gl.Vertex(size, i, 0);
                gl.Vertex(-size, i, 0);
                gl.End();

                gl.Begin(OpenGL.GL_LINES);
                gl.Color(1.0, 1.0, 1.0, 1.0);
                gl.Vertex(size, -i, 0);
                gl.Vertex(-size, -i, 0);
                gl.End();
            }

            for (int i = 1; i <= size; i++)
            {
                gl.Begin(OpenGL.GL_LINES);
                gl.Color(1.0, 1.0, 1.0, 1.0);
                gl.Vertex(i, size, 0);
                gl.Vertex(i, -size, 0);
                gl.End();

                gl.Begin(OpenGL.GL_LINES);
                gl.Color(1.0, 1.0, 1.0, 1.0);
                gl.Vertex(-i, size, 0);
                gl.Vertex(-i, -size, 0);
                gl.End();
            }

            gl.Begin(OpenGL.GL_LINES);
            gl.Color(1.0, 0.0, 0.0, 1.0);
            gl.Vertex(0, 0, size);
            gl.Vertex(0, 0, -size);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0.0, 1.0, 0.0, 1.0);
            gl.Vertex(0, size, 0);
            gl.Vertex(0, -size, 0);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0.0, 0.0, 1.0, 1.0);
            gl.Vertex(size, 0, 0);
            gl.Vertex(-size, 0, 0);
            gl.End();
        }

        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl1.OpenGL;

            gl.ClearColor(0, 0, 0, 0);
            camera = new Camera();
            vekhonggian = false;
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
            gl.Perspective(60, openGLControl1.Width / openGLControl1.Height, 1.0, 10000.0);
            //gl.LoadIdentity();
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LookAt(camera.eyex, camera.eyey, camera.eyez, 0, 0, 0, 0, 0, 1);
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openGLControl1.OpenGL;

            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();
            gl.LookAt(camera.eyex, camera.eyey, camera.eyez, camera.centerx, camera.centery, camera.centerz, 0, 0, 1);

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            switch (shShape)
            {
                case 1: object3D[numOfObject] = new cube(); break;
                case 2: object3D[numOfObject] = new Pyramid(); break;
                case 3: object3D[numOfObject] = new LangTru(); break;
                case 4: object3D[numOfObject] = new cubTexture(gl); break;
                case 5: object3D[numOfObject] = new pyrTexture(gl); break;
                default: break;
            }

            object3D[numOfObject].Set(pointControl, bankinh);
            object3D[numOfObject].SetColor(userColor);

            if (vekhonggian == true) showSpaceGrid(gl, bankinh);
            if (numOfObject > 0)
                for (int i = 1; i <= numOfObject; i++)
                {
                    object3D[i].drawObject(gl);
                }

            if (idViewPoint != -1) //Nếu đang vẽ một hình thì hiện control point của hình đó lên
                object3D[idViewPoint].viewControlPoint(gl);

            gl.Flush();
        }

        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z) camera.NhinGan(1.05);
            if (e.KeyCode == Keys.X) camera.NhinXa(1.05);
            if (e.KeyCode == Keys.A) camera.Ngang(5);
            if (e.KeyCode == Keys.D) camera.Ngang(-5);
            if (e.KeyCode == Keys.S) camera.Doc(5);
            if (e.KeyCode == Keys.W) camera.Doc(-5);
        }

        private void bt_cube_Click(object sender, EventArgs e)
        {
            numOfObject += 1;
            numOfCube += 1;
            shShape = 1;
            lb_NameObject.Items.Add("Cube " + numOfCube);
            listView1.Items.Add("Cube " + numOfCube);
        }

        private void pyramid_Click(object sender, EventArgs e)
        {
            numOfObject += 1;
            numOfPyr += 1;
            shShape = 2;
            lb_NameObject.Items.Add("Pyramid " + numOfPyr);
        }

        private void bt_LangTru_Click(object sender, EventArgs e)
        {
            numOfObject += 1;
            numOfPrism += 1;
            shShape = 3;
            lb_NameObject.Items.Add("Prism " + numOfPrism);
        }

        private void bt_texture_Click(object sender, EventArgs e)
        {
            numOfObject += 1;
            numOfCubeTex += 1;
            shShape = 4;
            lb_NameObject.Items.Add("Cube Texture " + numOfCubeTex);
        }

        private void bt_pyrtexture_Click(object sender, EventArgs e)
        {
            numOfObject += 1;
            numOfPyrTex += 1;
            shShape = 5;
            lb_NameObject.Items.Add("Pyramid Texture " + numOfPyrTex);
        }

        private void bt_DrawSpace_Click(object sender, EventArgs e)
        {
            if (vekhonggian == false) vekhonggian = true;
            else vekhonggian = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btMauVien_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                userColor = colorDialog1.Color;
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            ListViewItem firstSelectedItem = listView1.SelectedItems[0];
            firstSelectedItem.UseItemStyleForSubItems = false;
            firstSelectedItem.SubItems[1].Font = new Font(firstSelectedItem.SubItems[1].Font,
            firstSelectedItem.SubItems[1].Font.Style | FontStyle.Bold);
        }
    }
}
