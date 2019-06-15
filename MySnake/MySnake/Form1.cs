using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySnake
{
    public partial class Form1 : Form
    {
        int score = 0; // Điểm
        Random randFood = new Random();
        Food food;
        Graphics paper;
        Snake snake = new Snake();
        Boolean left = false, right = false, up = false, down = false;

        public Form1()
        {
            InitializeComponent();
            food = new Food(randFood);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            //SolidBrush sb = new SolidBrush(Color.Red);
            //Graphics g = this.CreateGraphics();

            //g.FillEllipse(sb, new Rectangle(0, 0, 10, 10));
            //g.FillEllipse(sb, new Rectangle(10, 0, 10, 10));
            //g.FillEllipse(sb, new Rectangle(20, 0, 10, 10));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            snake.DrawSnake(paper);
            food.DrawFood(paper);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                timer1.Enabled = true;
                up = false;
                down = false;
                left = false;
                right = true;
                label1.Text = "";
                label2.Text = "";
            }
            if(e.KeyData == Keys.Up && down == false)
            {
                up = true;
                down = false;
                left = false;
                right = false;
            }
            if (e.KeyData == Keys.Down && up == false)
            {
                up = false;
                down = true;
                left = false;
                right = false;
            }
            if (e.KeyData == Keys.Left && right == false)
            {
                up = false;
                down = false;
                left = true;
                right = false;
            }
            if (e.KeyData == Keys.Right && left == false)
            {
                up = false;
                down = false;
                left = false;
                right = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelScore.Text = score.ToString();
            if (down == true) { snake.MoveDown(); }
            if (up == true) { snake.MoveUp(); }
            if (left == true) { snake.MoveLeft(); }
            if (right == true) { snake.MoveRight(); }

            //Kiểm tra va chạm giữa rắn và mồi.
            for (int i = 0; i < snake.SnakeRec.Length; i++)
            {
                if (snake.SnakeRec[i].IntersectsWith(food.foodRec))
                {
                    //Tăng điểm lên.
                    score += 10;
                    //Rắn lớn lên.
                    snake.GrowSnake();
                    //Tạo ta mồi khác.
                    food.foodLocation(randFood);
                }
            }
            collision(); //Va chạm vs thân mình hoặc với tường.
            this.Invalidate();
        }
        //Va chạm vs thân mình hoặc với tường.
        public void collision()
        {
            for(int i = 1; i < snake.SnakeRec.Length; i++)
            {
                if(snake.SnakeRec[0].IntersectsWith(snake.SnakeRec[i]))
                {
                    Restart();
                }
            }
            if(snake.SnakeRec[0].X < 0 || snake.SnakeRec[0].X > 290)
            {
                Restart();
            }
            if (snake.SnakeRec[0].Y < 0 || snake.SnakeRec[0].Y > 290)
            {
                Restart();
            }
        }
        void Restart()
        {
            timer1.Enabled = false;
            label1.Text = "Bấm phím cách để bắt đầu chơi";
            score = 0;
            toolStripStatusLabelScore.Text = score.ToString();
            label2.Text = "GAME OVER !!!";
            snake = new Snake();
        }
    }
}
