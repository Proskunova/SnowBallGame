using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] Settings settings;
    [SerializeField] SimpleInputNamespace.Joystick joystick;

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * settings.Speed * joystick.Value);
    }
}
