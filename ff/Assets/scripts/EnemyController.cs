using System.Collections;
using System.Collections.Generic;
using Assets.scripts;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int Damage;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        var damagedObject = col.gameObject.GetComponent<IDamageable>();
        damagedObject?.GetDamage(Damage);
    }
}
