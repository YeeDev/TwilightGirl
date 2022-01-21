using UnityEngine;

namespace TG.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover2D : Mover
    {
        Rigidbody2D rb;

        private void Awake() { rb = GetComponent<Rigidbody2D>(); }

        public override bool IsRigidbodyEnabled() { return !rb.isKinematic; }
        public override void Move(float xAxis, float zAxis) { rb.velocity = CalculateDirection(xAxis); }

        private Vector2 CalculateDirection(float xAxis)
        {
            Vector2 moveDirection = Vector2.zero;
            moveDirection.x = xAxis * Speed;
            moveDirection.y = rb.velocity.y;

            return moveDirection;
        }

        public override void SetBehaviorOnMovement(bool use3DMovement)
        {
            rb.bodyType = use3DMovement ? RigidbodyType2D.Kinematic : RigidbodyType2D.Dynamic;
            rb.velocity = Vector3.zero;
        }

        public override void Jump(bool halt) { rb.velocity = CalculateJumpForce(halt); } 

        private Vector2 CalculateJumpForce(bool halt)
        {
            Vector2 jumpVelocity = rb.velocity;
            jumpVelocity.y = halt ? rb.velocity.y > 0 ? jumpVelocity.y * 0.5f : rb.velocity.y : JumpForce;

            return jumpVelocity;
        }
    }
}