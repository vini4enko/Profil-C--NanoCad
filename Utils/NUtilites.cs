using System;
using Teigha.DatabaseServices;
using Teigha.Geometry;

namespace NUtils
{
    public class NGUtils
    {
        public static double Curvature(double distance, double radius)
        {
            //return (Math.Asin(distance / (2.0 * radius))) / 2.0;
            return 2 * (radius - Math.Sqrt(radius * radius - distance * distance / 4)) / distance;
        }

        public static double Distance(Point2d pt0, Point2d pt1)
        {
            double X = pt0.X - pt1.X;
            double Y = pt0.Y - pt1.Y;
            return Math.Sqrt((X * X) + (Y * Y));
        }

        public static void TransPoly(ref Polyline aPol, int curRot, ref Point3d ptStart, Matrix3d curUCSMatrix)
        {
            CoordinateSystem3d curUCS = curUCSMatrix.CoordinateSystem3d;
            aPol.TransformBy(curUCSMatrix);

            Point3d acPt3d = new Point3d(0, 0, 0).TransformBy(curUCSMatrix);
            Point3d acPt3d_x = new Point3d(100, 0, 0).TransformBy(curUCSMatrix);
            Point3d acPt3d_y = new Point3d(0, 100, 0).TransformBy(curUCSMatrix);
            Line3d x = new Line3d(acPt3d, acPt3d_x);
            Line3d y = new Line3d(acPt3d, acPt3d_y);

            switch (curRot)
            {
                case 1:
                    break;
                case 11:
                    aPol.TransformBy(Matrix3d.Mirroring(y));
                    //aPol.TransformBy(Matrix3d.Rotation(Math.PI, curUCS.Yaxis, acPt3d));
                    break;
                case 10:
                    aPol.TransformBy(Matrix3d.Rotation(Math.PI / 2, curUCS.Zaxis, acPt3d));
                    break;
                case 8:
                    aPol.TransformBy(Matrix3d.Rotation(Math.PI / 2, curUCS.Zaxis, acPt3d));
                    aPol.TransformBy(Matrix3d.Mirroring(x));
                    //aPol.TransformBy(Matrix3d.Rotation(Math.PI, curUCS.Xaxis, acPt3d));
                    break;
                case 7:
                    aPol.TransformBy(Matrix3d.Mirroring(y));
                    aPol.TransformBy(Matrix3d.Mirroring(x));
                    //aPol.TransformBy(Matrix3d.Rotation(Math.PI, curUCS.Yaxis, acPt3d));
                    //aPol.TransformBy(Matrix3d.Rotation(Math.PI, curUCS.Xaxis, acPt3d));
                    break;
                case 5:
                    aPol.TransformBy(Matrix3d.Mirroring(x));
                    //aPol.TransformBy(Matrix3d.Rotation(Math.PI, curUCS.Xaxis, acPt3d));
                    break;
                case 4:
                    aPol.TransformBy(Matrix3d.Rotation(-Math.PI / 2, curUCS.Zaxis, acPt3d));
                    break;
                case 2:
                    aPol.TransformBy(Matrix3d.Rotation(-Math.PI / 2, curUCS.Zaxis, acPt3d));
                    aPol.TransformBy(Matrix3d.Mirroring(x));
                    //aPol.TransformBy(Matrix3d.Rotation(Math.PI, curUCS.Xaxis, acPt3d));
                    break;
                default:
                    break;
            }
            Vector3d acVec3d = acPt3d.GetVectorTo(ptStart);
            aPol.TransformBy(Matrix3d.Displacement(acVec3d));
        }
        //public static void Trans(ref  Prim, ref Point3d ptStart, Matrix3d curUCSMatrix)
        //{
        //    CoordinateSystem3d curUCS = curUCSMatrix.CoordinateSystem3d;
        //    Point3d acPt3d = new Point3d(0, 0, 0).TransformBy(curUCSMatrix);
        //    Vector3d acVec3d = acPt3d.GetVectorTo(ptStart);
        //    Prim.TransformBy(Matrix3d.Displacement(acVec3d));
        //}
    }
}
