using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iframescontroller : MonoBehaviour
{
    private HealthController _healthController;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
    }

    public void StartIframes(float IframeDuration)
    {
        StartCoroutine(IframesCoroutine(IframeDuration));
    }

    private IEnumerator IframesCoroutine(float IframeDuration)
    {
        _healthController.Iframes = true;
        yield return new WaitForSeconds(IframeDuration);
        _healthController.Iframes = false;
    }
}
