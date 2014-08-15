using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void Update () {
		this.transform.Rotate(Vector3.down * Time.deltaTime * speed);
	}
}
