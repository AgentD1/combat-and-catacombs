using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_and_Catacombs {
    public class Vector2 {
        public int x;
        public int y;

        public Vector2(int x, int y) {
            this.x = x;
            this.y = y;
        }

        #region Overrides
        public override bool Equals(object obj) {
            return obj is Vector2 && (obj as Vector2) == this;
        }
        public override int GetHashCode() {
            return (x.ToString() + "/" + y.ToString()).GetHashCode();
        }
        #endregion

        #region Operators
        public static Vector2 operator+(Vector2 lhs, Vector2 rhs) {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs) {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2 operator +(Vector2 rhs) {
            return rhs;
        }

        public static Vector2 operator -(Vector2 rhs) {
            return new Vector2(-rhs.x, -rhs.y);
        }

        public static Vector2 operator *(Vector2 lhs, int rhs) {
            return new Vector2(lhs.x * rhs, lhs.y * rhs);
        }
        
        public static Vector2 operator /(Vector2 lhs, int rhs) {
            return new Vector2(lhs.x / rhs, lhs.y / rhs);
        }

        public static bool operator ==(Vector2 lhs, Vector2 rhs) {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs) {
            return lhs.x != rhs.x || lhs.y != rhs.y;
        }
        #endregion

        #region Static Vector2 Variables
        public static Vector2 up = new Vector2(0, 1);
        public static Vector2 down = new Vector2(0, -1);
        public static Vector2 left = new Vector2(-1, 0);
        public static Vector2 right = new Vector2(1, 0);
        public static Vector2 one = new Vector2(1, 1);
        public static Vector2 zero = new Vector2(0, 0);
        #endregion

        #region Static Functions
        public double EuclideanDistance(Vector2 a, Vector2 b) {
            return Math.Sqrt(Math.Pow(a.x + b.x, 2) + Math.Pow(a.y + b.y, 2));
        }

        // Taxicab
        public int Distance(Vector2 a, Vector2 b) {
            return Math.Abs((a.x - b.x) + (a.y - b.y));
        }
        #endregion
    }
}
