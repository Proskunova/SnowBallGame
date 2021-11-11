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
            transform.Translate(Vector3.up * Time.deltaTime * _settings._speed * _joystick.Value);
        }
    }
}