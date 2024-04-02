# Game Development Recap

The game features a single level, designed with a finite gameplay loop in mind. While my initial vision was to create an endless runner-style experience, time constraints guided me towards a more concise design. A death zone is situated at the very bottom of the level, and touching it with the player character triggers a level restart. Additionally, the 'Escape' key can be pressed to bring up a pause menu. I've embraced a minimalist approach throughout the design, positioning this project as a foundation for future expansion. The codebase is highly scalable, making it effortless to modify or introduce new platform types. As for the player character, it's represented simply as a square with animated eyes, brought to life using DOTween—a third-party asset I chose for its versatility and performance.

# Design Patterns & Architecture: 

State Pattern (Implemented for Player's behavior, platforms and effector)

Reason: The State Pattern is optimal for representing and managing changing states in an object. In gaming, it’s especially helpful for controlling different states of a character or entity such as jumping, running, standing, and more. 

Implementation: I’m used it to handle the varying behaviors of the player depending on the platform they interacted with. For instance, the Wind platform had a distinct influence on the player's movement compared to a normal platform. 

Observer pattern (For game events and interactions): 

Reason: This pattern offers a robust mechanism to allow various parts of a system to react to events. It helps in keeping the system modular and the components decoupled. 

Implementation: Applied it for collecting items, finishing levels, or interacting with UI components. The benefit was evident – any game component could simply "subscribe" to an event (like item collection) and respond when that event was "published".

Singleton pattern (For PlatformStateManager)

The PlatformStateManager is a centralized manager script for handling platform-related states.

Reason: To have a single point of access to platform states and handlers, ensuring consistency and avoiding multiple instances. 

Implementation: The script inherits from a Singleton base class, which provides the Singleton behavior.

# Interactions and Gameplay Elements

DOTween

Designed to guide players through the game mechanics. Made it interactive with the new input system, allowing players to activate it via a mouse click. Enhanced its presentation using DOTween animations for smoother transitions. 

Parallax Effect
Create a visually engaging background that enhances the depth and movement feeling in a 2D environment. Adopted an infinite horizontal parallax effect, giving the game a continuous and seamless environment, enhancing the player's immersion.

Moving Platforms

Add complexity and challenge to the gameplay. Implemented with DOTween for fluid movement between two set points, ensuring that the player could predict platform movement. 

Collectible Items

Generalized the item name to CollectibleItem for scalability – so it could be a gem today, a coin tomorrow, or anything else in the future. Enhanced its collection effect using DOTween animations for an engaging user experience.

# Player Movement on Moving Platforms

Challenge: The player didn't move along with the platform. 
Solution: Setting the player as a child of the platform temporarily when standing on it.

Scaling Animations and Interactions

Used DOTween extensively to ensure animations and interactive elements feel fluid and responsive. 

New Input System

Allowed for a more modern and flexible approach to input handling, especially catering to both keyboard and mouse-based interactions seamlessly. 

StringBuilder

Improved performance, especially when updating text on the screen frequently. StringBuilder is efficient as it avoids creating a new string object in memory on each modification. Used for updating in-game text elements, ensuring a smooth player experience without performance hitches. 

Cinemachine

Simplifies camera interactions, making it easier to achieve professional-quality camera work. Integrated Cinemachine for dynamic camera behavior, responding to player movement and ensuring the player remains the focus.

Pause & Exit Functionality
Incorporated a system to pause/resume gameplay, ensuring players cannot move or interact during the pause state for better game control.

Custom Debugging
 
For better development insights and troubleshooting. Using CustomDebug.Log(), this manager provides specialized debug outputs that can be color-coded and customized for clarity during development and testing phases.

Example 

CustomDebug.LogEditor(nameof(PlatformStateManager), $"WindAreaState {windArea.WindForce}", Color.green);

