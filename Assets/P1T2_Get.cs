﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class P1T2_Get : MonoBehaviour {

	// Use this for initialization
	public WWW get;
	public static string getreq;
	Text text;

	void Start ()
	{
		//string url = "http://192.168.137.31:9000/api/comments";
		//get = new WWW(url);
		//StartCoroutine(GET());
		//getData();
		text = GetComponent <Text> ();
	}

	// Update is called once per frame
	void Update()
	{

		//StartCoroutine(GET());
		//getData();
		StartCoroutine(WaitForRequest());

	}

	private IEnumerator WaitForRequest()
	{
		float num = UnityEngine.Random.Range(-10.0f, 10.0f);
		string url = "http://10.42.0.1:9000/api/comments?t=" + num.ToString();
		//string url = "http://10.42.0.1:9000/api/comments";
		WWW get = new WWW(url);
		yield return get;        
		getreq = get.text;        
		//getreq = File.ReadAllText(@"\Data\data.json");
		//yield return getreq;
		//check for errors
		if (get.error == null)
		{
			//Debug.Log("Ohhh Yeahhh!-> " + get.text);
			//Debug.Log(getreq.ToString());
			Debug.Log("To be parsed: " + getreq.ToString());
			string json = @getreq;
			List<MyP1T2_Get> data = JsonConvert.DeserializeObject<List<MyP1T2_Get>>(json);
			int l = data.Count;
			Debug.Log("Latest Data: " + data[l - 1].content);
			text.text = "Data: " + data[l - 1].content.Split(',')[1];
		}
		else
		{
			Debug.Log("Dayumn!-> " + get.error);
		}

	}  

}

public class MyP1T2_Get
{
	public string _id;
	public string author;
	public string content;
	public string _v;
	public string date;
}
