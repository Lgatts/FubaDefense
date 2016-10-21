using Microsoft.Xna.Framework;

namespace FubaDefense
{
    public class TrajectPoint
    {
        Point point;
        string direction;

        #region Constructor
        /// <summary>
        /// Create a point where an game entity change your direction
        /// </summary>
        /// <param name="point">Point of chance</param>
        /// <param name="direction">Direction of chance</param>
        public TrajectPoint(Point point, string direction)
        {
            this.point = point;
            this.direction = direction;
        }
        #endregion

        #region Properties
        public Point Point
        {
            get
            {
                return point;
            }
        }

        public string Direction
        {
            get
            {
                return direction;
            }
        }
    }
    #endregion
}