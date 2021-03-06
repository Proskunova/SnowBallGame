using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class HitCheck : MonoBehaviour
    {
        public event System.Action OnHit;

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.CompareTag("SnowBall"))
            {
                coll.gameObject.SetActive(false);
                OnHit?.Invoke();
            }
        }
    }
}
