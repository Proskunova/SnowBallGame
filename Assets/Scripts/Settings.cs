using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "SO/Character Settings")]
    public class Settings : ScriptableObject
    {
        public float HealthsEnemy;
        public float Speed;
        public float TimeBetweenAttack;
        public float TimeCreateSnowBall;

        public int Score;

        [SpineSkin(dataField = "skeleton")]
        public string Skin;

        [SerializeField] SkeletonDataAsset skeleton;
    }
}
