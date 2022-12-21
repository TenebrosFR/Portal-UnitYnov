using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace utils {
    public enum VectorAxis {
        X,
        Y,
        Z
    }
    public static partial class StaticMethod {
        #region Vector
        public static Vector3 Restricted(this Vector3 movement, bool x = false, bool y = false, bool z = false) {
            return new Vector3(x ? 0 : movement.x, y ? 0 : movement.y, z ? 0 : movement.z);
        }
        public static Vector3 UpdateAxis(this Vector3 movement, float newValue, VectorAxis axis) {
            return new Vector3(axis == VectorAxis.X ? newValue : movement.x, axis == VectorAxis.Y ? newValue : movement.y, axis == VectorAxis.Z ? newValue : movement.z);
        }
        public static Vector3 Add(this Vector3 movement, Vector3 direction) {
            return new Vector3(movement.x+direction.x,movement.y+direction.y,movement.z+direction.z);
        }   
        #endregion
        #region Collider
        public static bool IsGrounded(this Collider obj) {
            return Physics.CheckCapsule(obj.bounds.center, new Vector3(obj.bounds.center.x, obj.bounds.min.y - 0.1f, obj.bounds.center.z), 0.18f, LayerMask.GetMask("Ground"));
        }
        #endregion
    }
}