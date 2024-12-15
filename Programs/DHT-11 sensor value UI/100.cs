using System.Collections;            // Required for handling coroutines
using System.Collections.Generic;    // Provides generic collections like List, Dictionary
using UnityEngine;                   // Unity's core namespace
using UnityEngine.Networking;        // Provides tools for HTTP networking

// Class to handle URL interactions
public class ClickUrl : MonoBehaviour
{
    // URL to be accessed, can be set in the Unity Inspector
    public string url;

    // Public method that can be called (e.g., by a button) to start the URL request
    public void open()
    {
        // Starts a coroutine to make the HTTP GET request
        StartCoroutine(GetRequest(url));
    }
 
    // Coroutine for sending an HTTP GET request to the provided URL
    IEnumerator GetRequest(string uri)
    {
        // `using` ensures the UnityWebRequest is disposed of properly after use
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Sends the request and waits for the response (asynchronous operation)
            yield return webRequest.SendWebRequest();

            // Check if there's an error in the request
            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                // Log the error message to the console
                Debug.LogError($"Error: {webRequest.error}");
            }
            else
            {
                // Log the response to the console (useful for debugging)
                Debug.Log($"Response: {webRequest.downloadHandler.text}");
            }
        }
    }
}
