using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    //
    public GameObject EffectPre;
    //
    private Transform player;
    //
    public static int Count = 0;
    //
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        //
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        float dis = Vector3.Distance(transform.position,player.position);
        //
        if( dis < 1.5f )
        {
            Count++;
            //
            audioSource.PlayOneShot(Resources.Load<AudioClip>("UFO/UFO02"));
            //
            Debug.Log("获得金币，当前金币为：" + Count);
            if( Count >= 3 )
            {
                GameObject go = Instantiate(EffectPre,transform.position,transform.rotation);
                //
                Destroy(go,8f);
                Debug.Log("集齐金币，游戏结束");
            }
            //销毁该脚本
            Destroy(this);
            //销毁物体本身
            Destroy(gameObject,0.3f);
        }
    }
}
