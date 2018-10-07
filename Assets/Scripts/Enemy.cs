using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] float health = 100;
	[SerializeField] float minTimeBetweenShots = 0.2f;
	[SerializeField] float maxTimeBetweenShots = 0.3f;
	[SerializeField] GameObject laserPrefab;
	[SerializeField] float projectileSpeed = 8f;
	[SerializeField] GameObject explosionPrefab;
	[SerializeField] AudioClip deathSfx;
	[SerializeField] [Range(0,1)] float deathSfxVol = 1f;
	[SerializeField] AudioClip laserSfx;
	[SerializeField] [Range(0,1)] float laserSfxVol = 1f;
	[SerializeField] int reward = 150;

	GameSession gameSession;
	float shotCounter;
	

	// Use this for initialization
	void Start () {
		shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
		gameSession = FindObjectOfType<GameSession>();
	}
	
	// Update is called once per frame
	void Update () {
		CountDownAndFire();
	}

	private void CountDownAndFire()
	{
		shotCounter -= Time.deltaTime;
		if (shotCounter <= 0f)
		{
			Fire();
			shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
		}
	}

	private void Fire()
	{
		GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint(laserSfx, Camera.main.transform.position, laserSfxVol);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
		if (!damageDealer) {return;}
		damageDealer.Hit();
		health -= damageDealer.GetDamage();
		if (health <= 0)
		{
			Kill();
		}
	}

	private void Kill()
	{
		var explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(deathSfx, Camera.main.transform.position, deathSfxVol); 
		gameSession.AddToScore(reward);
		//camera pos used to keep sounds level
		Destroy(gameObject);
		Destroy(explosion, 1f);
	}
}
