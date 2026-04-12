using System.Collections;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] segments;

    private int _zPos;
    private bool _creatingSegment;
    private int _segmentNum;


    private void Update()
    {
        if (!_creatingSegment)
        {
            _creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    private IEnumerator SegmentGen()
    {
        _segmentNum = Random.Range(0, segments.Length);
        Instantiate(segments[_segmentNum], new Vector3(0, 0, _zPos), Quaternion.identity);

        _zPos += 44;
        yield return new WaitForSeconds(5f);
        _creatingSegment = false;
    }
}