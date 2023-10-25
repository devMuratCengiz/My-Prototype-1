using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Transform player;
    public float delayTime = 10f;
    public bool itsOk = true;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MonsterMove();
        Follow();
        //transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);

    }
    void MonsterMove()
    {

        if (itsOk)
        {
            
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime,0,0));
            
        }

    }
    void Follow()
    {
        if (itsOk)
        {
            float hedefY = player.position.y;
            float mevcutY = transform.position.y;
            float yeniY = Mathf.SmoothDamp(mevcutY, hedefY, ref delayTime, 1f);
            transform.position = new Vector3(transform.position.x, yeniY, transform.position.z);
        }
        
    }
    
}
