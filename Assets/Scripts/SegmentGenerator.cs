using System.Collections;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] segmentPrefabs;

    private int _nextSpawnZ;
    private int _lastSegmentIndex;
    private bool _isSpawning;

    private void Update()
    {
        if (!_isSpawning)
        {
            _isSpawning = true;
            StartCoroutine(SpawnNextSegment());
        }
    }

    private IEnumerator SpawnNextSegment()
    {
        _lastSegmentIndex = Random.Range(0, segmentPrefabs.Length);
        Instantiate(segmentPrefabs[_lastSegmentIndex], new Vector3(0, 0, _nextSpawnZ), Quaternion.identity);

        _nextSpawnZ += 44;
        yield return new WaitForSeconds(5f);
        _isSpawning = false;
    }
}