using UnityEngine;

namespace TowerSystem
{
    public class TowerBuilder : MonoBehaviour
    {


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                CheckArea();
            }
        }

        private void CheckArea()
        {
            print("Check area");
            Collider[] hits = Physics.OverlapSphere(transform.position, 2f);
            

            foreach(Collider hit in hits)
            {
                if (hit.TryGetComponent(out BuildArea area))
                {
                    print(area.AreaType);
                }
            }

            
        }

        private void OnDrawGizmos()
        {
            //Gizmos.DrawSphere(transform.position, 2f);
        }

    }
}


