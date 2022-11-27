LineBender - VR Puzzle Game Project
Team Members: Alex Burnley and Timon Hume

Unity Version: 2021.3.9f1

Other Install Notes: None


Milestone 3:
For our two travel techniques we used the XR toolkit to change between two difference sources of forward movement. We tried and implemented both look based travel and pointer based travel. For both we were able to use the joystick of the left controller to mover around on the floor of our room. 

Our wayfinding technique is an immersive path of cables on the floor of our room. Each cable leads the player to the next target in the puzzle. Upon activating a puzzle target the cable lights up towards the final goal that the player will eventually need to travel to in order to finish the game. 

Our selection / manipulation tech
The selection and manipulation technique we used was to make the user pick up items directly. With the horror/puzzle game that we are going for, we want the users to move around the scenes, and requiring them to pick items up directly encourages them to do so. To help the user manipulate the rotation of items in cases where precise rotation was necessary, we created a precision rotation tool, where the user can grab a glowing handle around the item. It tracks the users hand movement until they let go, but the objects position is locked and rotation is locked around a single axis.


Q and A User 1:

Q: How is the way finding system?
A: The cables are helpful. I like how they all light up when you power one target. It’s nice to know where the power is going. It is confusing where they are going to right now, but when you finish the door etc. the cables will be very nice.
Response: We will add a door / starting position, and lead the player to the first target that perhaps is already enabled in order to make the way finding very intuitive.

Q: How do you feel about the pointer based and look based navigation? Which do you prefer?
A: It’s nice to have navigation based on the pointer, because in this game you’re not always moving forward. Instead you’re moving around one space. You can look at the puzzle while moving to the side which is nice.
Response: We will take this response into account when deciding which navigation style to use in the final project.

Q: What do you think of the interaction system? 
A: The blocks are a little big, but you want them to be pretty big. I don’t like how your hand clips through the blocks when you pick them up. The main problem is that you don’t grab them on their outside, they instead transform their origin to your hand which is hard to manage. The rotation helper is very nice and smooth. 
Response: We will resize the unity assets or player so that they have better relative scales. We will also see if we can create a different transform for the blocks to move to in your hand when you pick them up. 

Q: Is there anything else that you would recommend us to work on?
A: I want snap turn instead of continuous maybe. It makes you less sick. Boxes that I place on the ground sometimes clip/fall through.
Response: We will try to fix the clipping problem, and we could enable snap turn for a future build.



User 2:
Q: How do you like look based movement?
A: I don't really like it, it's weird. I kept accidentally going in directions that I didn't want to because I looked at something else.

Q: How do you like pointer based movement?
A: I like it better than the other one. I liked being able to look around a bit as I moved, I didn't like having to stare where I wanted to go.
Reflection on Travel Mechanics: In a puzzle style game where it is important to allow the user to look around as they move. However, different users may prefer one over the other so it may be better to allow the user to switch between modes.

Q: How did you like the wayfinding system? (told that there will eventually be an unpowered exit door as the objective, which would be connected to the power cables)
A: I don't know. The power cables make it easy to see whats connected but I don't think I'd be able to guess that the laser needs to go through the targets.
Reflection: We need to implement a better way to tell the user where to go and what to do. As long as they understand that they need to power the door and that lasers can be used to power targets, the cables are useful for telling them where to look and what targets to power, but we need to get the user to that point where we can let them just follow the cables.

Q: How did you like the mechanics for picking things up?
A: I didn't like it. The blocks were too big and in my face, and I couldn't put them where I wanted to.
Reflection: With blocks that are so large, centering them on the user's hand when they are picked up makes them unwieldy. We need to make the user grab from the surface of the blocks.

Q: How did you like the Rotation Helper?
A: It was a little confusing at first but once I figured out how to use it, it made it a lot easier. I couldn't really place the block well so I needed to use it to aim the lasers.
Reflection: This does a good job of helping the user, but it is only as useful as it is because of the shortcomings of the grab mechanics.