using UnityEngine;
using System.Collections;

public class BulletStat : MonoBehaviour
{
    public float Force = 1000f;
    public float AliveTime = 5f;
    public float CollisionAlive = 3f;
    public float Damage = 1f;

	// Use this for initialization
    public void Start()
    {
        rigidbody.AddForce(transform.forward*Force);
        Destroy(gameObject, AliveTime);
    }

    // Update is called once per frame
    public void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Monsters")
        {
            //var vFinal = obj.rigidbody.mass * obj.relativeVelocity / (rigidbody.mass + obj.rigidbody.mass);
            //var impulse = vFinal * rigidbody.mass;

            //Debug.Log(obj.gameObject.name + "  vFinal = " +  vFinal + "(" + vFinal.magnitude + ")  impulse = " + impulse + " (" + impulse.magnitude + ")");

            Destroy(gameObject, CollisionAlive);
        }
    }
}
