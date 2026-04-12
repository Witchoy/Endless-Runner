using System.Collections;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] segments;

    [SerializeField] private int zPos;
    [SerializeField] private bool creatingSegment = false;
    [SerializeField] private int segmentNum;
    

    private void Update()
    {
        if (!creatingSegment)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }
    
    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, segments.Length);
        Instantiate(segments[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
        
        zPos += 44;
        yield return new WaitForSeconds(5f);
        creatingSegment = false;
    }

}
