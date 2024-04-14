using Infrastructure;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "StaticData", menuName = "Data/StaticData")]
    public class StaticData : ScriptableObject
    {
        public EEntity Type;
        public GameObject Prefab;
    }
}
