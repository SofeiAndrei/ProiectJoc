using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 7;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, 100 * Time.deltaTime);
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up, 100 * Time.deltaTime);
        }   

        var dir = new Vector3(0, 0, Input.GetAxis("Vertical"));

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0.1)
        {
            transform.Translate(dir * 2 * speed * Time.deltaTime);
            animator.SetBool("shift_pressed", true);
        }
        else
        {
            transform.Translate(dir * speed * Time.deltaTime);
            animator.SetBool("shift_pressed", false);
        }
        
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
    }
}
