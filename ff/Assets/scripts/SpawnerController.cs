using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour 
{
	public Transform EnemyPrefab;
	public int MaxCount;
	public float SpawnDistance;

	private GameObject _player;
	private int count;

	private void Start () 
	{
		_player = GameObject.FindGameObjectWithTag ("Player");
		count = 0;
	}

	private void Update () 
	{
		if(count < MaxCount)
			Spawn ();
	}

	private void Spawn()
	{
		Instantiate(EnemyPrefab, GetPointToSpawn(), Quaternion.identity);
		count++;
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
