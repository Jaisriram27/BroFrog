using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    int flag=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flag>0)
        {
            Destroy(this);
            flag=0;
        }
    }
        private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.CompareTag("Player"))
        {
            flag++;
        }  
    }
    
}
