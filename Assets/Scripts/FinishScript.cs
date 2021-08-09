using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider Player)
    {
        if (Player.GetComponent<MovementScript>() != null)
        {
            Player.GetComponent<MovementScript>().Finished = true;
        }
    }
}
