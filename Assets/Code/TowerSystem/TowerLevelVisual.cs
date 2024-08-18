using System.Collections.Generic;
using UnityEngine;

namespace TowerSystem
{
    public class TowerLevelVisual : MonoBehaviour
    {
        [SerializeField] private List<GameObject> levelObjects = new();

        private void Start()
        {
            for (int i = 0; i < levelObjects.Count; i++)
            {
                if (i != 0)
                {
                    levelObjects[i].SetActive(false);
                }
                else
                {
                    levelObjects[i].SetActive(true);
                }
            }
        }

        public void LevelUp(int level)
        {
            if (level < levelObjects.Count)
            {
                levelObjects[level].SetActive(true);
            }
        }
    }
}