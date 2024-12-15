# AR with IoT

## Overview
**AR-with-IoT** is an innovative project that combines Augmented Reality (AR) and Internet of Things (IoT) to provide an immersive interface for interacting with IoT devices. The repository includes projects like a **DHT-11 sensor value UI** and **Remote Relay-Control**, demonstrating the seamless integration of IoT sensors and AR interfaces.

## Features
- **DHT-11 Sensor Value UI**: Displays temperature and humidity data from the DHT-11 sensor in a user-friendly AR interface.
- **Remote Relay Control**: Enables remote control of a relay using IoT commands integrated with AR.
- Real-time IoT data visualization in AR environments.
- Modular design for adding new IoT sensors and AR components.

## Requirements
- **Unity Engine** (tested with version 2021 or later)
- IoT devices (e.g., DHT-11, relay module)
- ESP8266/ESP32 microcontroller
- Arduino IDE (for microcontroller programming)

## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/arulx06/AR-with-IoT.git
   ```
2. Open the Unity project in the Unity Engine.
3. Configure your IoT devices with the provided Arduino sketches.
4. Deploy the Unity application to a compatible AR device or emulator.

## Usage
### DHT-11 Sensor Value UI
1. Set up the DHT-11 sensor with an ESP8266/ESP32 microcontroller.
2. Upload the corresponding Arduino sketch from the repository to the microcontroller.
3. Launch the Unity app and view the sensor data in AR.

### Remote Relay Control
1. Connect a relay module to an ESP8266/ESP32 microcontroller.
2. Upload the provided sketch to enable IoT control.
3. Use the AR interface to toggle the relay state remotely.

## Contributing
Contributions are welcome! If you have ideas for additional features or improvements, feel free to:
- Fork the repository
- Create a new branch
- Submit a pull request

Please ensure your code adheres to the repository's coding standards and includes detailed comments.

## Future Work
- Adding support for more IoT sensors and devices.
- Enhancing the AR interface with 3D models and animations.
- Exploring machine learning for predictive IoT data visualization.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Acknowledgments
Special thanks to contributors and the open-source community for providing tools and libraries that made this project possible.

---
For more details or to report issues, please visit the [GitHub repository](https://github.com/arulx06/AR-with-IoT).

