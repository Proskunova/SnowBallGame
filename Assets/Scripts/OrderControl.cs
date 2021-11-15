using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Spine.Unity;

namespace Game
{
    public class OrderControl : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] MeshRenderer renderer;

        private void Update()
        {
            int order = (int)(transform.position.y * 10 * -1);
            renderer.sortingOrder = order;
        }
    }
}