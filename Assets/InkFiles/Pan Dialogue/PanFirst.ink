Do you want to buy a hat? #speaker:??? #audio:Pan

Everyone in town wants a hat from Pan!

They are the greatest hats you can find in Hazy City! #speaker:Mad Hatter Pan
    ->WhatCan

=== WhatCan ===
What can Pan do for you?
    +[Can I have a hat?]
        ->HaveHat
    +[Do you have a key to the gate?]
        ->HaveKey
    +[What do you think is behind the gate?]
        ->BehindGate
    +[Goodbye.]
        ->Goodbye
        
=== HaveHat ===
Your head has good shape!
Pan can think of a few hats that would be perfect!
But sadly Pan is busy with hat orders right now.
Too busy even to fix <b>ordering system</b>!
    +[Where is your ordering system?]
        Right next to my shop's door!
            ->WhatCan
    +[I see.]
    ->WhatCan
    
=== HaveKey ===
Unless the keys are also hats, Pan does not have one.
    ->WhatCan
    
=== BehindGate ===
Pan doesn’t know.
Maybe a giant hat?
    ->WhatCan
    
=== Goodbye ===
Bye!
    ->END