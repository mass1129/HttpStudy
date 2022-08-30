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
        //������ �Խù� ��ȸ ��û(/posts/1,GET)
        //HttpRequester�� ����
        HttpRequester requester = new HttpRequester();

        // /posts/1, GET �Ϸ�Ǿ��� �� ȣ��Ǵ� �Լ�
        requester.url = "https://jsonplaceholder.typicode.com/posts/1";
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteGetPost;
        
        //HttpManager���� ��û
        HttpMgr.instance.SendRequest(requester);

    }

    public void OnCompleteGetPost(DownloadHandler downHdr)
    {
        PostData postData = JsonUtility.FromJson<PostData>(downHdr.text);
        //Ÿ��Ʋ  UI�� ���
       
        print("��ȸ�Ϸ�");


    }
    public void OnClickGetAllPost()
    {
        //������ �Խù� ��ȸ ��û(/posts/1,GET)
        //HttpRequester�� ����
        HttpRequester requester = new HttpRequester();

        // /posts/1, GET �Ϸ�Ǿ��� �� ȣ��Ǵ� �Լ�
        requester.url = "https://jsonplaceholder.typicode.com/posts";
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteGetAllPost;

        //HttpManager���� ��û
        HttpMgr.instance.SendRequest(requester);

    }
    public void OnCompleteGetAllPost(DownloadHandler downHdr)
    {
        //�迭 �����͸� Ű���� �ִ´�.
        string s = "{\"data\":" + downHdr.text + "}";
        //List<PostData>
        PostDataArray array = JsonUtility.FromJson<PostDataArray>(s);
        for(int i = 0; i<array.data.Count; i++)
        {
            print(array.data[i].id+"\n"+ array.data[i].title + "\n"+ array.data[i].body);
            
        }
        print("��ȸ�Ϸ�");


    }

    public void OnClickGetAllComments()
    {
        //������ �Խù� ��ȸ ��û(/posts/1,GET)
        //HttpRequester�� ����
        HttpRequester requester = new HttpRequester();

        // /posts/1, GET �Ϸ�Ǿ��� �� ȣ��Ǵ� �Լ�
        requester.url = "https://jsonplaceholder.typicode.com/comments";
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteGetAllComments;

        //HttpManager���� ��û
        HttpMgr.instance.SendRequest(requester);

    }
    public void OnCompleteGetAllComments(DownloadHandler downHdr)
    {
        //�迭 �����͸� Ű���� �ִ´�.
        string s = "{\"data\":" + downHdr.text + "}";
        //List<PostData>
        CommentsDataArray array = JsonUtility.FromJson<CommentsDataArray>(s);
        for (int i = 0; i < array.data.Count; i++)
        {
            print(array.data[i].id + "\n" + array.data[i].name + "\n" + array.data[i].email + "\n" + array.data[i].body);

        }
        print("��ȸ�Ϸ�");


    }

    public void OnClickSignIn()
    {
        //������ �Խù� ��ȸ ��û(/posts/1,GET)
        //HttpRequester�� ����
        HttpRequester requester = new HttpRequester();

        // /user, Post �Ϸ�Ǿ��� �� ȣ��Ǵ� �Լ�
        requester.url = "https://jsonplaceholder.typicode.com/user";
        requester.requestType = RequestType.POST;

        //post data ����
        UserData data = new UserData();
        data.name = "������";
        data.email = "dfdfd@efe.com";
        data.id = "mass413";
        data.age = 29;

        requester.postData = JsonUtility.ToJson(data,true);
        print(requester.postData);
        requester.onComplete = OnCompleteSignIn;

        //HttpManager���� ��û
        HttpMgr.instance.SendRequest(requester);

    }
    public void OnCompleteSignIn(DownloadHandler downHdr)
    {
        //�迭 �����͸� Ű���� �ִ´�.
        string s = "{\"data\":" + downHdr.text + "}";
        //List<PostData>
        PostDataArray array = JsonUtility.FromJson<PostDataArray>(s);
        for (int i = 0; i < array.data.Count; i++)
        {
            print(array.data[i].id + "\n" + array.data[i].title + "\n" + array.data[i].body);

        }
        print("��ȸ�Ϸ�");


    }

}
