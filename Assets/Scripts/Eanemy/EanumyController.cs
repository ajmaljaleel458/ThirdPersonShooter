using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EanemySurvival
{
    public class EanumyController : MonoBehaviour
    {
        public int EanemyHealth = 100;
        private void Update()
        {
            if (EanemyHealth <= 0)
            {
                DestroyImmediate(gameObject);
            }
        }

        void ApplyDamage(int damage)
        {
            EanemyHealth -= damage;
        }
    }
}

