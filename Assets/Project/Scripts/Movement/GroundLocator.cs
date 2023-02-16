using UnityEngine;

namespace Invaders.Movement
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class GroundLocator : MonoBehaviour
    {
        [SerializeField][Min(0)] private int _groundLayerId;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == _groundLayerId)
                IsGround = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.layer == _groundLayerId)
                IsGround = false;
        }
        public bool IsGround { get; private set; }
    }
}