using UnityEngine;

namespace UIInitialization
{
    [CreateAssetMenu(fileName = "CanvasPrefabs", menuName = "ScriptableObjects/CanvasPrefabs", order = 2)]
    public class GameplayCanvasPrefabsSO : ScriptableObject
    {
        [SerializeField] private GameObject _PCCanvasPrefab;
        [SerializeField] private GameObject _mobileCanvasPrefab;

        public GameObject PCCanvasPrefab => _PCCanvasPrefab;
        public GameObject MobileCanvasPrefab => _mobileCanvasPrefab;
    }
}

