using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Pointer : MonoBehaviour
{
    private RaycastHit hit;
    private Vector3 click;
    private float _waitingTime=0f;
    private Renderer _colliderRend;

    public Shader _wallDraw;
    public Shader _wall;

    bool change=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _waitingTime += Time.deltaTime;

            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50f);
            Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition).origin, hit.point - Camera.main.ScreenPointToRay(Input.mousePosition).origin, Color.red);
            if (hit.point != null && hit.collider.tag == "Env")
            {

                click = hit.point;

                _colliderRend = hit.collider.gameObject.GetComponent<Renderer>();
                if (_colliderRend.material.shader != _wall)
                {
                    _colliderRend.material.shader = _wallDraw;
                    if (_waitingTime >= 4.5f)
                    {
                        _colliderRend.material.shader = _wall;
                        _waitingTime = 0f;
                    }
                }
                else return;
            }
        }
        else _waitingTime = 0f; 
    }

    
}
