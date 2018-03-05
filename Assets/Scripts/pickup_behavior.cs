using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_behavior : MonoBehaviour {

    // Get all pickups in the scene
    GameObject[] pickups;

    // Is it spinning?
    public bool spinning;
    [Range(2.5f, 99.5f)]
    public float spin_speed_min;
    [Range(2.5f, 99.5f)]
    public float spin_speed_max;
    float[] rotate_speeds;

	// Use this for initialization
	void Start () {
        pickups = GameObject.FindGameObjectsWithTag("pickup");

        float rand_rotation;
        rotate_speeds = new float[pickups.Length];

        for (int index = 0; index < pickups.Length; index++)
        {
            rand_rotation = Random.Range(spin_speed_min, spin_speed_max);
            rotate_speeds[index] = rand_rotation;
        }
    }
	
	// Update is called once per frame
	void Update () {
		for(int index = 0; index < pickups.Length; index++)
        {
            GameObject pickup = pickups[index];
            if (pickup != null && spinning && spin_speed_max >= spin_speed_min)
            {
                RotateGameObject(pickup, rotate_speeds[index]);
            }
        }
	}

    void RotateGameObject(GameObject obj_to_rotate, float rotate_speed)
    {
        obj_to_rotate.transform.Rotate(Vector3.forward * rotate_speed * Time.deltaTime);
    }
}
