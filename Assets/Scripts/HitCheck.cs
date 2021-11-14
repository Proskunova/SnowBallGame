using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class HitCheck : MonoBehaviour
    {
        public static event Action<int> OnHit;

        private void OnTriggerEnter2D(Collider2D coll)
        {
            coll.gameObject.SetActive(false);

            OnHit?.Invoke(1);
            //Debug.Log(coll.gameObject.name);
        }
    }
}
