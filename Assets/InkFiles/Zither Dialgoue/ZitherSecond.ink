->WhatWant

=== WhatWant ===
What do you want? #speaker:Zither #audio:Zither
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
    +[Where is the generator?]
        Its panel is behind me on that wall.
        ->WhatWant
    +[I see.]
    ->WhatWant
    
=== Goodbye ===
Farewell.
->END