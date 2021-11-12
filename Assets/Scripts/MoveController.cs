using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] Settings _settings;
        [SerializeField] SimpleInputNamespace.Joystick _joystick;

        private void Update()
        {
            if (transform.position.y > -3.55 && transform.position.y < 2.6)
            {
                transform.Translate(Vector3.up * Time.deltaTime * _settings.Speed * _joystick.Value);
            }
        }
    }
}