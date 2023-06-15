using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class WheelView : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private WheelCollider wheelCollider;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private new Collider collider;

        private bool demolished;

        public void Demolish(Vector3 velocity)
        {
            if (demolished)
                return;
            demolished = true;


            transform.parent = null;

            collider.enabled = true;

            rigidbody.isKinematic = false;
            rigidbody.velocity = Vector3.Lerp(velocity.normalized, Random.onUnitSphere, 0.75f) * velocity.magnitude;
            rigidbody.angularVelocity = Random.onUnitSphere * 360;

            Hide();
        }

        private async void Hide()
        {
            await UniTask.Delay(10f);

            float animationTime = 1f;
            Vector3 scale = transform.localScale;
            for (float time = 0; time < animationTime; time += Time.fixedDeltaTime)
            {
                transform.localScale = Vector3.Lerp(scale, Vector3.zero, time / animationTime);

                await UniTask.WaitForFixedUpdate();
            }

            Destroy(gameObject);
        }


        private void FixedUpdate()
        {
            if (demolished)
                return;

            Vector3 position;
            Quaternion rotation;

            wheelCollider.GetWorldPose(out position, out rotation);

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
