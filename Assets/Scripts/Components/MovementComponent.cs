using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private Rigidbody2D targetRigidbody;
        [SerializeField] private LayerCheckComponent platformCheck;
        [SerializeField] private Attractable attractable;

        private Vector2 _direction;

        private void FixedUpdate()
        {
            if (_direction == Vector2.zero)
            {
                return;
            }

            DoMove();
            DoJump();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void DoJump()
        {
            var isJumping = _direction.y > 0;
            if (isJumping && IsOnGround())
            {
                targetRigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        private void DoMove()
        {
            var attractor = attractable.Attractor;
            var moveDirection = attractor.Normal.x != 0
                ? new Vector2(targetRigidbody.velocity.x, _direction.x * attractor.Normal.x * speed)
                : new Vector2(_direction.x * -attractor.Normal.y * speed, targetRigidbody.velocity.y);

            targetRigidbody.velocity = moveDirection;
        }

        private bool IsOnGround()
        {
            return platformCheck.IsTouchingLayer;
        }
    }
}