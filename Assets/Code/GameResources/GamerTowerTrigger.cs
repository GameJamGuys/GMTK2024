using System.Collections.Generic;
using TowerSystem;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GamerTowerTrigger : MonoBehaviour
{
    public HashSet<Tower> towers = new ();
    private Tower activeTower;
    private Vector3 oldPosition;

    private void Update()
    {
        if (Vector3.Distance(oldPosition, transform.position) > .2f)
        {
            oldPosition = transform.position;
            UpdateActiveTower();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            UpgradeCurrentTower();
        }
    }

    private void UpdateActiveTower()
    {
        Tower nearestTower = null;

        foreach (var tower in towers)
        {
            if (nearestTower == null || Vector3.Distance(nearestTower.transform.position, transform.position) > Vector3.Distance(tower.transform.position, transform.position))
            {
                nearestTower = tower;
            }
        }

        if (nearestTower == activeTower)
        {
            return;
        }

        if (nearestTower != null)
        {
            if (activeTower != null)
            {
                activeTower.UpgradeView.UnHover();
            }

            activeTower = nearestTower;
            activeTower.UpgradeView.Hover();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Tower tower))
        {
            towers.Add(tower);
            UpdateActiveTower();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out Tower tower))
        {
            towers.Remove(tower);

            if (tower == activeTower)
            {
                activeTower.UpgradeView.UnHover();
                activeTower = null;
            }

            UpdateActiveTower();
        }
    }

    private void UpgradeCurrentTower()
    {
        if (activeTower == null)
        {
            return;
        }
        
        activeTower.UpgradeLevel();
    }
}