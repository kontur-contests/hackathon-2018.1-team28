using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using UnityEngine;

namespace Assets.scripts
{
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
    public class SpawnerController : MonoBehaviour
    {
        private int _count;

        public List<GameObject> PlayerPrefabs;
        public List<GameObject> PlayerWeapons;
        private GameObject _player;
        public List<Transform> EnemyPrefabs;
        public int MaxCount;
        public float SpawnDistance;

        public void Decrement()
        {
            if (_count > 0)
                Interlocked.Decrement(ref _count);
        }

        private void Awake()
        {
            var difficult = GlobalGameState.GetInstance().Difficult;
            Debug.Log($"difficult={difficult}");
            _player = Instantiate(PlayerPrefabs[difficult-1], Vector3.zero, Quaternion.identity);
            //_player.GetComponent<PlayerController>().Weapon = PlayerWeapons[difficult - 1];

            GameObject.Find("Main Camera").GetComponent<CameraController>().FollowWhom = _player.transform;
            _count = 0;
        }

        private void Update()
        {
            if (_count < MaxCount && Random.Range(0, 10) % 2 == 0)
            {
                Interlocked.Increment(ref _count);
                Spawn();
                Debug.Log($"Spawned bug {_count} of {MaxCount}");
            }
        }

        private void Spawn()
        {
            var pref = GetEnemy();
            var enemy = Instantiate(pref, GetPointToSpawn(), Quaternion.identity);
            enemy.GetComponent<EnemyController>().SetSpawner(this);
        }

        private Transform GetEnemy()
        {
            var num = Random.Range(0, EnemyPrefabs.Count);
            return EnemyPrefabs[num];
        }

        private Vector3 GetPointToSpawn()
        {
            var radian = Random.Range(0f, Mathf.PI * 2);
            var x = Mathf.Cos(radian);
            var y = Mathf.Sin(radian);
            var spawnPoint = new Vector3(x, y, 0) * SpawnDistance;
            return _player.transform.position + spawnPoint;
        }
    }
}