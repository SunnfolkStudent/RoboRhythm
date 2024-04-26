->WhatCanDo

=== WhatCanDo ===
What can I do for you? #speaker:Mayor Bell
    +[Do you have a key to the gate?]
        ->HaveAKey
    +[What's this about Sky Pirates?]
        ->SkyPirates
    +[Goodbye]
        ->Goodbye
        
=== HaveAKey ===
When I took the hat of mayor I was also given the key passed down to all mayors. 
I’ve been tasked with keeping it safe from those who wish harm.
    ->WhatCanDo
    
=== SkyPirates ===
Those nasty pirates have been messing with <b>Hazy City’s Zeppelin Transport</b> again! 
We’ve chased them off before but they always come back stronger!
    +[Where is the Zeppelin Transport Area?]
        Just past me is the platform.
        ->WhatCanDo
    +[What Happened to The Sheriff?]
        Our poor Sheriff is on bedrest after an attack from those hooligans! Now there’s no one to stand up against them.
        ->WhatCanDo
    +[I see.]
    ->WhatCanDo
    
=== Goodbye ===
Stay safe, it’s a dangerous world out there!
->END
