using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnotSizeInfluence : MonoBehaviour
{
    CinemachineSplineDolly  spline;
    CinemachineCamera activeCamera;
    [SerializeField] private List<float> OrthographicSize;
    private float activeKnot=0;
    private float activeSize;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spline = GetComponent<CinemachineSplineDolly>();
        activeCamera = GetComponent<CinemachineCamera>();
        activeKnot=0;
        activeSize=OrthographicSize[0];
        MoveTo(activeKnot);
    }

    public void MoveTo(float knot)
    {
        StopAllCoroutines();
        StartCoroutine(MoveCam(knot));
    }

    private IEnumerator MoveCam(float knot)
    {
        float tempKnot=activeKnot;
        float tempSize=activeSize;
        for (float i = 0; i < 1; i += Time.deltaTime/1.5f)
        {
            yield return null;
            spline.CameraPosition=Mathf.Lerp(tempKnot,knot,Mathf.Sin(Mathf.PI*i/2));
            activeCamera.Lens.OrthographicSize=Mathf.Lerp(tempSize,OrthographicSize[(int)knot],Mathf.Sin(Mathf.PI*i/2));
            activeSize=activeCamera.Lens.OrthographicSize;
            activeKnot=spline.CameraPosition;
        }
    }
    
}
