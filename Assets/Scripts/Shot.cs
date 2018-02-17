using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UniRx;

public class Shot: MonoBehaviour
{
    float timeout = 1;

    void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(timeout))
            .Subscribe(_ =>
        {
            Destroy(this.gameObject);
        }).AddTo(this);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * 5);
    }
}
