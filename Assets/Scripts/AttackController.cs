using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;

namespace Game
{
    public class AttackController : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] Settings _settings;
        [SerializeField] Button _buttonAttack;
        [SerializeField] Pool _poolSnowBall;
        [SerializeField] Transform _spawnPoint;
        [SerializeField] Slider _slider;
        [SerializeField] Image _image;
        [SerializeField] SkeletonAnimation _anim;

        private void Awake()
        {
            _buttonAttack.onClick.AddListener(Fire);
        }

        private void Attack()
        {
            _anim.state.SetAnimation(0, "jump_up", false);
            _anim.state.AddAnimation(0, "Idle", true, 0);

            float powerY = _slider.value * _settings.Power;
            GameObject snowB = _poolSnowBall.GetSnowBall();
            if (snowB == null) return;
            snowB.transform.position = _spawnPoint.position;
            snowB.SetActive(true);
            snowB.GetComponent<Rigidbody2D>().AddForce(new Vector2(powerY*2, powerY));
            
            Debug.Log("attack");
        }

        private void Cooldown()
        {
            _image.DOFillAmount(1, _settings.TimeBetweenAttack).SetEase(Ease.Linear).OnComplete(delegate
            {
                _buttonAttack.interactable = true;
            });
        }

        private void Fire()
        {
            _buttonAttack.interactable = false;
            _image.fillAmount = 0;

            Attack();
            Cooldown();
        }

    }
}