using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissableAfterTime : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DisableAfterLifeTime");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DisableAfterLifeTime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
        yield return null;
    }
}
