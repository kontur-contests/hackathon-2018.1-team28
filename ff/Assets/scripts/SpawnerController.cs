using System.Diagnostics.CodeAnalysis;
using System.Threading;
using UnityEngine;

namespace Assets.scripts
{
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    public class SpawnerController : MonoBehaviour
    {
        private int _count;

        private GameObject _player;
        public Transform EnemyPrefab;
        public int MaxCount;
        public float SpawnDistance;

        public void Decrement()
        {
            if (_count > 0)
                Interlocked.Decrement(ref _count);
        }

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
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
            var enemy = Instantiate(EnemyPrefab, GetPointToSpawn(), Quaternion.identity);
            enemy.GetComponent<EnemyController>().SetSpawner(this);
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