﻿using System;
using UnityEngine;

namespace HighPrecisionStepperJuggler
{
    public static class InverseKinematics
    {
        private static float _l1 = 0.004f;
        private static float _l2 = 0.005f;

        /// <summary>
        /// Get theta1 and theta2 with a given target height (tip of link2)
        /// </summary>
        /// <param name="targetY">The given target height (tip of link2)</param>
        /// <returns>theta1 (rotation of joint1) and theta2 (rotation of joint2)</returns>
        public static (float theta1, float theta2) CalculateJointRotationsFromTargetY(float targetY)
        {
            var theta1 = Mathf.Asin((targetY * targetY + _l1 * _l1 - _l2 * _l2) / (2f * _l1 * targetY));
            var theta2 = Mathf.PI - Math.Acos(Mathf.Cos(theta1) * _l1 / _l2);

            return (theta1: theta1, theta2: (float)theta2);
        }

        /// <summary>
        /// Get joint1 rotation with a given theta1 rotation
        /// </summary>
        /// <param name="theta1">The rotation of joint1</param>
        /// <returns>theta2 (rotation of joint2)</returns>
        public static float CalculateJoint2RotationFromJoint1Rotation(float theta1)
        {
            return (float)(Mathf.PI - Math.Acos(Mathf.Cos(theta1) * _l1 / _l2));
        }
    }
}
