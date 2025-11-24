using UnityEngine;

namespace Components
{
    public class AttractorChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask attractableMask;
        [SerializeField] private Attractable attractable;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.IsTouchingLayers(attractableMask))
            {
                return;
            }

            if (other.TryGetComponent(out Attractor attractor))
            {
                attractable.SetAttractor(attractor);
            }
        }
    }
}