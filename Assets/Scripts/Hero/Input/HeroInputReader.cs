using Components;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Hero.Input
{
    [RequireComponent(typeof(PlayerInput), typeof(MovementComponent))]
    public class HeroInputReader : MonoBehaviour
    {
        private const string HeroMovementActionName = "Movement";

        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private MovementComponent movementComponent;

        private InputAction _movement;

        private void Awake()
        {
            _movement = playerInput.actions[HeroMovementActionName];
        }

        public void Update()
        {
            if (_movement == null)
            {
                return;
            }

            var direction = _movement.ReadValue<Vector2>();
            movementComponent.SetDirection(direction);
        }
    }
}