using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DataUpdater : MonoBehaviour
{
    public InputField field; // Assign in the Inspector for Temperature display
    public InputField Hum; // Assign in the Inspector for Humidity display
    public float updateInterval = 5f; // Update every 5 seconds

    void Start()
    {
        // Start the update loop
        StartCoroutine(UpdateDataLoop());
    }

    IEnumerator UpdateDataLoop()
    {
        while (true)
        {
            // Start both data fetching coroutines
            StartCoroutine(GetData_Coroutine1());
            StartCoroutine(GetData_Coroutine());

            // Wait for the specified interval before updating again
            yield return new WaitForSeconds(updateInterval);
        }
    }

    IEnumerator GetData_Coroutine1()
    {
        Debug.Log("Getting Temperature Data");
        field.text = "Loading...";
        string uri1 = "https://blr1.blynk.cloud/external/api/get?token=6rozQsy6pP-3kGT0ZlREV2KExBTuUp0L&dataStreamId=2";

        using (UnityWebRequest request = UnityWebRequest.Get(uri1))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                field.text = request.error;
            else
            {
                field.text = request.downloadHandler.text;
                field.text = field.text.Substring(2, 2);
                Debug.Log("Temperature: " + field.text);
            }
        }
    }

    IEnumerator GetData_Coroutine()
    {
        Debug.Log("Getting Humidity Data");
        Hum.text = "Loading...";
        string uri1 = "https://blr1.blynk.cloud/external/api/get?token=6rozQsy6pP-3kGT0ZlREV2KExBTuUp0L&dataStreamId=1";

        using (UnityWebRequest request = UnityWebRequest.Get(uri1))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                Hum.text = request.error;
            else
            {
                Hum.text = request.downloadHandler.text;
                Hum.text = Hum.text.Substring(2, 2);
                Debug.Log("Humidity: " + Hum.text);
            }
        }
    }
}
