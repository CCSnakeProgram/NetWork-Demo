 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_mobile : MonoBehaviour
{
    private Material _material;

    private Vector2 mobile;

    public Vector2 Speen;
    // Start is called before the first frame update
    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    private void Update()
    {
        mobile += Speen * Time.deltaTime;
        _material.mainTextureOffset = mobile;
    }

}
