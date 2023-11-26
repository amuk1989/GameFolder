using System.Collections;
using UnityEngine;

namespace Zombies
{
    [CreateAssetMenu(fileName = "ZombiesRegistry", menuName = "Registries/ZombiesRegistry", order = 0)]
    public class ZombiesRegistry : ScriptableObject
    {
        [SerializeField] private Zombie[] _zombiesPrefabs;

        public IEnumerable ZombiesPrefabs => _zombiesPrefabs;
    }
}