using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

    Light[] lights_array;

	// Use this for initialization
	void Start () {

        lights_array = FindObjectsOfType<Light>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach(Light light_instance in lights_array)
            {
                light_instance.enabled = !light_instance.enabled;
            }
        }
	}
}
