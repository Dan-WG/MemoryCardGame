using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] Objs = GameObject.FindGameObjectsWithTag("Music");
        if (Objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}