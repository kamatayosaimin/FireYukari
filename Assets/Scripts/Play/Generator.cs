using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Generator : MonoBehaviour
{

    [System.Serializable]
    public class Data
    {
        [SerializeField] private int _range;
        [SerializeField] private FallObject _object;

        public int Range
        {
            get
            {
                return _range;
            }
        }

        public FallObject Object
        {
            get
            {
                return _object;
            }
        }
    }

    [SerializeField] private int _lowRange, _highRange;
    [SerializeField] private float _xRange, _changeSpan;
    private bool _isHigh;
    [SerializeField] private Data[] _datas;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeState());
    }

    void FixedUpdate()
    {
        int range = _isHigh ? _highRange : _lowRange;

        if (Random.Range(0, range) != 0)
            return;

        FallObject obj = GetObject();

        if (!obj)
            return;

        Instantiate(obj, GetPosition(), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }

    Vector3 GetPosition()
    {
        return transform.position + Vector3.right * Random.Range(-_xRange, _xRange);
    }

    FallObject GetObject()
    {
        int num = Random.Range(0, _datas.Sum(d => d.Range)),
            range = 0;

        foreach (var d in _datas)
        {
            range += d.Range;

            if (num < range)
                return d.Object;
        }

        return null;
    }

    IEnumerator ChangeState()
    {
        while (true)
        {
            yield return new WaitForSeconds(_changeSpan);

            _isHigh = !_isHigh;
        }
    }
}
