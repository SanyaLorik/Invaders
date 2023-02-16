using UnityEngine;

namespace Invaders.Movement
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class SurfaceSlider : MonoBehaviour
    {
        [SerializeField][Min(0)] private int _groundLayerId;

        private Vector3 _normal;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == _groundLayerId)
                _normal = collision.contacts[0].normal;
        }

        public Vector3 Project(Vector3 forward) =>
            forward - Vector3.Dot(forward, _normal) * _normal;

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, transform.position + _normal * 3);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Project(transform.forward));
        }
#endif
    }
}