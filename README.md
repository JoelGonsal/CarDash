# CarDash - 3D Unity Driving & Collision Simulator

## Author Information
* **Author:** Joel Gonsalves
* **Program:** Master of Computer Applications (MCA)
* **Course:** IVR & AR (Interactive Virtual Reality & Augmented Reality)
* **Instructor:** Dr. Siddhesh Tirodkar

## 1. Project Overview
This project is a 3D driving simulation developed in Unity that demonstrates core game object manipulation, physics, materials, and C# scripting. The player controls a sports car navigating a track, where collisions with boundary walls (acting as the game's "enemies") reduce the player's health. The simulation culminates in the player's destruction upon reaching zero health.

## 2. Asset Integration & Environment Configuration
The project leverages several customized asset packages to build a cohesive and interactive environment:

*   **Player (Car):** Sourced from the Low Poly Vehicle Pack Lite. The 3D model was imported into the scene and configured as the central playable character. The vehicle's hierarchy was structured to separate the root physics object from the visual mesh.
*   **Track & Environment:** Sourced from Modular LowPoly Track Roads Free. The track pieces were laid out to create a drivable circuit. Crucially, the floor pieces were left Untagged to allow safe driving, while the red-and-white edge blocks and fences were assigned a custom Barrier tag to designate them as the enemy hazards.
*   **Sky & Lighting:** The scene background was transitioned from a solid color to a realistic environment by changing the Main Camera's Background Type to Skybox. The Default-Skybox material was assigned in the Lighting settings to provide natural sunlight and horizon visuals.
*   **Explosion Effects:** Sourced from the Unity Particle Pack (specifically the FireBall prefab). This particle system is stored as a reference in the player script and is instantiated dynamically at the player's exact coordinates the moment the vehicle is destroyed.

## 3. Core Mechanics & Scripting
*   **Physics & Constraints:** The player vehicle utilizes a Rigidbody configured with a high mass and custom linear damping to simulate heavy vehicle friction. Rotational constraints (Freeze X and Z) ensure the car remains upright during sharp turns or collisions. A custom physics material with zero bounciness prevents violent ricochets.
*   **Health & UI Management (`PlayerController.cs`):** A custom script tracks a 100-point health pool. Collisions with Barrier-tagged objects reduce health by 10 points per hit. This math is visually represented through a 10-heart UI grid that dynamically updates (hiding red fills to reveal empty backgrounds) upon taking damage.
*   **Dynamic Chase Camera (`CameraFollows.cs`):** A custom third-person camera script utilizes `Vector3.Lerp` for smooth positional tracking and `Quaternion.Slerp` for smooth rotational panning. The logic executes in `LateUpdate()` to completely eliminate screen jitter, and includes a null-check failsafe to prevent game crashes when the player vehicle is destroyed.

## 4. How to Run the Project
1. Clone this repository to your local machine.
2. Open the project folder using Unity Hub (configured for Unity 6 / Universal Render Pipeline).
3. In the Project window, navigate to `Assets/Scenes` and open the `A023_Joel` scene.
4. Press the **Play** button at the top of the Unity Editor.
5. Use **W/A/S/D** or the **Arrow Keys** to accelerate, brake, and steer.
