LineBender - VR Puzzle Game Project
Team Members: Alex Burnley and Timon Hume

Unity Version: 2021.3.9f1

Other Install Notes: None


Milestone 3:
For our two travel techniques we used the XR toolkit to change between two difference sources of forward movement. We tried and implemented both look based travel and pointer based travel. For both we were able to use the joystick of the left controller to mover around on the floor of our room. 

Our wayfinding technique is an immersive path of cables on the floor of our room. Each cable leads the player to the next target in the puzzle. Upon activating a puzzle target the cable lights up towards the final goal that the player will eventually need to travel to in order to finish the game. 

Our selection / manipulation tech



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