using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] Settings _settings;
        [SerializeField] SimpleInputNamespace.Joystick _joystick;
        [SerializeField] RandomPointBox _box;

        private SkeletonAnimation _skeletonAnimotion;
        //private Vector2 temp;
        private void Awake()
        {
            _skeletonAnimotion = this.GetComponent<SkeletonAnimation>();
        }

        private void Update()
        {
            //print("_joystick.Value.y = " + _joystick.Value.y);
            if(_joystick.Value.y > 0)
            {
                if (transform.position.y > _box.GetBoundMax.y) return;
            }
            if (_joystick.Value.y < 0)
            {
                if (transform.position.y < _box.GetBoundMin.y) return;
            }

          transform.Translate(Vector3.up * Time.deltaTime * _settings.Speed * _joystick.Value);
            //PlayerAnim();
        }

        //private void PlayerAnim()
        //{

        //    Vector2 value = _joystick.Value;
        //    if (value.y = 0f)
        //    {
        //        _skeletonAnimotion.AnimationName = "idle";
        //    }
        //        _skeletonAnimotion.AnimationName = "walk";
        //}
    }
}