using UnityEngine;
using System.Collections;

public class ArrowAngleScript : MonoBehaviour {

	Rigidbody2D theRigidBody;
	float Damage;
	string EnemyTag;
	
	// Use this for initialization
	void Start () {
		theRigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		//theRigidBody.AddForce (Direction * speed);
		transform.rotation = Quaternion.FromToRotation(Vector3.up, theRigidBody.velocity);
	}

	public void CalculateAngle (Transform Target, float speed, float Damage, string EnemyTag)
	{
		//print (speed);
		this.Damage = Damage;
		this.EnemyTag = EnemyTag;

		if (EnemyTag

		theRigidBody = GetComponent<Rigidbody2D> ();
		float y = Target.transform.position.y - transform.position.y;
		float x = Target.transform.position.x - transform.position.x;
		if (x < 0) {
			x *= -1;
		}
		//print (x);
		//print (y);
		float g = -Physics2D.gravity.y;

		float power = Mathf.Pow(speed, 4);
		float gx = g * x * x;
		float yv2 = 2 * y * speed * speed;

		//float temp = (speed * speed * speed * speed) - (g * ((g * (x * x)) + (2 * y * (speed * speed))));
		float temp = power - (g * (gx + yv2));

		if (temp > 0) {
			temp = Mathf.Sqrt (temp);

			power = speed * speed;
			gx = g * x;
			//temp = (((speed * speed) + temp) / (g * x));
			temp = (power + temp)/gx;
			temp = Mathf.Atan(temp);
			//print (temp);
			temp *= Mathf.Rad2Deg;
			//temp += 10;
			//print (temp);
			Vector2 TempDir = Quaternion.AngleAxis (temp, Vector3.forward) * Vector2.right;
			if (Target.transform.position.x < transform.position.x)
			{
				TempDir.Set ( TempDir.x *-1, TempDir.y );
			}
			//print (Direction * speed);
			theRigidBody.AddForce (TempDir * speed, ForceMode2D.Impulse);
		} else {
			CalculateAngle (Target, speed + 1, Damage, EnemyTag);
		}
	}

	void OnCollisionEnter2D( Collision2D col ) {
		if (col.gameObject.tag == tag) {
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col.collider);
		} else if (col.gameObject.tag == EnemyTag)
		{
			AllyClass TempAlly = col.gameObject.GetComponent<AllyClass>();
			AI TempEnemy = col.gameObject.GetComponent<AI>();
			if ( TempAlly != null )
			{
				TempAlly.TakeDamage(Damage);
			}
			else if (TempEnemy != null)
			{
				TempEnemy.TakeDamage(Damage);
			}
		}
		Destroy(gameObject);
	}
}
