using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//게시물 정보
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
    //요청타입(GET,POST,PUT,DELETE)
    public RequestType requestType;

    //Post Data
    public string postData;
    
    //응답이 왔을 때 호출해줄 함수 (Action)
    //Action : 함수를 넣을 수 있는 자료형
    public Action<DownloadHandler> onComplete;

    //반환자료형이 void이고 매개변수가 없는 함수를 넣을 수 있다.
    //Action<int>   -->  매개변수(여러개 가능)가 int인 함수를 넣을 수 있다.
  
}
