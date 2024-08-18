using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(menuName = "Scriptable/EnemyWave", order = 1, fileName = "EnemyWave")]
    public class EnemiesWavesSO : ScriptableObject
    {
        [field:Header("Список волн")]
        [field:SerializeField] public List<Wave> Waves { get; private set; }
    }
    
    [Serializable]
    public class Wave
    {
        [Header("Пульс - это спавн группы врагов")]
        public List<WavePulse> Pulses = new ();
    }

    [Serializable]
    public class WavePulse
    {
        [Header("Перерыв до следующего пульса")]
        public float PulseCooldown;
        [Header("Список врагов с их количеством, которых надо заспавнить в этот пульс")]
        public List<WavePulseEnemy> Enemies = new ();
    }
    
    [Serializable]
    public class WavePulseEnemy
    {
        [Header("Префаб врага")]
        public BaseEnemy EnemyPrefab;
        [Header("Количество врагов для спавна")]
        public int Count;
    }
}