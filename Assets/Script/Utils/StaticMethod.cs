﻿using UnityEngine;
using static utils.StaticMethod;

namespace utils {
    public enum VectorAxis {
        X,
        Y,
        Z
    }
    public static partial class StaticMethod {
        
        public static Vector3 Restricted(this Vector3 movement, bool x = false, bool y = false, bool z = false) {
            return new Vector3(x ? 0 : movement.x, y ? 0 : movement.y, z ? 0 : movement.z);
        }
        public static Vector3 UpdateAxis(this Vector3 movement,float newValue ,VectorAxis axis) {
            return new Vector3(axis == VectorAxis.X ? newValue : movement.x, axis == VectorAxis.Y ? newValue : movement.y, axis == VectorAxis.Z ? newValue : movement.z);
        }
    }
}