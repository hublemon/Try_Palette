using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;   
    private RaycastHit hit;
    
    public float _speed=3f;
    public float _turnSpeed = 2f;

    private Vector3 _horizon;
    private Vector3 _vertical;
    private Vector3 _desiredMoveDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1 || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1)
        {
            _horizon = transform.right * Input.GetAxis("Horizontal");
            _vertical = transform.forward * Input.GetAxis("Vertical");
            
        }
        else return;

        _desiredMoveDir = _horizon + _vertical;
        rb.MovePosition(transform.position + (_horizon + _vertical) * Time.deltaTime * _speed);
        LookAt(_desiredMoveDir);
    }

    private void LookAt(Vector3 pos)
    {
        Quaternion lookAtRotation = Quaternion.LookRotation(pos);
        Quaternion lookAtRotationOnly_Y = Quaternion.Euler(transform.rotation.eulerAngles.x, lookAtRotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookAtRotationOnly_Y, _turnSpeed*Time.deltaTime);
    }
}
