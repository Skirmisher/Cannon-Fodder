using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour
{

    public GameObject HorizontalAngle;
    public GameObject VerticalAngle;
    public float FireCoolDownTime = 1f;
    private bool _canFire;
    public float TurretMussleOffset = 0.5f;

    public GameObject CurrentWeapon;
	
	public AudioClip FireSoundEffect;

	// Use this for initialization
	void Start ()
	{
	    _canFire = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButton("Fire1") && _canFire)
	    {
	        _canFire = false;

            //var hAngle = HorizontalAngle.transform.eulerAngles.y;
            //var vAngle = VerticalAngle.transform.eulerAngles.y;

            //Debug.Log("Horizontal = " + hAngle + "   Vertical = " + vAngle);

            this.Wait(FireCoolDownTime, () =>_canFire = true);

	        var bullet = (GameObject) Instantiate(CurrentWeapon, transform.position, Quaternion.LookRotation(VerticalAngle.transform.forward));
            bullet.transform.Translate(Vector3.forward * TurretMussleOffset);
			
			AudioSource.PlayClipAtPoint(FireSoundEffect, transform.position);
	    }
	}

}
