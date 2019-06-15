using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MySnake
{
    class Food
    {
        private int x, y, width, height;
        private SolidBrush brush;
        public Rectangle foodRec;

        public Food(Random randFood)
        {
            x = randFood.Next(0, 29) * 10;
            y = randFood.Next(0, 29) * 10;
            width = 10; height = 10;

            brush = new SolidBrush(Color.Black);
            foodRec = new Rectangle(x, y, width, height);
        }
        public void foodLocation(Random randFood)
        {
            x = randFood.Next(0, 29) * 10;
            y = randFood.Next(0, 29) * 10;
        }
        public void DrawFood(Graphics paper)
        {
            foodRec.X = x;
            foodRec.Y = y;

            paper.FillEllipse(brush, foodRec);
        }
    }
}
