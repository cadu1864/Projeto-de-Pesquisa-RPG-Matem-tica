using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


    public class ControleCena : MonoBehaviour
    {


        public Flowchart fungus;
        public GameObject[] UiElementos;
        public int execUmaVez = 0;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (execUmaVez == 0)
            {
                for (int i = 0; i < UiElementos.Length; i++)
                {
                    UiElementos[i].SetActive(false);
                }
            ;
            }
        }
    }
