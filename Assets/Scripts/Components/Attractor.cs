using UnityEngine;

namespace Components
{
    public class Attractor : MonoBehaviour
    {
        [SerializeField] private float gravity = 10;
        [SerializeField] private float rotationZ;
        [SerializeField] private Vector2 normal;

        public float Gravity => gravity;
        public float RotationZ => rotationZ;
        public Vector2 Normal => normal;
    }
}