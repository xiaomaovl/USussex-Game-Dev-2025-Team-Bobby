using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayerChest : MonoBehaviour
{
    public GameObject PlayerHead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(PlayerHead.transform.position.x, 
                                              PlayerHead.transform.position.y,
                                              PlayerHead.transform.position.z);

        float delta = Mathf.Abs(Mathf.DeltaAngle(this.transform.eulerAngles.y, PlayerHead.transform.eulerAngles.y));

        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation,Quaternion.Euler(new Vector3(0, PlayerHead.transform.eulerAngles.y, 0)), Time.deltaTime * delta * 5f);
    }
}
