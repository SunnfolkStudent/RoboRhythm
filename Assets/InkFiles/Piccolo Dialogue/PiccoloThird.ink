What a beautiful hat you have! #speaker:Piccolo #audio:Piccolo
Is there anything I can help you with?
    +[I'm looking for keys to the gate.]
    -> LookingForKeys
    +[I'm lost.]
    ->Lost
    +[Do you know what’s behind the gate?]
    ->BehindTheGate
    +[Goodbye.]
    ->Goodbye
    
    
=== AnythingElse ===
Is there anything else I can help you with?
+[I'm looking for keys to the gate.]
    -> LookingForKeys
    +[I'm lost.]
    ->Lost
    +[Do you know what’s behind the gate?]
    ->BehindTheGate
    +[Goodbye.]
    ->Goodbye
    
=== LookingForKeys ===
I do happen to have one in my possession but it is part of my exclusive collection.

That hat of yours looks very nice, would you trade it for my <color=\#F8FF30>Key</color>?
    +[Yes]
        Wonderful! #hatoff:true #donetalking:Piccolo
        Pleasure doing business! #key:Piccolo
    -> AnythingElse2
        +[No thank you.]
            Let me know if you change your mind.
    -> AnythingElse
    
=== Lost ===
What are you looking for?
    + [The Mines]
        <b>The Mines</b> are right down the stairs and to the left!
        ->AnythingElse
    +[The Power Plant]
        <b>The Power Plant</b> is down the stairs and to the right!
        ->AnythingElse
    +[The Gate]
        <b>The Gate</b> is just behind me!
        ->AnythingElse
    +[Nevermind.]
        ->AnythingElse
        
=== BehindTheGate ===
There are many theories and rumors on why the gate has been locked up.

Some say there is a terrible beast on the other side, waiting for it to open again.

Others say the land beyond is inhospitable and had to be closed for safety.

I think if there is anything beyond the gate, it’s long dead.

It’s been more than a hundred years, what could survive that long?

    ->AnythingElse
    
    
=== AnythingElse2 ===
Is there anything else I can help you with?
    +[I'm lost.]
    ->Lost2
    +[Do you know what’s behind the gate?]
    ->BehindTheGate2
    +[Goodbye.]
    ->Goodbye
    
    === Lost2 ===
What are you looking for?
    + [The Mines]
        <b>The Mines</b> are right down the stairs and to the left!
        ->AnythingElse2
    +[The Power Plant]
        <b>The Power Plant</b> is down the stairs and to the right!
        ->AnythingElse2
    +[The Gate]
        <b>The Gate</b> is just behind me!
        ->AnythingElse2
    +[Nevermind.]
        ->AnythingElse2
        
=== BehindTheGate2 ===
There are many theories and rumors on why the gate has been locked up.

Some say there is a terrible beast on the other side, waiting for it to open again.

Others say the land beyond is inhospitable and had to be closed for safety.

I think if there is anything beyond the gate, it’s long dead.

It’s been more than a hundred years, what could survive that long?

    ->AnythingElse2
    
=== Goodbye ===
Come back anytime!
->END