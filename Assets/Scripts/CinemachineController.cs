using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineController : MonoBehaviour
{
    public CinemachineVirtualCamera playerCamera, treasureCamera;

    private void Start()
    {
        StartCoroutine(Cutscene());
    }

    private IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(1.0f);
        treasureCamera.Priority = 15;
        yield return new WaitForSeconds(4.0f);
        treasureCamera.Priority = 9;
    }
}
