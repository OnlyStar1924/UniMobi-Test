using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button btn20;
    public Button btn50;
    public Button btn100;

    public GameObject[] prefab;

    public TextMeshProUGUI fpsText;
    private float deltaTime;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        btn20.onClick.AddListener(() => Spawn(20));
        btn50.onClick.AddListener(() => Spawn(50));
        btn100.onClick.AddListener(() => Spawn(100));

        StartCoroutine(CountFps());

    }


    private void Spawn(int num)
    {
        for (int i = 0; i < num; i++)
        {
            StartCoroutine(WaitSpawn((i)*0.05f +Random.Range(0, 1)));
        }
    }

    IEnumerator CountFps()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString() + " FPS";
        yield return new WaitForSeconds(1f);
        StartCoroutine(CountFps());
    }

    IEnumerator WaitSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        int ran = Random.Range(0, 8);
        Instantiate(prefab[ran], transform.position, Quaternion.identity);

    }

}
