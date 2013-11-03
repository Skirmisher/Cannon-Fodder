using UnityEngine;
using System.Collections;

public class TurretControl_Horizontal : MonoBehaviour
{

    public float RotationSpeed = 1f;

	// Update is called once per frame
	void Update () {
        var angle = Input.GetAxis("Horizontal") * RotationSpeed;
        transform.Rotate(Vector3.up, angle);
	}
}
