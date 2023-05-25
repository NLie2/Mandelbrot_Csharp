using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        //Class variables for user-dependent values
        double zoom = 0.01;
        double MiddenX = 0;
        double MiddenY = 0;

        int max = 100;

        //For color scheme
        int r = 255;
        int g = 255;
        int bl = 255;


        public Form1()
        {
            InitializeComponent();

            //Content of the textboxes should be equals to the current values of the variables
            this.textBox1.Text = MiddenX.ToString();
            this.textBox2.Text = MiddenY.ToString();
            this.textBox3.Text = zoom.ToString();
            this.textBox4.Text = max.ToString();

        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Create bitmap on top of the pictureBox
            Bitmap bm = new Bitmap(pictureBox1.Width,pictureBox1.Height);

            //Iterate throuch each point in the pictureBox
            for(int x=0; x< pictureBox1.Width; x++ )
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    //Match the display to make middle point 0,0 & less sensitive to variable changes
                    double a = (double)(x - (pictureBox1.Width / 2)) / (double)(pictureBox1.Width) * (zoom * 400) ;
                    double b = (double) (y - (pictureBox1.Height / 2)) / (double)(pictureBox1.Height) * (zoom * 400);

                    //Calculate Mandelnumbers of each point using the classs "Mandelnumber" which we created earlier
                    Mandelnumber c = new Mandelnumber(MiddenX + a, b - MiddenY);//add middle X and middle Y to AB. 
                    Mandelnumber z = new Mandelnumber(0, 0);
                    int it = 0;

                    while (it <= max && z.Distance() <= 2.0)
                    {
                        it++;
                        z.Square();
                        z.Add(c);
                    }

                    // DrawPixel: Change color of the pixel based on Mandelnumber
                    // If the number of iterations is smaller than Maximum (=point is not in the Mandelbrotset), color the point in a specific shade 
                    // If the number of iterations is greater than Maxmimum (=point is in the Mandelbrotset), make the point black. 
                    bm.SetPixel(x, y, it < max ? Color.FromArgb((it * r) / max, (it * g) / max, (it * bl) / max) : Color.Black);
                }


                //what the picturebox shows, needs to be equal to the bitmap
                pictureBox1.Image = bm; 
            }
        }


        //Implement values from user input:
        //Make sure to tybe in a comma, when typing in the values, not a dot! 
        public void button1_Click(object sender, EventArgs e)
        {
           //Change X and Y Values of the Middle to user Input
           MiddenX = double.Parse(textBox1.Text);
           MiddenY = double.Parse(textBox2.Text);

           //Change zoom value to User Input
           zoom = double.Parse(textBox3.Text);
           max = int.Parse(textBox4.Text);

           pictureBox1.Invalidate();
        }

        //When the user clicks on the pictureBox, transform the values in the pictureBox to the position of the Mouse 
        //With each click, zoom in. 
        private void pictureBox1_MouseClick(object sender, MouseEventArgs mea)
        {

            //match world and picture coordinates 
            textBox1.Text = ((double)MiddenX +(mea.X - (pictureBox1.Width / 2)) / (double)(pictureBox1.Width) * (zoom * 400)).ToString();
            textBox2.Text = ((double)MiddenY-(mea.Y - (pictureBox1.Height / 2)) / (double)(pictureBox1.Height) * (zoom * 400 )).ToString();
            textBox3.Text = (zoom * 0.5 ).ToString();

            button1_Click(sender, mea);

            pictureBox1.Invalidate();
        }
       
        //Different Color Schemes

        //Grayscale Color Scheme 
        private void label5_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 255;
            bl = 255;

        }

        //Blue Color Scheme 
        private void label6_Click(object sender, EventArgs e)
        {
            r = 0;
            g = 255;
            bl = 255;

        }

        // Color Scheme 
        private void label7_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 0;
            bl = 255;

        }

        //When labels are clicked, set to certain position

        //Lightning theme
        private void label5_Click_1(object sender, EventArgs e)
        {
            double position1X = -1.0079296875;
            double position1Y = 0.3112109375;
            double position1zoom = 1.953125E-5;
            int position1max = 100;


            this.textBox1.Text = (position1X).ToString();
            MiddenX = position1X;

            this.textBox2.Text = (position1Y).ToString();
            MiddenY = position1Y;

            this.textBox3.Text = (position1zoom).ToString();
            zoom = position1zoom;

            this.textBox4.Text = (position1max).ToString();
            max = position1max;

            pictureBox1.Invalidate();


        }

        //Cell Membrane theme
        private void label6_Click_1(object sender, EventArgs e)
        {
            double position2X = -0.1578125;
            double position2Y = 1.0328113;
            double position2zoom = 1.5625E-4;
            int position2max = 200;

            this.textBox1.Text = (position2X).ToString();
            MiddenX = position2X;

            this.textBox2.Text = (position2Y).ToString();
            MiddenY = position2Y;

            this.textBox3.Text = (position2zoom).ToString();
            zoom = position2zoom;

            this.textBox4.Text = (position2max).ToString();
            max = position2max;

            pictureBox1.Invalidate();

        }

        //Hawaiian theme 
        private void label7_Click_1(object sender, EventArgs e)
        {
            double position3X = -0.108625;
            double position3Y = 0.9014428;
            double position3zoom = 0.8147E-8;
            int position3max = 400;


            this.textBox1.Text = (position3X).ToString();
            MiddenX = position3X;

            this.textBox2.Text = (position3Y).ToString();
            MiddenY = position3Y;

            this.textBox3.Text = (position3zoom).ToString();
            zoom = position3zoom;

            this.textBox4.Text = (position3max).ToString();
            max = position3max;

            pictureBox1.Invalidate();
        }
    }
}
