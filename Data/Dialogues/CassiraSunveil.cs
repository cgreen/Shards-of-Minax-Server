<?xml version="1.0" encoding="utf-8"?>
<DialogueFile npc="CassiraSunveil">

  <!-- Greeting / Intro -->
  <Dialogue id="greeting">
    <NPCText>
      <![CDATA[
      <BASEFONT COLOR='#f4e4a6'>
      A dazzling woman in a feathered hat strums her gilded harp atop a cask, laughter and rumor swirling around her.<BR><BR>
      “Ah! A new ear for old tales? I am Cassira Sunveil—bard of Sunreach, rumor-monger for coin and cause, and sometimes, just sometimes, the voice of truth in a city that prefers lies.<BR><BR>
      What brings you to my stage: music, secrets, or perhaps... opportunity?”
      </BASEFONT>
      ]]>
    </NPCText>
    <Option text="Do you know of any work for a wandering soul?" next="questIntro"/>
    <Option text="You seem to know everyone. Who are your friends in Sunreach?" next="connections"/>
    <Option text="Tell me about Sunreach’s intrigues." next="sunreachLore"/>
	<Option text="Who are you really, Cassira Sunveil?" next="backstoryIntro"/>
    <Option text="Just listening for now." next="dismiss"/>
  </Dialogue>

  <!-- Connections branch -->
  <Dialogue id="connections">
    <NPCText>
      <![CDATA[
      Cassira’s eyes glint mischievously.<BR><BR>
      “My coin flows from Hassan’s scholarly coffers, but my whispers reach Darius Veynar and the Ashveil Corsairs too. In Sunreach, loyalty is measured by songs unsung—and secrets unshared.<BR>
      Sometimes, the right ballad opens more doors than a master thief.” 
      ]]>
    </NPCText>
    <Option text="Anyone you don’t trust?" next="rivals"/>
    <Option text="I want to hear about your rivals in Qasaria." next="qasariaRival"/>
    <Option text="Back to business—any work?" next="questIntro"/>
  </Dialogue>

  <!-- Rival branch -->
  <Dialogue id="rivals">
    <NPCText>
      <![CDATA[
      She leans close, lowering her voice.<BR><BR>
      “Trust is in short supply. Magistrate Thornwall fears a clever song more than any blade, and Qasaria’s bards have longer knives than most.<BR>
      But my true rival is Zafir the Sand-Tongue—a charmer in Qasaria with sticky fingers and a sharper tongue than any serpent. He stole my prized songbook. Without it, I’m just another minstrel. With it, I move the city.”
      ]]>
    </NPCText>
    <Option text="Tell me about Zafir and this stolen songbook." next="qasariaRival"/>
    <Option text="Is there a way to get it back?" next="questIntro"/>
    <Option text="That sounds dangerous. I’ll pass." action="Close"/>
  </Dialogue>

  <Dialogue id="qasariaRival">
    <NPCText>
      <![CDATA[
      “Zafir plucks his harp in Qasaria’s moonlit courts, wooing merchant-princes and gathering secrets like pearls. My songbook—a slim crimson volume—vanished from my rooms the night he performed here.<BR>
      The pages hold more than lyrics: codes, contacts, perhaps the odd scandal or three.<BR>
      Bring it back, and you’ll have a friend in every tavern, and a secret to trade with any power in Sunreach.”
      ]]>
    </NPCText>
    <Option text="How do I find him in Qasaria?" next="howToFind"/>
    <Option text="I’ll recover your songbook." next="acceptQuest"/>
    <Option text="This sounds risky. Nevermind." action="Close"/>
  </Dialogue>

  <!-- Sunreach Lore -->
  <Dialogue id="sunreachLore">
    <NPCText>
      <![CDATA[
      “Sunreach is a song of shifting loyalties—pirates trading silk with merchants, magisters bribing thieves, and every secret worth a king’s ransom.<BR>
      But every city has its heart. Here, that’s the docks, where fortunes are made and lost by sunset.<BR>
      Stay long enough, and you’ll hear your own name woven into my next ballad—be it praise, or warning.”
      ]]>
    </NPCText>
    <Option text="Any work for an ambitious stranger?" next="questIntro"/>
    <Option text="I prefer to stay out of trouble." action="Close"/>
  </Dialogue>

  <Dialogue id="dismiss">
    <NPCText>
      <![CDATA[
      Cassira flashes a dazzling smile. “The music never ends, friend. Should you tire of shadows, you’ll find me where stories gather and wine flows.”
      ]]>
    </NPCText>
    <Option text="On second thought, do you need a hand?" next="questIntro"/>
    <Option text="Farewell." action="Close"/>
  </Dialogue>

  <!-- Quest Offer -->
  <Dialogue id="questIntro">
    <NPCText>
      <![CDATA[
      Cassira plucks a melancholy chord, her voice dropping to a whisper.<BR><BR>
      “There’s work, if your heart’s steady and your hands steadier. My songbook—a collection of verses and, perhaps, a secret or two—was stolen by Zafir the Sand-Tongue, a rival bard in Qasaria.<BR><BR>
      Without it, I’m just another voice in the crowd. Bring it back to me, and I’ll sing your name in every corner of Sunreach—and slip you a tale or two the Council would pay dearly for.<BR><BR>
      So, will you chase a song through the desert for me?”
      ]]>
    </NPCText>
    <Option text="I accept. How do I find this Zafir?" next="howToFind"/>
    <Option text="Why is this songbook so important?" next="whyImportant"/>
    <Option text="This sounds like too much trouble." action="Close"/>
  </Dialogue>

  <!-- How to find Zafir / Qasaria tip -->
  <Dialogue id="howToFind">
    <NPCText>
      <![CDATA[
      “You’ll find Zafir in Qasaria’s Sapphire Pavilion—he’s never far from a crowd. He favors blue and gold, with a peacock feather in his turban, and travels with hired blades.<BR>
      Charm him, best him in a contest, or slip in when the crowd’s thickest. The songbook is in a lacquered box by his side.<BR>
      Return it—whole and unspoiled—and Sunreach’s secrets are yours to spend.”
      ]]>
    </NPCText>
    <Option text="I’ll bring your songbook home." action="GiveItem:FactionDeliveryQuestScroll(Songbook,Qasaria,250)" next="accept"/>
    <Option text="Anything I should know about Qasaria?" next="qasariaLore"/>
    <Option text="Let me think it over." action="Close"/>
  </Dialogue>

  <!-- Why Important -->
  <Dialogue id="whyImportant">
    <NPCText>
      <![CDATA[
      “Every bard keeps secrets, friend—but mine are written in cipher, wrapped in melody, and bartered for lives. Some songs change hearts. Others topple thrones.<BR>
      That little crimson book is the only leverage I have in Sunreach. If Zafir cracks it, more than my pride is lost.”
      ]]>
    </NPCText>
    <Option text="I’ll retrieve it, you have my word." next="howToFind"/>
    <Option text="You’re a dangerous friend to make, Cassira." next="acceptQuest"/>
    <Option text="Perhaps another time." action="Close"/>
  </Dialogue>

  <!-- Accept quest, end chain -->
  <Dialogue id="acceptQuest">
    <NPCText>
      <![CDATA[
      Cassira clasps your hand, pressing a coin into your palm.<BR><BR>
      “Luck favors the bold—and the bard who pays for results. Return with my songbook, and I’ll show you what real secrets sound like.”
      ]]>
    </NPCText>
    <Option text="I’ll be back soon—with your songbook." action="GiveItem:FactionDeliveryQuestScroll(Songbook,Qasaria,250)" next="accept"/>
    <Option text="On second thought, I’m not your hero." action="Close"/>
  </Dialogue>

  <Dialogue id="accept">
    <NPCText>
      <![CDATA[
      “The melody awaits. Trust no one in Qasaria—and keep an eye out for peacock feathers. When you return, seek me by the firelight or wherever the council’s spies are thickest.”
      ]]>
    </NPCText>
    <Option text="Until then, Cassira." action="Close"/>
  </Dialogue>

  <!-- Qasaria Lore branch -->
  <Dialogue id="qasariaLore">
    <NPCText>
      <![CDATA[
      “Qasaria is a jewel wrapped in sand and intrigue—merchant-princes hoard magic like water, and every bard is a spy in another’s employ.<BR>
      Keep your wits sharp. In the Sapphire Pavilion, a smile can be a challenge, and a song, a duel.”
      ]]>
    </NPCText>
    <Option text="I’ll remember that. I’m off to find your rival." next="howToFind"/>
    <Option text="I need to prepare first." action="Close"/>
  </Dialogue>

<!-- Backstory Intro -->
<Dialogue id="backstoryIntro">
  <NPCText>
    <![CDATA[
    Cassira’s fingers still upon her harp, her smile faltering for the briefest moment.<BR><BR>
    “Who am I? A fair question… but the answer depends: Do you want the tale I tell the crowds, or the one I sing only to moonlight and ghosts?”
    ]]>
  </NPCText>
  <Option text="Tell me the tale for the crowds." next="publicTale"/>
  <Option text="I’d rather hear what the ghosts hear." next="trueTale"/>
  <Option text="Perhaps another time." action="Close"/>
</Dialogue>

<!-- Public Tale -->
<Dialogue id="publicTale">
  <NPCText>
    <![CDATA[
    She flourishes her harp and strums a jaunty tune. <BASEFONT COLOR='#ffcc99'>(You hear a soft lute trill.)</BASEFONT><BR><BR>
    “Born to a wine-merchant in the hills, raised among caravan songs and courtesan tales. I played my first harp at thirteen and stole my first heart before fifteen. I’ve performed in Trinsic’s palaces and Buccaneer’s hovels alike.”<BR><BR>
    She winks. “And I’ve never once paid for a drink I couldn’t charm my way out of.”
    ]]>
  </NPCText>
  <Option text="You must have admirers everywhere." next="admirers"/>
  <Option text="That sounds rehearsed. What’s the real story?" next="trueTale"/>
  <Option text="Farewell, songbird." action="PlaySound:0x015" /> <!-- lute strum -->
</Dialogue>

<!-- Real (Private) Tale -->
<Dialogue id="trueTale">
  <NPCText>
    <![CDATA[
    Cassira’s tone quiets, her gaze turning distant.<BR><BR>
    “I was born in chains, friend. My mother sang in Qasaria’s courts as a servant—her voice bought her freedom but not mine. I learned songs not from tutors, but from listening outside silk-curtained chambers, humming lullabies to keep the guards from hearing me cry.<BR><BR>
    When I escaped, I carried three things: a stolen harp, a broken promise, and a name I would make mean something.”<BR>
    She smiles sadly. “Sunveil... it’s not the name I was born with. It’s the name I earned.”
    ]]>
  </NPCText>
  <Option text="You earned more than a name." action="Fame:+250" condition="KarmaAtLeast:0" next="gratitude"/>
  <Option text="A fine tale. Perhaps too fine to be true." next="doubtResponse"/>
  <Option text="That explains your fire." next="passions"/>
</Dialogue>

<!-- If player expresses trust/respect -->
<Dialogue id="gratitude">
  <NPCText>
    <![CDATA[
    “You surprise me,” she says, genuinely moved.<BR><BR>
    “Most hear a sob story and wait for the punchline. You listened. That’s rare—and dangerous. The kind of rare that wins songs, or knives in the dark.”<BR>
    She chuckles. “Let’s hope I give you the first.”
    ]]>
  </NPCText>
  <Option text="So what keeps you going?" next="passions"/>
  <Option text="I still want to know more." next="secrets"/>
  <Option text="Back to business. Any work?" next="questIntro"/>
</Dialogue>

<!-- If player doubts -->
<Dialogue id="doubtResponse">
  <NPCText>
    <![CDATA[
    She raises an eyebrow. “All stories are lies wrapped in truth. Or the other way around.”<BR><BR>
    “But doubt me if you must. Just know this—every verse I sing, I bled for. That’s more than most court minstrels can claim.”
    ]]>
  </NPCText>
  <Option text="Fair enough. What drives you now?" next="passions"/>
  <Option text="Let’s talk about your secrets." next="secrets"/>
  <Option text="I want to help you reclaim what you lost." next="questIntro"/>
</Dialogue>

<!-- Interests and Drives -->
<Dialogue id="passions">
  <NPCText>
    <![CDATA[
    Cassira lifts her harp again but doesn’t play. “I chase moments. A gasp in the crowd, a tear in a soldier’s eye, a secret traded for a lullaby. I want to make people *feel*. Whether it’s joy, guilt, or fire in their belly.”<BR><BR>
    “And maybe, just maybe... I’ll leave behind a verse the world won’t forget.”
    ]]>
  </NPCText>
  <Option text="You’ve already earned that much." condition="FameAtLeast:500" action="Karma:+100" next="secrets"/>
  <Option text="What secret verse hides behind your smile?" next="secrets"/>
  <Option text="You have work for someone like me?" next="questIntro"/>
</Dialogue>

<!-- Secrets & Subtle Flirtation -->
<Dialogue id="secrets">
  <NPCText>
    <![CDATA[
    She leans in, voice low, words laced with song.<BR><BR>
    “Every verse I write is a key... and every performance a lock I’ve yet to pick. Some doors open to love, some to betrayal. And some to things darker still.”<BR><BR>
    “Careful, dear one. Linger near me too long, and you might become a story all your own.”
    ]]>
  </NPCText>
  <Option text="I don’t mind becoming your next ballad." condition="IsMale" action="SendMessage:She smiles, just for you." next="questIntro"/>
  <Option text="I’d rather write my own ending." next="questIntro"/>
  <Option text="I’ll take my leave for now." action="Close"/>
</Dialogue>

<!-- Admirers Joke Option -->
<Dialogue id="admirers">
  <NPCText>
    <![CDATA[
    “Admirers?” She grins.<BR><BR>
    “More like victims of charm and verse. Some left poems, some left scars. All left stories—and I remember every one.”<BR>
    She sighs dramatically. “But not one of them returned my crimson songbook when it was stolen.” 
    ]]>
  </NPCText>
  <Option text="Let me be the exception." next="questIntro"/>
  <Option text="Your love life sounds exhausting." next="trueTale"/>
</Dialogue>


</DialogueFile>
