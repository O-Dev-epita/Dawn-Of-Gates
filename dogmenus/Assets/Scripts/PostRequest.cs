using System.Net;
using System.Text;
using System.IO;

using UnityEngine;

public class PostRequest {


	private string data;
	private HttpWebRequest req;
	private HttpWebResponse res;

	public PostRequest(string url)
	{
		
		req = (HttpWebRequest) WebRequest.Create(url);
		res = null;
		req.Method = "POST";
		req.ContentType = "application/x-www-form-urlencoded";
		data = "";	
	}
	
	public void addData(string key, string value)
	{
		if(data == "")
		{
			data = key + "=" + value;
		}
		else
		{
			data += "&" + key + "=" + value;
		}
	}
	
	public bool send()
	{
		
		try
		{
		
			byte[] body = Encoding.ASCII.GetBytes(data);
			req.ContentLength = body.Length;
		
			using(Stream stream = req.GetRequestStream())
			{
				stream.Write(body, 0, body.Length);
			}
		
			res = (HttpWebResponse) req.GetResponse();
			return true;
		}
		catch
		{
			return false;
		}
	
	}
	
	public string getResponseBody()
	{
		return new StreamReader(res.GetResponseStream()).ReadToEnd();
	}
}