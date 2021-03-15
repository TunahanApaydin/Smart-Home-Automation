# Make-life-easier
Hello to you developer.
This project may help you if you want to make some kind of home automation system.
I used the arduino development card to the control all sensors and i used the C# to design user interface.
The communication system is UART from C# to Arduino or for the opposite.
Everything is not perfect in this project but you can take inspiration from my codes.
Advices:
1- I used 6V DC motor for modelling the ventilation system but i recommend you to use 9-12V DC motor.(6V DC motor was not productive for this project)
2- I used some kind of serial port interrupt algorithm for data transfer between arduino and C#. If you understand the algorithm well, you can optimize your codes and increase the speed of data transfer.
3- I recommend that you use an industrial battery to feed the system. If you want to use a regular battary, you may have to connect several batteries in parallel because their power is not good enough. 
Note: I used the L293B motor driver for the DC motors.
Note 2: You should determine the components of the system according to your project, so you should not try to stick to the products I use.
Note 3: Earlier in the project, I created the project to test the motion sensor. Then, when I made rapid progress, I built everything on that project. That's why the name of the project files remained 'motion sensor control'.
Have a nice coding day :)

Youtube video link: https://youtu.be/bYDCL9sZxlk
