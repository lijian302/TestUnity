using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadImageManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateScrollView();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateScrollView()
    {
        string[] paths = Directory.GetDirectories(Application.streamingAssetsPath);
        int count = paths.Length;
        float scrollViewWidth = Screen.width / count;
        for (int i = 0; i < count; i++)
        {
            GameObject prefab = Resources.Load<GameObject>("Scroll View");
            GameObject go = Instantiate(prefab, GameObject.Find("Canvas").transform);
            go.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollViewWidth, Screen.height);
            go.GetComponent<RectTransform>().localPosition = new Vector3(-Screen.width / 2 + scrollViewWidth / 2 + scrollViewWidth * i, 0, 0);

            CreateImage2(go.transform, paths[i], scrollViewWidth);
        }
    }

    private void CreateImage(Transform trans, string path, float scrollViewWidth)
    {
        string[] paths = Directory.GetDirectories(path);
        int count = paths.Length;
        float imageWidth = scrollViewWidth / 5;
        for (int i = 0; i < count; i++)
        {
            GameObject prefab = Resources.Load<GameObject>("RawImage");
            GameObject go = Instantiate(prefab, trans.Find("Viewport").Find("Content"));
            go.GetComponent<RectTransform>().sizeDelta = new Vector2(imageWidth, imageWidth);
            float imageX = imageWidth / 2 + imageWidth * (i % 5);
            float imageY = 0;
            if ((int)(i / 5) % 2 == 0)
            {
                if (i % 2 == 0)
                    imageY = -imageWidth / 2 - imageWidth * 1.5f * (int)(i / 5);
                else
                    imageY = -imageWidth / 2 - imageWidth * 1.5f * (int)(i / 5) - imageWidth * 0.75f;
            }
            else
            {
                if (i % 2 == 0)
                    imageY = -imageWidth / 2 - imageWidth * 1.5f * (int)(i / 5) - imageWidth * 0.75f;
                else
                    imageY = -imageWidth / 2 - imageWidth * 1.5f * (int)(i / 5);
            }
            go.GetComponent<RectTransform>().localPosition = new Vector3(imageX, imageY, 0);
        }
    }

    private void CreateImage2(Transform trans, string path, float scrollViewWidth)
    {
        string[] paths = Directory.GetDirectories(path);
        int count = paths.Length;
        float imageWidth = scrollViewWidth / 5;
        for (int i = 0; i < count; i++)
        {
            GameObject prefab = Resources.Load<GameObject>("RawImage");
            GameObject go = Instantiate(prefab, trans.Find("Viewport").Find("Content"));
            go.GetComponent<RectTransform>().sizeDelta = new Vector2(imageWidth, imageWidth);
            float imageX = 0;
            float imageY = 0;
            if (i % 5 < 3)
            {
                imageX = imageWidth / 2 + imageWidth * 2 * (i % 5);
                imageY = -imageWidth / 2 - imageWidth * 1.5f * (int)(i / 5);
            }
            else
            {
                imageX = imageWidth / 2 + imageWidth * 2 * (i % 5 - 3) + imageWidth;
                imageY = -imageWidth / 2 - imageWidth * 1.5f * (int)(i / 5) - imageWidth * 0.75f;
            }
            go.GetComponent<RectTransform>().localPosition = new Vector3(imageX, imageY, 0);
        }
    }
}
