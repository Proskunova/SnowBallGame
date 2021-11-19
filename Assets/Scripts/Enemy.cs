using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;

namespace Game
{
    public class Enemy : MonoBehaviour
    {
        public static event System.Action<int> OnScore;
        public event System.Action OnDead;

        [Header("Links")]
        [SerializeField] EnemyMoveController moveController;
        [SerializeField] EnemyAttack enemyAttack;
        [SerializeField] SkeletonAnimation anim;
        [SerializeField] HitCheck hitCheck;
        [SerializeField] BoxCollider2D collider2D;

        [Header("Data")]
        [SerializeField] Settings settings;
        [SerializeField] Transform pointOut;
        [SpineAnimation]
        [SerializeField] string idle;
        [SpineAnimation]
        [SerializeField] string walk;
        [SpineAnimation]
        [SerializeField] string attack;
        [SpineAnimation]
        [SerializeField] string hit;

        Coroutine cAttack;

        private void OnEnable()
        {
            hitCheck.OnHit += HitCheck_OnHit;
            moveController.OnEndMove += MoveController_OnEndMove;
        }
        
        private void OnDisable()
        {
            hitCheck.OnHit -= HitCheck_OnHit;
            moveController.OnEndMove -= MoveController_OnEndMove;
        }

        private void MoveController_OnEndMove()
        {
            anim.state.SetAnimation(0, idle, true);

            if (collider2D.enabled == false)
            {
                gameObject.SetActive(false);
                OnDead?.Invoke();
                return;
            }

            cAttack = StartCoroutine(WaitAttack());
        }

        private IEnumerator WaitAttack()
        {
            yield return new WaitForSeconds(Random.Range(1, settings.TimeIdleMax));
            transform.rotation = CheckRotation(transform.position + Vector3.left, transform);
            anim.state.SetAnimation(0, attack, false).Complete += Enemy_Complete;
            enemyAttack.AttackEnemy();
        }

        private void Enemy_Complete(Spine.TrackEntry trackEntry)
        {
            if (collider2D.enabled == false) return;

            Move();
        }

        private void HitCheck_OnHit()
        {
            if(cAttack != null)StopCoroutine(cAttack);
            transform.DOKill();
            OnScore?.Invoke(settings.Score);
            collider2D.enabled = false;

            StartCoroutine(HitRoutine());
        }

        private IEnumerator HitRoutine()
        {
            var track = anim.state.SetAnimation(0, hit, false);
            yield return new WaitForSpineAnimationComplete(track);
            anim.state.SetAnimation(0, walk, true);
            moveController.EnemyMove(pointOut.position);
        }

        private void Move()
        {
            moveController.EnemyMove();
            anim.state.SetAnimation(0, walk, true);
        }

        public void SetSettings(Settings newSettings)
        {
            settings = newSettings;
        }

        public void Init(RandomPointBox bounds, Pool poolFireballs, Transform pointOut)
        {
            this.pointOut = pointOut;
            moveController.Init(settings.Speed, bounds);
            enemyAttack.Init(settings.Power, poolFireballs);
            anim.initialSkinName = settings.Skin;
            anim.Initialize(true);
            anim.skeleton.SetSlotsToSetupPose();
        }

        public void Activate()
        {
            collider2D.enabled = true;
            gameObject.SetActive(true);

            Move();
        }

        public static Quaternion CheckRotation(Vector2 movePoint, Transform t)
        {
            if (movePoint.x < t.position.x && t.rotation.eulerAngles == Vector3.zero)
            {
                return Quaternion.Euler(Vector3.up * 180);
            }
            else if (movePoint.x > t.position.x && t.rotation.eulerAngles == Vector3.up * 180)
            {
                return Quaternion.Euler(Vector3.zero);
            }

            return t.rotation;
        }
    }
}