using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーンの切り替えに使用するライブラリ(メモ)

public class MouseFollow : MonoBehaviour
{
    [System.Serializable]
    public class Bounds
    {
        public float xMin, xMax, yMin, yMax;
    }
    [SerializeField] Bounds bounds;

    [SerializeField, Range(0f, 1f)] private float followStrength;

    public AudioClip sound1;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlaneScript.moving)
        {
            // マウス位置をスクリーン座標からワールド座標に変換する
            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // X, Y座標の範囲を制限する
            targetPos.x = Mathf.Clamp(targetPos.x, bounds.xMin, bounds.xMax);
            targetPos.y = Mathf.Clamp(targetPos.y, bounds.yMin, bounds.yMax);

            // Z座標を修正する
            targetPos.z = 0f;

            transform.position = Vector3.Lerp(transform.position, targetPos, followStrength);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Plane"))
        {
            StartCoroutine(Wait());
            //other.gameObject.SetActive(false);
            //SceneManager.LoadScene("Result", LoadSceneMode.Single);
        }
    }

    IEnumerator Wait()
    {
        PlaneScript.moving = false;
        audioSource.PlayOneShot(sound1);
        //Debug.Break();

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Result", LoadSceneMode.Single);
    }
}
