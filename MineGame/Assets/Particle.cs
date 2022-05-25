using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    float timer = 0;
    float dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = Mathf.Sign(Random.Range(-1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > .5f)
            Destroy(gameObject);

        transform.position = new Vector2(transform.position.x, transform.position.y-(2000*Time.deltaTime));
        transform.Rotate(new Vector3(0, 0, 200 * dir * Time.deltaTime));
    }
}
