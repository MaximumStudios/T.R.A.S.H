using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class KnotSizeInfluence : MonoBehaviour
{
    CinemachineSplineDolly  spline;
    CinemachineCamera activeCamera;
    [SerializeField] private List<float> OrthographicSize;
    private float activeKnot;
    private float activeSize;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spline = GetComponent<CinemachineSplineDolly>();
        activeCamera = GetComponent<CinemachineCamera>();
        activeKnot=0;
        activeSize=OrthographicSize[0];
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
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            yield return null;
            spline.CameraPosition=Mathf.Lerp(tempKnot,knot,i);
            activeCamera.Lens.OrthographicSize=Mathf.Lerp(tempSize,OrthographicSize[(int)knot],i);
            activeSize=activeCamera.Lens.OrthographicSize;
            activeKnot=spline.CameraPosition;
        }
    }
    
}
