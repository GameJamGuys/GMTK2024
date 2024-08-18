using System.Collections.Generic;
using TowerSystem;
using UnityEngine;

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

        if (activeTower != null)
        {
            activeTower.HideUpgrades();
        }

        if (nearestTower != null)
        {
            activeTower = nearestTower;
            activeTower.ShowUpgrades();
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
            UpdateActiveTower();
        }
    }
}