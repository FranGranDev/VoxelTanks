using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class WheelView : MonoBehaviour
    {
        [SerializeField] private WheelCollider wheelCollider;

        private void FixedUpdate()
        {
            Vector3 position;
            Quaternion rotation;

            wheelCollider.GetWorldPose(out position, out rotation);

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
