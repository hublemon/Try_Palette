using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PaintManager : MonoBehaviour
{
    public Shader _wallDraw;
    public Shader _wall;

    Material _firstMaterial;
    Material _lastMaterial;

    // Start is called before the first frame update
    void Awake()
    {
        _firstMaterial = new Material(_wallDraw);
        _lastMaterial = new Material(_wall);
        _lastMaterial.color = _firstMaterial.color;
    }

    public void ChangeShader(GameObject collider)
    {
        Material _wallMat;
        _wallMat = collider.gameObject.GetComponent<Material>();
        _wallMat.shader = _wallDraw;
        StartCoroutine(Change());
        _wallMat.shader=_wall;
    }
    
    IEnumerator Change()
    {
        yield return new WaitForSeconds(3.5f);
    }

    // Update is called once per frame
    
}
