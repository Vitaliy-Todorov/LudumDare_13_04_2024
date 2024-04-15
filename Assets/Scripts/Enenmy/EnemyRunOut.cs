using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunOut : MonoBehaviour
{
   // GameController gameController;

    public float speed;
    Vector2 movement;
    Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        //gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        _rb = GetComponent<Rigidbody2D>();
        GenerateDir();
    }

    void GenerateDir()
    {
        movement = new Vector2(Random.Range(transform.position.x - 10, transform.position.x + 10), Random.Range(transform.position.y - 10, transform.position.y + 10));
        StartCoroutine(Rand());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movement, speed * Time.deltaTime);
    }

    IEnumerator Rand()
    {

        yield return new WaitForSeconds(Random.Range(3, 9));

        GenerateDir();
        StopCoroutine(Rand());
    }
}
