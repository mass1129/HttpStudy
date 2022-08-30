using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HttpMgr : MonoBehaviour
{
    public static HttpMgr instance;
    private void Awake()
    {
        //만약에 instance가 null이라면
        if (instance == null)
        {   
            //instance에 나를 넣겠다
            instance = this;
            //나를 파괴되지 않게 하겠다.
            DontDestroyOnLoad(gameObject);
        }
        //그렇지 않으면
        else
        {   
            //나를 파괴하겠다.
            Destroy(gameObject);
        }

    }

    //서버에게 요청
    //응답이 올때까지 기다려야 하기 때문에 코루틴 사용해야함
    //url(posts/1), GET,
    public void SendRequest(HttpRequester requester)
    {
        StartCoroutine(Send(requester));
    }

    IEnumerator Send(HttpRequester requester)
    {
        UnityWebRequest webRequest = null;
        //requestType에 따라서 호출해줘야한다.
        switch(requester.requestType)
        {
            case RequestType.POST:
                webRequest = UnityWebRequest.Post(requester.url, requester.postData);
                break;
            case RequestType.GET:
                webRequest = UnityWebRequest.Get(requester.url);
                break;
            case RequestType.PUT:
                webRequest = UnityWebRequest.Put(requester.url, requester.postData);
                break;
            case RequestType.DELETE:
                webRequest = UnityWebRequest.Delete(requester.url);
                break;
        }
        //서버에 요청을 보내고 응답이 올때까지 기다린다.
        yield return webRequest.SendWebRequest();
        //만약 응답이 성공했다면 result에 값이 담김
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            print(webRequest.downloadHandler.text);


            
            //완료되었다고 requester.onComplete를 실행
            requester.onComplete(webRequest.downloadHandler);

        }

        //그렇지않다면
        else
        {
            //서버통신 실패
            print("통신 실패"+webRequest.result + "\n" + webRequest.error);
        }
            yield return null;

    }


}
