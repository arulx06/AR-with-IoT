#define BLYNK_PRINT Serial  // Enable serial debugging for Blynk messages

/* Fill-in your Template ID and Template Name (only required when using Blynk.Cloud) */
#define BLYNK_TEMPLATE_ID "TMPL3AJ3Fz-Hl"  // Template ID for your Blynk project
#define BLYNK_TEMPLATE_NAME "ledblink"    // Template Name for your Blynk project

// Include required libraries
#include <WiFi.h>                // WiFi library for ESP32
#include <WiFiClient.h>          // WiFi client library
#include <BlynkSimpleEsp32.h>    // Blynk library for ESP32

#define relay 4  // Define the GPIO pin connected to the relay

// Blynk Auth Token (Get this from the Blynk app after creating your project)
char auth[] = "YourAuthToken"; 

// WiFi credentials (Replace with your network's SSID and password)
char ssid[] = "YourNetworkName";  // WiFi network name
char pass[] = "YourPassword";     // WiFi password

// This function is triggered when a value is sent from the Blynk app to Virtual Pin V0
BLYNK_WRITE(V0)
{
  int pinValue = param.asInt();  // Get the value sent from the app (0 or 1)
  digitalWrite(relay, pinValue); // Set the relay state based on the received value
  // If pinValue is 1, the relay turns ON; if 0, the relay turns OFF
}

void setup()
{
  // Start serial communication for debugging purposes
  Serial.begin(9600);

  // Set relay pin as an output
  pinMode(relay, OUTPUT);

  // Initialize Blynk with the provided Auth Token and WiFi credentials
  Blynk.begin(auth, ssid, pass);

  // Print a message to indicate setup is complete
  Serial.println("Setup Complete. Waiting for Blynk commands...");
}

void loop()
{
  // Run the Blynk library to handle communication with the server
  Blynk.run();
}
