using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class TriggerZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.gameObject.SetActive(false);
        }
    }
}
