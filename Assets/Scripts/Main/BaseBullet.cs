using UnityEngine;

namespace Main
{
    public class BaseBullet: MonoBehaviour
    {
        [SerializeField] public int damage = 10;
        
        protected void SetDamage(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IVulnerable>(out var val))
            {
                val.TakeDamage(damage);
            };
        }
    }
}