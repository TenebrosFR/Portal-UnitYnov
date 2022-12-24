using System;
using System.Collections;
using UnityEngine;

namespace utils {
    public enum VectorAxis {
        X,
        Y,
        Z
    }
    public static partial class StaticMethod {
        public static MonoBehave MonoBehave;
        #region Vector
        public static Vector3 Restricted(this Vector3 movement, bool x = false, bool y = false, bool z = false) {
            return new Vector3(x ? 0 : movement.x, y ? 0 : movement.y, z ? 0 : movement.z);
        }
        public static Vector3 UpdateAxis(this Vector3 movement, float newValue, VectorAxis axis) {
            return new Vector3(axis == VectorAxis.X ? newValue : movement.x, axis == VectorAxis.Y ? newValue : movement.y, axis == VectorAxis.Z ? newValue : movement.z);
        }
        #endregion
        #region Collider
        public static bool IsGrounded(this Collider obj) {
            return Physics.CheckSphere(obj.bounds.min, .2f, LayerMask.GetMask("Ground"));
        }
        #endregion
        #region Coroutine
        public static Coroutine ReloadCoroutine(this Coroutine current, IEnumerator ToLoad) {
            return MonoBehave.ReloadCoroutine(current, ToLoad);
        }
        #endregion
    }
}