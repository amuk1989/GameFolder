using UnityEngine;

namespace Aim
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        public void Throw(Vector3 power)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(power, ForceMode.Impulse);
        }
    }
}