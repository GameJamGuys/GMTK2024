using System.Collections.Generic;
using Damage;
using UnityEngine;

namespace Enemy
{
    public class GoldenShrimpEnemy : BaseEnemy
    {
        [SerializeField]
        GameObject chest;


        public override void BeforeDead()
        {
            base.BeforeDead();
            Instantiate(chest, transform.position, Quaternion.identity);
        }


    }
}