using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterCollide : MonoBehaviour
{
    Monster monsterClass;
    
    // Start is called before the first frame update
    void Start()
    {
        monsterClass = GameObject.Find("Monster Parent").GetComponent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(collision.gameObject);
        
        if (collision.gameObject.tag=="Player")
        {
            monsterClass.itsOk = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
           

        }
    }
}
