using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosaoEsqueleto : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao") || outro.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
