using UnityEngine;
using System.Collections;

public class FlyingMonster : MonoBehaviour
{
    public float HP = 100;
    public enum States { Alive, Dead }

    private States _state;

    public float TurningAngle = 30f;
    public float MinDirection = 1f;
    public float MaxDirection = 2f;

    public float Speed = 1f;
	
	public GameObject DetonatorGameObject;
	private Detonator _detonator;

	// Use this for initialization
    public void Start ()
	{
	    _state = States.Alive;
		
		_detonator = DetonatorGameObject.GetComponent<Detonator>();
		
		if (_detonator==null)
			Debug.Break();

	    SetFlightCourse();
	}

    private void SetFlightCourse()
    {
        var angle = Random.Range(-TurningAngle, TurningAngle);
        transform.Rotate(Vector3.up, angle);

        var time = Random.Range(MinDirection, MaxDirection);
        this.Wait(time, SetFlightCourse);
    }


    public void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }


    public void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Bullets")
        {
            if (_state == States.Alive && HP > 0)
            {
                var vFinal = obj.rigidbody.mass * obj.relativeVelocity / (rigidbody.mass + obj.rigidbody.mass);
                var impulse = vFinal * rigidbody.mass;

                //Debug.Log(obj.gameObject.name + "  vFinal = " + vFinal + "(" + vFinal.magnitude + ")  impulse = " + impulse + " (" + impulse.magnitude + ")");
                HP -= obj.gameObject.GetComponent<BulletStat>().Damage*vFinal.magnitude;
                Debug.Log("HP = " + HP);

                if (HP <= 0)
                {
					var detonator = 
                    _state = States.Dead;
                    Debug.Log("Dead");
					audio.Play();
					_detonator.Explode();
					Destroy(gameObject, 3);
                }
            }
        }
    }
}
