using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CoroutineTester : MonoBehaviour
{
    [SerializeField] private Color destinationColor;
    [SerializeField] private float time;
    //[SerializeField] private Material mat;
    //[SerializeField] private Renderer renderer;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Volume volume;
    private ChromaticAberration chromaticAberration;

    private void Awake()
    {
        volume = GetComponent<Volume>();
        if (!volume.profile.TryGet(out chromaticAberration))
            Debug.LogError("Did not find a chromatic aberration in PostEffects");

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        float t = 0;
        while (t <= time)
        {
            t += Time.deltaTime;

            float eval = curve.Evaluate(t / time);

            chromaticAberration.intensity.value = eval;

            //renderer.material.SetColor("_BaseColor", Color.Lerp(Color.white, destinationColor, t / time));
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
