using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Collider2D))]
    public class LayerCheckComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask layer;
        [SerializeField] private bool isTouchingLayer;
        [SerializeField] private Collider2D targetCollider;

        public bool IsTouchingLayer => isTouchingLayer;

        private void Awake()
        {
            if (targetCollider == null)
            {
                targetCollider = GetComponent<Collider2D>();
            }
        }

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