using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager _inst;
    private static Manager Inst {  get { Init(); return _inst; } }

    private DataMgr _data = new DataMgr();
    public static DataMgr Data { get { return Inst._data; } }

    private PageMgr _page = new PageMgr();
    public static PageMgr Page { get { return Inst._page; } }



    private void Start()
    {
        Init();
    }

    public static void Init()
    {
        if (_inst != null)
            return;

        GameObject go = GameObject.Find("Manager");
        if (go == null)//없다면
        {
            go = new GameObject { name = "Manager" };
            go.AddComponent<Manager>();
        }
        _inst = go.GetComponent<Manager>();

        Page.Init(PageMgr.PageType.Month);
        Data.Init();
    }

    //private float lastEscape = 0f;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F1))
    //        Quit();

    //    if (Application.platform != RuntimePlatform.Android)
    //        return;

    //    if (Input.GetKeyDown(KeyCode.Home))
    //        Quit();
    //    else if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        if (lastEscape + 0.5f < Time.time)
    //        {
    //            lastEscape = Time.time;
    //            return;
    //        }

    //        Quit();
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Menu))
    //        Data.SavePrefab();
    //}

    //private void Quit()
    //{
    //    Debug.Log("어플 종료");
    //    Data.SavePrefab();
    //    Application.Quit();
    //}


}
