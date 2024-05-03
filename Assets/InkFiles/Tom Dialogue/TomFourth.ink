->WhatCanDo

=== WhatCanDo ===
What can I do for you little hero? #speaker:Blacksmith Tom #audio:Tom
    +[What was that train in the mines?]
        ->InTheMines
    +[Do you know anyone else with a Key?]
        ->KeyToGate
    +[What do you think is behind the gate?]
        ->BehindGate
    +[Goodbye]
        ->Goodbye
        
=== InTheMines ===
You saw a train down there? We used to have a train station below the city, but it was closed a while ago. 
The trains were left down there as far as I know.
Seems like one of them decided to come back for revenge.
I’m glad you weren’t hurt.
    ->WhatCanDo
    
=== KeyToGate ===
I had found another key, but I gave it to <b>Zither</b> from <b>The Power Plant</b> as thanks for fixing my hand.
    ->WhatCanDo
    
=== BehindGate ===
I have seen many interesting relics from beyond the wall come out of the mines.
I would love to see more of what behind it, but of course with only one <color=\#F8FF30>Key</color> that’s impossible.
    ->WhatCanDo
    
=== Goodbye ===
Goodbye then!
->END