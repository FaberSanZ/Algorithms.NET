using System.Numerics;

namespace Algorithms.Geometry
{
    public static class AngleBetweenVectors2D
    {
        // Return the smaller of the two angles between two 2D vectors in radians
        public static double AngleBetweenVectors(double v1x, double v1y, double v2x, double v2y)
        {

            // To determine the angle between two vectors v1 and v2 we can use
            // the following formula: dot(v1,v2) = len(v1)*len(v2)*cosθ and solve
            // for θ where dot(a,b) is the dot product and len(c) is the length of c.
            double dotproduct = (v1x * v2x) + (v1y * v2y);
            double v1Length = System.Math.Sqrt(v1x * v1x + v1y * v1y);
            double v2Length = System.Math.Sqrt(v2x * v2x + v2y * v2y);

            double value = dotproduct / (v1Length * v2Length);

            // Double value rounding precision may lead to the value we're about to pass into
            // the arccos function to be slightly outside its domain, so do a safety check.
            if (value <= -1.0)
            {
                return 3.1415926535897931;
            }

            if (value >= +1.0)
            {
                return 0;
            }

            return System.Math.Acos(value);
        }


        //public static double AngleBetweenVectors(Vector2 v, Vector2 v2)
        //{

        //    // To determine the angle between two vectors v1 and v2 we can use
        //    // the following formula: dot(v1,v2) = len(v1)*len(v2)*cosθ and solve
        //    // for θ where dot(a,b) is the dot product and len(c) is the length of c.
        //    double dotproduct = (v1x * v2x) + (v1y * v2y);
        //    double v1Length = System.Math.Sqrt(v1x * v1x + v1y * v1y);
        //    double v2Length = System.Math.Sqrt(v2x * v2x + v2y * v2y);

        //    double value = dotproduct / (v1Length * v2Length);

        //    // Double value rounding precision may lead to the value we're about to pass into
        //    // the arccos function to be slightly outside its domain, so do a safety check.
        //    if (value <= -1.0)
        //    {
        //        return 3.1415926535897931;
        //    }

        //    if (value >= +1.0)
        //    {
        //        return 0;
        //    }

        //    return System.Math.Acos(value);
        //}
    }
}
