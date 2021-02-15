using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Butt;

public class CoreTest : MonoSingleton<CoreTest>
{

    [SerializeField]
    private RunnableTest runnableTest;

    [SerializeField]
    private bool testEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        CreateInstance();
        FlagAsPersistant();

        RunnableUtils.Setup(ref runnableTest, gameObject, "Sally", new Vector3(1, 1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        runnableTest.enabled = testEnabled;
        RunnableUtils.Run(ref runnableTest, gameObject);
    }
}
