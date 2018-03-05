using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int score;
    public Text score_text;

    public float char_speed;
    public float char_jump_power;
    [Range(1, 30)]
    public int camera_rotation_speed;
    
    protected Rigidbody char_rb;
    protected Collider char_collider;
    protected Camera char_camera;
    protected Animation char_anim;

    // Use this for initialization
    void Start()
    {
        score = 0;
        char_rb = GetComponent<Rigidbody>();
        char_collider = GetComponent<Collider>();
        char_camera = Camera.main;
        char_anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1))
        {
            rotateCamera();
        }
    }

    private void FixedUpdate()
    {
        if (Input.anyKey)
        {
            moveChar(getMoveDirection());
        }

    }

    Vector3 getMoveDirection()
    {

        Vector3 move_direction = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            move_direction += char_camera.transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            move_direction += char_camera.transform.right * -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            move_direction += char_camera.transform.right;
        }

        if (Input.GetKey(KeyCode.S))
        {
            move_direction += char_camera.transform.forward * -1;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (IsOnGround())
            {
                char_rb.AddForce(Vector3.up * char_jump_power, ForceMode.Impulse);
            }
        }

        Vector3 move_vector = transform.position + (move_direction * char_speed * Time.deltaTime);

        return move_vector;
    }

    void moveChar(Vector3 move_vector)
    {
        // Then move
        //char_control.SimpleMove(move_vector);
        char_rb.MovePosition(move_vector);
        char_anim.Play("Walk");
    }

    void rotateCamera()
    {
        float h_rot = 2.0f * Input.GetAxis("Mouse X");
        float v_rot = 2.0f * Input.GetAxis("Mouse Y");


        // Horizontal rotation
        transform.Rotate(Vector3.up * h_rot * camera_rotation_speed);

        // Vertical rotation
        char_camera.transform.RotateAround(transform.position, -transform.right, v_rot);
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pickup")
        {
            score += 20;
            score_text.text = "Score: " + score;
            Debug.Log(score_text.text);
            Destroy(other.gameObject);
        }
    }

    bool IsOnGround()
    {
        return Physics.Raycast(transform.position, -Vector3.up, char_collider.bounds.extents.y);
    }
}
