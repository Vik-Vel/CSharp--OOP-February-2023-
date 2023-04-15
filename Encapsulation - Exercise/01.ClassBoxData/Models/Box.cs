using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData.Models;

    public class Box
    {
    //private const string PropertyValueExceptionMessage = "{0} cannot be zero or negative.";
    //private double length;

    //private double width;

    //private double height;
    //public Box(double lenght, double width, double height)
    //{
    //    Length = lenght;
    //    Width = width;
    //    Height = height;
    //}
    //public double Length
    //{
    //    get { return length; }
    //    set
    //    {
    //        if (value <= 0)
    //        {
    //            throw new ArgumentException(String.Format(PropertyValueExceptionMessage, nameof(Length)));
    //        }

    //        length = value;
    //    }
    //}

    //public double Width
    //{
    //    get { return width; }
    //    set
    //    {
    //        if (value <= 0)
    //        {
    //            throw new ArgumentException(String.Format(PropertyValueExceptionMessage, nameof(Width)));
    //        }


    //        width = value;
    //    }
    //}

    //public double Height
    //{
    //    get { return height; }
    //    set
    //    {
    //        if (value <= 0)
    //        {
    //            throw new ArgumentException(String.Format(PropertyValueExceptionMessage, nameof(Height)));
    //        }


    //        height = value;
    //    }
    //}

    private double length;

    private double width;

    private double height;

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }
    public double Length
    {
        get { return length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(PrintExeption("Length"));
            }

            length = value;
        }
    }

    public double Width
    {
        get { return width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(PrintExeption("Width"));
            }


            width = value;
        }
    }

    public double Height
    {
        get { return height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(PrintExeption("Height"));
            }


            height = value;
        }
    }


    public string PrintExeption(string input)
        {
            return$"{input} cannot be zero or negative.";
        }

        public double SurfaceArea()
        {
            //surface area (SA)=2lw+2lh+2hw
            double surfaceArea = (2 * Length * Width) + (2 * Length * Height) + (2 * Height * Width);
            return surfaceArea;

        }

        public double LateralSurfaceArea()
        {
            //lateral surface area  2h(l + w)
            double lateralSurfaceArea = 2 * Height * (Length + Width);
            return lateralSurfaceArea;

        }

        public double Volume()
        {
            //volume -> multiplying length x width x height
            double volume = Height * Length * Width;
            return volume;

        }
    }
    /* 
     public Box(double lenght, double width, double height)
        {
            Lenght = lenght;
            Width = width;
            Height = height;
        }
        public double Lenght
        {
            get { return lenght; }
             set
            {
                if (lenght <= 0) 
                {
                    throw new ArgumentException(String.Format(PropertyValueExceptionMessage,nameof(Lenght)));
                }
                
                lenght = value; 
            }
        }

        public double Width
        {
            get { return width; }
             set
            {
                if (width <= 0)
                {
                    throw new ArgumentException(String.Format(PropertyValueExceptionMessage, nameof(Width)));
                }


                width = value;
            }
        }

        public double Height
        {
            get { return height; }
             set
            {
                if (width <= 0)
                {
                    throw new ArgumentException(String.Format(PropertyValueExceptionMessage, nameof(Height)));
                }


                height = value;
            }
        }
    */


