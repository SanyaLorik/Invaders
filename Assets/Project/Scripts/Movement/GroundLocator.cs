using UnityEngine;

namespace Invaders.Movement
{
    public class GroundLocator : MonoBehaviour
    {
        [SerializeField][Min(0)] private int _groundLayerId;
        [SerializeField][Range(0f, 3f)] private float _distance;
    }
}