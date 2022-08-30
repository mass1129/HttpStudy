using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class UIMgr : MonoBehaviour
{


    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void OnClickGetPost()
    {
        //서버에 게시물 조회 요청(/posts/1,GET)
        //HttpRequester를 생성
        HttpRequester requester = new HttpRequester();

        // /posts/1, GET 완료되었을 때 호출되는 함수
        requester.url = "https://jsonplaceholder.typicode.com/posts/1";
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteGetPost;
        
        //HttpManager에게 요청
        HttpMgr.instance.SendRequest(requester);

    }

    public void OnCompleteGetPost(DownloadHandler downHdr)
    {
        PostData postData = JsonUtility.FromJson<PostData>(downHdr.text);
        //타이틀  UI에 출력
       
        print("조회완료");


    }
    public void OnClickGetAllPost()
    {
        //서버에 게시물 조회 요청(/posts/1,GET)
        //HttpRequester를 생성
        HttpRequester requester = new HttpRequester();

        // /posts/1, GET 완료되었을 때 호출되는 함수
        requester.url = "https://jsonplaceholder.typicode.com/posts";
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteGetAllPost;

        //HttpManager에게 요청
        HttpMgr.instance.SendRequest(requester);

    }
    public void OnCompleteGetAllPost(DownloadHandler downHdr)
    {
        //배열 데이터를 키값에 넣는다.
        string s = "{\"data\":" + downHdr.text + "}";
        //List<PostData>
        PostDataArray array = JsonUtility.FromJson<PostDataArray>(s);
        for(int i = 0; i<array.data.Count; i++)
        {
            print(array.data[i].id+"\n"+ array.data[i].title + "\n"+ array.data[i].body);
            
        }
        print("조회완료");


    }

    public void OnClickGetAllComments()
    {
        //서버에 게시물 조회 요청(/posts/1,GET)
        //HttpRequester를 생성
        HttpRequester requester = new HttpRequester();

        // /posts/1, GET 완료되었을 때 호출되는 함수
        requester.url = "https://jsonplaceholder.typicode.com/comments";
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteGetAllComments;

        //HttpManager에게 요청
        HttpMgr.instance.SendRequest(requester);

    }
    public void OnCompleteGetAllComments(DownloadHandler downHdr)
    {
        //배열 데이터를 키값에 넣는다.
        string s = "{\"data\":" + downHdr.text + "}";
        //List<PostData>
        CommentsDataArray array = JsonUtility.FromJson<CommentsDataArray>(s);
        for (int i = 0; i < array.data.Count; i++)
        {
            print(array.data[i].id + "\n" + array.data[i].name + "\n" + array.data[i].email + "\n" + array.data[i].body);

        }
        print("조회완료");


    }

    public void OnClickSignIn()
    {
        //서버에 게시물 조회 요청(/posts/1,GET)
        //HttpRequester를 생성
        HttpRequester requester = new HttpRequester();

        // /user, Post 완료되었을 때 호출되는 함수
        requester.url = "https://jsonplaceholder.typicode.com/user";
        requester.requestType = RequestType.POST;

        //post data 셋팅
        UserData data = new UserData();
        data.name = "김혜성";
        data.email = "dfdfd@efe.com";
        data.id = "mass413";
        data.age = 29;

        requester.postData = JsonUtility.ToJson(data,true);
        print(requester.postData);
        requester.onComplete = OnCompleteSignIn;

        //HttpManager에게 요청
        HttpMgr.instance.SendRequest(requester);

    }
    public void OnCompleteSignIn(DownloadHandler downHdr)
    {
        //배열 데이터를 키값에 넣는다.
        string s = "{\"data\":" + downHdr.text + "}";
        //List<PostData>
        PostDataArray array = JsonUtility.FromJson<PostDataArray>(s);
        for (int i = 0; i < array.data.Count; i++)
        {
            print(array.data[i].id + "\n" + array.data[i].title + "\n" + array.data[i].body);

        }
        print("조회완료");


    }

}
