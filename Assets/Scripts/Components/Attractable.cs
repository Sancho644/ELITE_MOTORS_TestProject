using System.Collections;
using UnityEngine;

namespace Components
{
    public class Attractable : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D targetRigidbody;
        [SerializeField] private float rotationTime = 0.15f;

        public Attractor Attractor { get; private set; }

        public void SetAttractor(Attractor attractor)
        {
            Attractor = attractor;
            SetRotation();
        }

        private void FixedUpdate()
        {
            Attract();
        }

        private void Attract()
        {
            if (Attractor == null)
            {
                return;
            }

            targetRigidbody.AddForce(Attractor.Normal * Attractor.Gravity);
        }

        private void SetRotation()
        {
            StartCoroutine(StartRotationAnimation());
        }

        private IEnumerator StartRotationAnimation()
        {
            var startZ = transform.eulerAngles.z;
            var time = 0f;

            while (time < rotationTime)
            {
                time += Time.deltaTime;
                var t = time / rotationTime;

                t = Mathf.SmoothStep(0f, 1f, t);

                var angle = Mathf.LerpAngle(startZ, Attractor.RotationZ, t);
                transform.rotation = Quaternion.Euler(0f, 0f, angle);

                yield return null;
            }

            transform.rotation = Quaternion.Euler(0f, 0f, Attractor.RotationZ);
        }
    }
}