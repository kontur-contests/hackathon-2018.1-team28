using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnerController : MonoBehaviour 
{
	public Transform EnemyPrefab;
	public int MaxCount;
	public float SpawnDistance;

	private GameObject _player;
	private int _count;

    public void Decrement()
    {
        if(_count > 0)
            Interlocked.Decrement(ref _count);
    }

    private void Start () 
	{
		_player = GameObject.FindGameObjectWithTag ("Player");
		_count = 0;
	}

	private void Update () 
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
        Instantiate(EnemyPrefab, GetPointToSpawn(), Quaternion.identity);	    
	}

	private Vector3 GetPointToSpawn()
	{
		float radian = Random.Range(0f, Mathf.PI*2);
		var x = Mathf.Cos(radian);
		var y = Mathf.Sin(radian);
		var spawnPoint = new Vector3 (x, y, 0) * SpawnDistance;
		return _player.transform.position + spawnPoint;
	}
	
}
