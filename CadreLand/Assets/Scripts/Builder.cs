using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // must tag camera MainCamera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
               print(hit.transform.name);
               
               GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
               var scale = 10f;
               box.transform.localScale = new Vector3(scale, scale, scale);
               box.transform.position = hit.point + new Vector3(0,scale/2.5f,0);

            }

            
        }
    }
    
    
}
