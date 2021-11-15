using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerHit : MonoBehaviour
    {
        public static event System.Action OnHit;

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.CompareTag("FireBall"))
            {
                coll.gameObject.SetActive(false);
                OnHit?.Invoke();
            }
        }
    }
}