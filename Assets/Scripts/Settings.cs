using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    [CreateAssetMenu(menuName = "SO/Character Settings")]
    public class Settings : ScriptableObject
    {
        public float _healthsEnemy;
        public float _speed;
        public float _timeBetweenAttack;
        public float _timeCreateSnowBall;

        public int _score;
        [SpineSkin(dataField = "skeleton")]
        public string Skin;

        [SerializeField] SkeletonDataAsset skeleton;
    }
}
