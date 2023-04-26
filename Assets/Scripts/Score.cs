using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform _scorePoint;
    public List<float> _spawnLoc;

    void Awake()
    {
        transform.localPosition = Vector3.right * _spawnLoc[(Random.Range(0, _spawnLoc.Count))];
        _scorePoint.rotation = Quaternion.Euler(0, 0, Random.Range(20, 40) * 10f);
    }
    public void ScoreAdded()
    {
        Destroy(_scorePoint.gameObject);
    }
}
