Greetings. I am Zither. #speaker:??? #audio:Zither
I run The Power Plant here in <b>Haze City</b>. #speaker:Zither
I’m currently preoccupied with a power outage that took out the street lamps.
    ->WhatWant

=== WhatWant ===
What do you want?
    +[I'm looking for keys to the gate.]
        ->Looking
    +[What happened to the lights?]
        ->Lights
    +[Goodbye]
        ->Goodbye
    
=== Looking ===
Good for you.
    ->WhatWant
    
=== Lights ===
A surge in the wiring took out the generator used for the street lighting.
This wouldn’t be that strange if I hadn’t fixed that generator just last week.
    ->WhatWant
    
=== Goodbye ===
Farewell.
->END