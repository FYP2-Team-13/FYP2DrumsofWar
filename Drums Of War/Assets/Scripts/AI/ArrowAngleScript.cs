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
		theRigidBody = GetComponent<Rigidbody2D> ();

		float y = Target.transform.position.y - transform.position.y;
		float x = (Target.transform.position - transform.position).magnitude;
		float g = Physics2D.gravity.y;
		float temp = (speed * speed * speed * speed) - (g * (g * (x * x) + 2 * y * (speed * speed)));

		this.Damage = Damage;
		this.EnemyTag = EnemyTag;

		temp = Mathf.Sqrt (temp);

		if (temp >= 0) {

			temp = Mathf.Atan (((speed * speed) + temp) / (g * x));
			//temp = Mathf.Rad2Deg;
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
		if (col.gameObject.tag == EnemyTag)
		{
			if (gameObject.GetComponent<AllyClass>() )
			{
				gameObject.GetComponent<AllyClass>().TakeDamage(Damage);
			}
			else if (gameObject.GetComponent<AI>())
			{
				gameObject.GetComponent<AI>().TakeDamage(Damage);
			}
		}
		Destroy(gameObject);
	}
}
