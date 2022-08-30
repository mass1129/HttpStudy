using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//�Խù� ����
[Serializable]
public class PostData
{
    public int userId;
    public int id;
    public string title;
    public string body;

}
[Serializable]
public class CommentsData
{
    public int postId;
    public int id;
    public string name;
    public string email;
    public string body;

}


public class UserData
{
    public string name;
    public string id;
    public string email;
    public int age;

}



[Serializable]
public class PostDataArray
{
    public List<PostData> data;

}
[Serializable]
public class CommentsDataArray
{
    public List<CommentsData> data;

}
public enum RequestType
{
    POST,
    GET,
    PUT,
    DELETE
}


public class HttpRequester
{
    //url
    public string url;
    //��ûŸ��(GET,POST,PUT,DELETE)
    public RequestType requestType;

    //Post Data
    public string postData;
    
    //������ ���� �� ȣ������ �Լ� (Action)
    //Action : �Լ��� ���� �� �ִ� �ڷ���
    public Action<DownloadHandler> onComplete;

    //��ȯ�ڷ����� void�̰� �Ű������� ���� �Լ��� ���� �� �ִ�.
    //Action<int>   -->  �Ű�����(������ ����)�� int�� �Լ��� ���� �� �ִ�.
  
}
