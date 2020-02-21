using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEsqueleto : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform vilao;
    void Start()
    {
        vilao = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        vilao.transform.Translate(new Vector2(-5f*Time.deltaTime, 0));
    }
}
