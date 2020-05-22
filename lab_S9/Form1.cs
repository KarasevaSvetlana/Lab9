using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_S9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            speedButton = trackBar2.Value;
            countButton = trackBar1.Value;
            label4.Text = trackBar2.Value.ToString();
            label3.Text = trackBar1.Value.ToString();
        }
        int speedButton = 1;
        int countButton = 1;
        int i = 1;
        List<Thread> threads = new List<Thread>();
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < countButton; i++)
            {

                Thread thread = new Thread(() =>
                {

                    Invoke((MethodInvoker)(() =>
                    {

                        Button myButton = new Button();
                        myButton.Name = "button_" + i;
                        myButton.Location = new Point(0 + i * 30, 0 + i * 30);
                        myButton.Size = new Size(152, 32);
                        myButton.TabIndex = 1;
                        i = i + 1;
                        myButton.Text = "поймай меня";
                        myButton.Click += new EventHandler(button_Click_win);
                        myButton.MouseMove += new MouseEventHandler(button1_MouseMove);
                        panel1.Controls.Add(myButton);
                        panel1.Update();
                        Thread.Sleep(500);

                    }));

                });
                thread.Start();
                threads.Add(thread);

            }
        }
        private void button_Click_win(object sender, EventArgs e)
        {
            MessageBox.Show("YOU ARE WINNER!!!");
        }
            private void button2_Click(object sender, EventArgs e)
        {
            int count = Controls.Count;
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Abort();

            }
            threads.Clear();
            panel1.Controls.Clear();

            i = 1;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            
            Button b = (Button)sender;
            Point cur = this.PointToClient(Cursor.Position);
            Point loc = b.Location;
            int x_new = loc.X;
            int y_new = loc.Y;

            //Движение вправо
            if (cur.X < loc.X + b.Width)
                x_new += speedButton * 20;

            //Движение влево
            if (cur.X > loc.X + b.Width)
                x_new -= speedButton * 20;

            //Движение вверх
            if (cur.Y > loc.Y + b.Height)
                y_new -= speedButton * 20;

            //Движение вниз
            if (cur.Y < loc.Y + b.Height)
                y_new += speedButton * 20;

            //Отступ слева
            if (x_new < 5)
                x_new = 5;

            //Отступ справа
            if (x_new > panel1.Width - b.Width - 25)
                x_new = panel1.Width - b.Width - 25;

            //Отступ сверху
            if (y_new < 10)
                y_new = 10;

            //Отступ снизу
            if (y_new > panel1.Height - b.Height - 45)
                y_new = panel1.Height - b.Height - 45;
            //курсор внизу формы
            if (y_new > panel1.Height - b.Height - 50)
                y_new = panel1.Height - b.Height - 80;

            //курсор вверху формы
            if (y_new < 11)
                y_new += 50;

            //курсор справа формы
            if (x_new > panel1.Width - b.Width - 26)
                x_new += -100;

            //курсор слева формы
            if (x_new < 6)
                x_new += 100;



            b.Location = new Point(x_new, y_new);
            panel1.Update();
            //Thread.Sleep(500);

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            speedButton = trackBar2.Value;
            countButton = trackBar1.Value;
            label4.Text = trackBar2.Value.ToString();
            label3.Text = trackBar1.Value.ToString();
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {

            speedButton = trackBar2.Value;
            countButton = trackBar1.Value;
            label4.Text = trackBar2.Value.ToString();
            label3.Text = trackBar1.Value.ToString();
        }
    }
}
