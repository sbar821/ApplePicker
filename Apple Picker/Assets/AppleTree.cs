using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    public float object1DropChance = 0.8f;
    [Range(0f, 1f)]
    public float object2DropChance = 0.2f;
    public GameObject applePrefab;
    public GameObject spiderPrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = .1f;
    public float appleDropDelay = 1f;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("TryDropObject", 2f);
        //Invoke("DropApple", 2f);
    }

    void TryDropObject()
    {
        float rand = Random.value;

        if (rand < object1DropChance)
        {
            DropApple();
        }
        else if (rand < object1DropChance + object2DropChance)
        {
            DropSpider();
        }
        // Else: do nothing (if total chance is < 1)
    }



    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("TryDropObject", 2f);
    }

    void DropSpider()
    {
        GameObject spider = Instantiate<GameObject>(spiderPrefab);
        spider.transform.position = transform.position;
        Invoke("TryDropObject", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        // else if (Random.value < changeDirChance)
        // {
        //     speed *= -1;
        // }
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}
