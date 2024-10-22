using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class CoroutineMove : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private float speed;
    [SerializeField] private AnimationCurve curve;

    private void Awake()
    {
        // volume = GetComponent<Volume>();
        // if (!volume.profile.TryGet(out chromaticAberration))
        //     Debug.LogError("Did not find a chromatic aberration in PostEffects");

    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(MyCoroutine());
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(MyCoroutine());
        }
    }

    IEnumerator MyCoroutine()
    {
        float t = 0;
        Vector3 dest = transform.position;
        dest.y += speed;

        Vector3 start = transform.position;

        while (t <= time)
        {
            t += Time.deltaTime;

            float eval = curve.Evaluate(t / time);
            transform.position = Vector3.Lerp(start, dest, eval);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }
}
