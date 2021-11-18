using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MoveController : MonoBehaviour
    {
        enum MoveState
        {
            Idle,
            Move
        }

        [Header("Links")]
        [SerializeField] Settings _settings;
        [SerializeField] SimpleInputNamespace.Joystick _joystick;
        [SerializeField] RandomPointBox _box;

        private MoveState _currentState;
        private SkeletonAnimation _skeletonAnimation;

        private void Awake()
        {
            _currentState = MoveState.Idle;
            _skeletonAnimation = this.GetComponent<SkeletonAnimation>();
        }

        private void Start()
        {
            _skeletonAnimation.state.SetAnimation(0, "Idle", true);
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

            PlayerAnim();
        }

        private void PlayerAnim()
        {
            Vector2 value = _joystick.Value;
            if (value.y == 0f && _currentState == MoveState.Move)
            {
                _skeletonAnimation.state.SetAnimation(0, "Idle", true);
                _currentState = MoveState.Idle;
            }
            else if (value.y != 0 && _currentState == MoveState.Idle)
            {
                _skeletonAnimation.state.SetAnimation(0, "walk", true);
                _currentState = MoveState.Move;
            }
        }
    }
}