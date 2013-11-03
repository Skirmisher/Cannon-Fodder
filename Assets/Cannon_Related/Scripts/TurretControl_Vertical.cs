using UnityEngine;
using System.Collections;

public class TurretControl_Vertical : MonoBehaviour {

    public float RotationSpeed = 1f;
    public float MinAngle = 0;
    public float MaxAngle = 45;

	
	// Update is called once per frame
	void Update () {
        var angle = Input.GetAxis("Vertical") * RotationSpeed;

	    //var futureAngle = transform.eulerAngles.x + angle;
        //if (futureAngle<=MaxAngle && futureAngle>= MinAngle)
            transform.Rotate(Vector3.left, angle);
    }
}
