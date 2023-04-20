using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    public GameObject block;  public int flag=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flag>0)
        {
            Destroy(block);
            flag=0;
        }
    }
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("BreakableBlock"))
        {
            Debug.Log("colliding");
            flag++;
            block=other.gameObject;
        }
        if(other.gameObject.CompareTag("Collectible"))
        {
            Debug.Log("colliding");
            flag++;
            block=other.gameObject;
        }
    }
}
