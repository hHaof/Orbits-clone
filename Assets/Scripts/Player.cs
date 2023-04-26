using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform _rotateTransform;
    public float _startRadius;
    public float moveSpeed;
    public List<float> _rotateRadius;

    public float _moveTime;

    float currentRadius;
    int level;

    void Awake()
    {
        level = 0;
        currentRadius = _startRadius;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ChangeRadius());
        }
    }

    void FixedUpdate()
    {
        transform.localPosition = Vector3.up * currentRadius;
        float rotateValue = moveSpeed * Time.fixedDeltaTime;
        _rotateTransform.Rotate(0, 0, rotateValue);
    }

    IEnumerator ChangeRadius()
    {
        float moveStartRadius = _rotateRadius[level];
        float moveEndRadius = _rotateRadius[(level + 1) % _rotateRadius.Count];
        float moveOffset = moveEndRadius - moveStartRadius;
        float speed = 1 / _moveTime;
        float timeElapsed = 0f;
        while (timeElapsed < 1f)
        {
            timeElapsed += speed * Time.fixedDeltaTime;
            currentRadius = moveStartRadius + moveOffset * timeElapsed;
            yield return new WaitForFixedUpdate();
        }
        level = (level + 1) % _rotateRadius.Count;
        currentRadius = _rotateRadius[level];

    }


    public GamePlayManager _gm;
    public GameObject _explosionPrefab, _scoreParticlePrefab;
    public AudioClip _loseClip, _pointClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            SoundManager.Instance.PlaySound(_loseClip);
            _gm.GameEnded();
            return;
        }

        if(collision.CompareTag("Score"))
        {
            Destroy(Instantiate(_scoreParticlePrefab, transform.position, Quaternion.identity),1f);
            SoundManager.Instance.PlaySound(_pointClip);
            _gm.UpdateScore();
            collision.gameObject.GetComponent<Score>().ScoreAdded();
            return;
        }
    }
}
