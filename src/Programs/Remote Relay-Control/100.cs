using System.Collections;            // Required for handling coroutines
using System.Collections.Generic;    // Provides generic collections like List, Dictionary
using UnityEngine;                   // Unity's core namespace
using UnityEngine.Networking;        // Provides tools for HTTP networking

// Class to fetch DHT11 sensor values from a URL
public class DHT11Fetcher : MonoBehaviour
{
    // Base URL of the server hosting DHT11 sensor data, can be set in the Unity Inspector
    public string baseUrl = "http://your-sensor-url.com";  // Replace with your actual server URL

    // Public method to initiate the request for DHT11 data
    public void FetchSensorData()
    {
        // Starts a coroutine to make the HTTP GET request
        StartCoroutine(GetDHT11Data());
    }

    // Coroutine to send an HTTP GET request and handle DHT11 sensor data
    IEnumerator GetDHT11Data()
    {
        // Construct the full URL (e.g., baseUrl/dht11 for sensor endpoint)
        string uri = $"{baseUrl}/dht11";

        // Using ensures the UnityWebRequest is disposed of properly after use
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
                // Parse and log the response (assuming JSON format: {"temperature":25, "humidity":60})
                string responseText = webRequest.downloadHandler.text;
                Debug.Log($"Response: {responseText}");

                // Parse JSON response (requires UnityEngine.JsonUtility or custom parsing)
                DHT11Data sensorData = JsonUtility.FromJson<DHT11Data>(responseText);
                Debug.Log($"Temperature: {sensorData.temperature}°C");
                Debug.Log($"Humidity: {sensorData.humidity}%");
            }
        }
    }

    // Class to represent the JSON structure of DHT11 data
    [System.Serializable]
    public class DHT11Data
    {
        public float temperature; // Temperature in Celsius
        public float humidity;    // Humidity percentage
    }
}