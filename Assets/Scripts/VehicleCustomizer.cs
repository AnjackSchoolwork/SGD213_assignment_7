using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCustomizer : MonoBehaviour {

    [SerializeField]
    Material material_red;
    [SerializeField]
    Material material_green;
    [SerializeField]
    Material material_blue;

    Renderer[] child_renderers;

	// Use this for initialization
	void Start () {

        child_renderers = GetComponentsInChildren<Renderer>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach(Renderer child_rend in child_renderers)
            {
                child_rend.material = material_red;
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            foreach (Renderer child_rend in child_renderers)
            {
                child_rend.material = material_green;
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            foreach (Renderer child_rend in child_renderers)
            {
                child_rend.material = material_blue;
            }
        }
	}
}
