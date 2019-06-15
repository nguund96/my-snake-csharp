using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MySnake
{
    class Snake
    {
        private Rectangle[] snakeRec;
        public Rectangle[] SnakeRec
        {
            get { return snakeRec; }
        }

        private SolidBrush brush;
        private int x, y, width, height;

        //Khởi tạo mặc định.
        public Snake()
        {
            snakeRec = new Rectangle[3];
            brush = new SolidBrush(Color.Red);

            x = 20; y = 0; width = 10; height = 10;

            for(int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }
        }
        //Vẽ rắn.
        public void DrawSnake(Graphics paper)
        {
            foreach(Rectangle rec in snakeRec)
            {
                paper.FillEllipse(brush, rec);
            }
        }
        //Vẽ rắn trong lúc di chuyển.
        public void DrawSnakeRun()
        {
            for(int i = snakeRec.Length - 1; i > 0; i--)
            {
                snakeRec[i] = snakeRec[i - 1];
            }
        }
        //Di chuyển lên.
        public void MoveDown()
        {
            DrawSnakeRun();
            snakeRec[0].Y += 10;
        }
        //Di chuyển xuống.
        public void MoveUp()
        {
            DrawSnakeRun();
            snakeRec[0].Y -= 10;
        }
        //Di chuyển sang trái.
        public void MoveLeft()
        {
            DrawSnakeRun();
            snakeRec[0].X -= 10;
        }
        //Di chuyển sang phải.
        public void MoveRight()
        {
            DrawSnakeRun();
            snakeRec[0].X += 10;
        }
        //Rắn lớn lên.
        public void GrowSnake()
        {
            List<Rectangle> rec = snakeRec.ToList();
            rec.Add(new Rectangle(snakeRec[snakeRec.Length - 1].X, snakeRec[snakeRec.Length - 1].Y, width, height));
            snakeRec = rec.ToArray();
        }
    }
}
