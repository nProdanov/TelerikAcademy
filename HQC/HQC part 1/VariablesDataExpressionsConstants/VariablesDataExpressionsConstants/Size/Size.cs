namespace VariablesDataExpressionsConstants.Size
{
    using System;

    public class Size
    {
        private double width;
        private double heigth;

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.ValidateIsDoubleValuePositive(value, "Width");
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.heigth;
            }
            set
            {
                this.ValidateIsDoubleValuePositive(value, "Height");
                this.heigth = value;
            }
        }

        public static Size GetRotatedSize(Size oldSize, double angleOfRotatingFigure)
        {
            double rotatedWidth = Size.GetRotatedWidth(oldSize, angleOfRotatingFigure);
            double rotatedHeight = Size.GetRotatedHeight(oldSize, angleOfRotatingFigure);

            return new Size(rotatedWidth, rotatedHeight);
        }

        private static double GetRotatedHeight(Size oldSize, double angleOfRotatingFigure)
        {
            double oldWidthSin = Math.Abs(Math.Sin(angleOfRotatingFigure)) * oldSize.Width;
            double oldHeigthCos = Math.Abs(Math.Cos(angleOfRotatingFigure)) * oldSize.Height;
            double rotatedHeight = oldWidthSin + oldHeigthCos;

            return rotatedHeight;
        }

        private static double GetRotatedWidth(Size oldSize, double angleOfRotatingFigure)
        {
            double oldWidthCos = Math.Abs(Math.Cos(angleOfRotatingFigure)) * oldSize.Width;
            double oldHeigthSin = Math.Abs(Math.Sin(angleOfRotatingFigure)) * oldSize.Height;
            double rotatedWidth = oldWidthCos + oldHeigthSin;

            return rotatedWidth;
        }

        private void ValidateIsDoubleValuePositive(double value, string parramName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parramName, "can not to be 0 ot less than 0!");
            }
        }
    }
}
