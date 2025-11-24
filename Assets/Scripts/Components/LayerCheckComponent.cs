using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Collider2D))]
    public class LayerCheckComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask layer;
        [SerializeField] public bool isTouchingLayer;
        [SerializeField] public Collider2D targetCollider;

        public bool IsTouchingLayer => isTouchingLayer;

        private void OnTriggerStay2D(Collider2D collision)
        {
            isTouchingLayer = targetCollider.IsTouchingLayers(layer);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            isTouchingLayer = targetCollider.IsTouchingLayers(layer);
        }
    }
}