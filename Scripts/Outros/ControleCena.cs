using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class ControleCena : MonoBehaviour
{
        public Flowchart fungus;
        public bool liberarJogo = false;
        public GameObject[] UiElementos;
        public int execUmaVez = 0;
        // Start is called before the first frame update
        void Start()
        {
            if (execUmaVez == 0)
            {
                for (int i = 0; i < UiElementos.Length; i++)
                {
                    UiElementos[i].SetActive(false);
                }
                    fungus.ExecuteBlock("Start");
                    execUmaVez++;
            }
    }

    // Update is called once per frame
    void Update()
    {
        if (!fungus.HasExecutingBlocks())
        {
            for (int i = 0; i < UiElementos.Length; i++)
            {
                UiElementos[i].SetActive(true);
                print("Entrou");
                liberarJogo = true;
            }
        }
    }
}
 
