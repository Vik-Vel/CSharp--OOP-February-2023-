using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Width = width;
            Height = height;
        }
        public double Width { get; set; }
        public double Height { get; set; }

        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Width + 2 * Height;
        }

        public override string Draw()
        {
            return $"Drawing {typeof(Rectangle).Name}";
        }
    }
}
