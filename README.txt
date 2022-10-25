LineBender - VR Puzzle Game Project
Team Members: Alex Burnley and Timon Hume

Unity Version: 2021.3.9f1

Other Install Notes: None

The Project Goal:
The goal for our project is to take the core gameplay from our VR project and recreate it in AR as a small separate experience. This experience has the player sit down at a table and move fiducials around to complete a laser puzzle. Each fiducial has a reflective cube parented to it, which are used to reflect a laser to hit a number of spherical targets. Once all the targets are lit up the puzzle has been completed. In order to create this experience, we set up a laptop with a webcam above our scene. We chose to use Vuforia to track fiducials for this project because we did not have access to mobile devices that we could build and run project on. We then placed printed out fiducial markers on the table in front of the computer. We used 4 markers to place the reflective cubes and one marker to place the beginning of the laser puzzle. We learner that by having the player chose where the beginning of the puzzle is located, we were able to create a dynamic scene that could fit many different workspace environments. 

AR Interaction:
While we were creating our AR scene we found that it was difficult to line up our reflective cubes with the rest of the puzzle. Even though everything was laid out on a flat table in front of our AR camera there was still enough variation in the transformations of our virtual elements to make them not be able to reflect the laser reliably. To solve this and create a more intuitive experience we decided to simplify our interactivity to only a number of axises by limiting the location and rotation input from our image targets so that our cubes were always at one height and rotate around one axis. 
 
Challenge Focus:
We overcame a number of challenges when setting up our AR project. It was difficult to set up the digital content to fit on the table in front of the player, and reliably track it when it was sitting on the table. This challenge was overcome by changing the scale of our objects that we parented to our fiducials, and by lighting up our AR workspace. We ended up making the puzzle much smaller than it would be in VR so that it would fit on the table. And because it was sometimes difficult for Unity to recognize our fiducials, we made sure our AR workspace was well lit. Another challenge we faced was the orientation of our computer’s webcam. In order to track the fiducial we needed the camera to view them from above. We were able to overcome this challenge by propping up the computer to view the scene from above. While this was not an ideal solution, it was one of the best methods we found when we attempted different tracking methods. 
