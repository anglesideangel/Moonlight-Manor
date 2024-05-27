using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    
    public Vector3 newStartPosition = new Vector3(9.323404f, 0.00470268f, 5.508661f);
    public Vector3 newStartRotation = new Vector3(0, 180, 0);


    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(newStartPosition, Quaternion.Euler(newStartRotation));
    }

}
