# Lost-In-QR-Code--Unity-Game=

![ezgif com-gif-maker](https://user-images.githubusercontent.com/84543584/198857459-6cdb77f8-689d-4ddc-a401-c483218d4f0f.gif)

This is a 2D game developed within 48 hours for DokuTech's game jam 2022 event with the theme "My Face Is Not A Barcode".Built with Unity, play as a character inside a QR Code maze with the goal of reaching the finish line without being detected by the cameras. Can you find your way out? 
 
Based on the description of the game the following architecture was obtained: 

![QRdiagram (2)](https://user-images.githubusercontent.com/84543584/199014879-465f32dc-f306-4dfb-a89e-1a6578283b1f.jpg)


## Camera zoom out 

When the game finishes, the camera starts zooming out and moving to the left side to show the play again button and the win/lose message. The camera movement on the left side was accomplished by using the line equation. Let the center point be the point which the camera needs to go to. We need to find the equation of the line of that goes through the center point and the current camera end point when the game ends. We will then change the position of the camera based on this line equation on every frame.

![3924e479-e567-4129-869b-73e042aaa1de__online-video-cutter_com__AdobeExpress](https://user-images.githubusercontent.com/84543584/198856787-6231eb54-6684-4739-8915-f5cb04f0a578.gif)


The slope of the line of the two points $CenterPoint(x_1,y_1), EndPoint(x_2,y_2)$ is 

$$ k = {{y_2-y_1} \over {x_2-x_1}} $$ 

Now that we have $k$, we find the equation of the line with slope k, through point $(x_1,y_1).$ Let $(x_1, y_1)$ of a point of the line $y=kx+l$. Then we have 

$$
\begin{cases} 
y=kx+l\\
y_1 = kx_1+l 
\end{cases}
$$

Subtracting these equations we have 

$$ y-y_1 = k(x-x_1) => y=k(x-x_1) +y_1 $$

We first set $x=x_2$ and decrement it for some value every frame and we update the $y$ value from the obtained line equation. We stop moving the camera when $x >x_1$.

In every frame we also increase the camera size. We stop incrementing the size the momement camera size is larger than the desired camera size. 
