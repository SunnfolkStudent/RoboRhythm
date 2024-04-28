->WhatWant

=== WhatWant ===
What do you want? #speaker:Zither
    +[Do you know where more keys are?]
        ->Looking
    +[Do you know what caused the power out?]
        ->Lights
    +[Do you know anything about what's beyond the gate?]
        ->Gate
    +[Goodbye]
        ->Goodbye
    
=== Looking ===
I would assume <b>The Mayor</b> has one.
    ->WhatWant
    
=== Lights ===
There have been a few outages recently, some caused by <b>The Pirates</b>, some by whatever has been happening in <b>The Mines</b>.
Some seem to be completely random.
Unfortunately, I don’t have time to fix the generators and find out where the problem is coming from.
    ->WhatWant
    
=== Gate ===
I haven’t given it much thought.
If it doesn’t effect my work here, than I don’t care.
    ->WhatWant
=== Goodbye ===
Farewell.
->END