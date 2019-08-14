using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shrinker : MonoBehaviour
{
    public float currentShrinkSpeed = 0f;
    public float MinShrinkSpeed = 2f;
    public float MaxShrinkSpeed = 3f;
    public Rigidbody2D rb;
    public float ShrinkAcceleration = 10f;
    float timeInc = 0;

    private void Start()
    {
        rb.rotation = Random.Range(0, 360);
        transform.localScale = Vector3.one * 10f;
        currentShrinkSpeed = MinShrinkSpeed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        currentShrinkSpeed = Mathf.SmoothStep(MinShrinkSpeed, MaxShrinkSpeed, timeInc / ShrinkAcceleration);
        Debug.Log("current " + Time.time + "delta" +Time.fixedDeltaTime);
        transform.localScale -= Vector3.one * currentShrinkSpeed * Time.fixedDeltaTime;

        if (transform.localScale.x <= 0.5f)
        {
            Destroy(gameObject);
            ScoreManager.IncreaseScore();
        }
        timeInc += Time.fixedDeltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("cool", other);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
