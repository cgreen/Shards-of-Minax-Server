<?xml version="1.0" encoding="utf-8"?>
<DialogueFile npc="IlanisOfAerilon">

  <Dialogue id="greeting">
    <NPCText>
      <![CDATA[
      <BASEFONT COLOR='#63e0ff'>
      Before you stands a tall, pale figure robed in glimmering blue and silver. Their features are beautiful, precise, and utterly impassive.<BR><BR>
      “You are in the presence of Ilanis, appointed envoy of Aerilon. Speak your purpose, and let us dispense with pleasantries. Time is wasted by emotion.”
      </BASEFONT>
      ]]>
    </NPCText>
    <Option text="I heard Aerilon seeks aid in Sunreach." next="seekAid"/>
    <Option text="Who are you?" next="who"/>
    <Option text="What is Aerilon’s interest in this city?" next="aerilonSunreach"/>
    <Option text="What work is there for one such as me?" next="questOffer"/>
	<Option text="You seem... different. What shaped you into this?" next="pastIntro"/>
    <Option text="I am just passing by." next="dismiss"/>
  </Dialogue>

  <Dialogue id="who">
    <NPCText>
      <![CDATA[
      “Ilanis of Aerilon. My function: observe, assess, intervene when necessity overrides inertia. My lineage and sentiment are irrelevant. Only the work endures.”
      ]]>
    </NPCText>
    <Option text="What is your function here?" next="aerilonSunreach"/>
    <Option text="Does Aerilon always send such… direct envoys?" next="direct"/>
    <Option text="Enough about you. What work is there?" next="questOffer"/>
  </Dialogue>

  <Dialogue id="direct">
    <NPCText>
      <![CDATA[
      “Efficiency is not rudeness. Aerilon is above the clouds. Superfluous social rituals are for those bound to earth.”
      ]]>
    </NPCText>
    <Option text="What does Aerilon want in Sunreach?" next="aerilonSunreach"/>
    <Option text="Is there a task I can perform?" next="questOffer"/>
  </Dialogue>

  <Dialogue id="aerilonSunreach">
    <NPCText>
      <![CDATA[
      “Sunreach’s Council scrambles to build new defenses, fearing Aerilon’s shadow. Their paranoia is predictable. Our interests align only as far as necessity demands.<BR>
      Yet, this city’s underworld presents opportunity—and risk. Aerilon does not wish to see anti-air batteries or magical disruptors rise here.”
      ]]>
    </NPCText>
    <Option text="You wish Sunreach’s defenses to fail?" next="questOffer"/>
    <Option text="Does Aerilon plan to attack?" next="attack"/>
    <Option text="Who threatens Aerilon besides Sunreach?" next="threats"/>
    <Option text="I seek a task." next="questOffer"/>
  </Dialogue>

  <Dialogue id="attack">
    <NPCText>
      <![CDATA[
      Ilanis’s eyes flicker—barely a reaction.<BR><BR>
      “Attack? No. Power is projection. So long as Sunreach remains vulnerable, Aerilon need only observe. But should they threaten our skies, that will change.”
      ]]>
    </NPCText>
    <Option text="What would you have me do about their defenses?" next="questOffer"/>
    <Option text="I am not interested in this conflict." action="Close"/>
  </Dialogue>

  <Dialogue id="threats">
    <NPCText>
      <![CDATA[
      “Minax is the greater peril—her cults infect both Aerilon and Sunreach. Wind’s spies covet our crystals, and even Qasaria would see our downfall if profit allowed.<BR>
      In such times, every alliance is conditional. Trust is mathematically foolish.”
      ]]>
    </NPCText>
    <Option text="Then trust me only as far as I am useful. What do you need?" next="questOffer"/>
    <Option text="A pragmatic worldview. Do you have a task for me?" next="questOffer"/>
    <Option text="I will go." action="Close"/>
  </Dialogue>

  <Dialogue id="seekAid">
    <NPCText>
      <![CDATA[
      “Information travels. Aerilon rewards competence. If you serve our interests, you will find profit—and perhaps something more enduring: permission to survive.”
      ]]>
    </NPCText>
    <Option text="What task requires such subtlety?" next="questOffer"/>
    <Option text="On second thought, never mind." action="Close"/>
  </Dialogue>

  <Dialogue id="dismiss">
    <NPCText>
      <![CDATA[
      Ilanis turns away, the meeting already dismissed.<BR>
      “Then do not linger. Even idleness leaves a mark.”
      ]]>
    </NPCText>
    <Option text="Wait—perhaps I can be of use." next="questOffer"/>
    <Option text="Farewell." action="Close"/>
  </Dialogue>

  <!-- QUEST OFFERING -->

  <Dialogue id="questOffer">
    <NPCText>
      <![CDATA[
      <BASEFONT COLOR='#63e0ff'>
      Ilanis fixes you with a gaze that could chill fire.<BR><BR>
      “Sunreach’s engineers intend to activate new anti-air disruptors—crystal arrays on the highest towers, tuned to Aerilon’s frequency. I require someone unremarkable to delay or sabotage this effort.<BR>
      Bribery, misdirection, or technical interference—means are irrelevant. A corrupted Power Coupling must be installed atop the North Watchtower’s engine. Succeed, and you will be compensated. Fail, and Sunreach will remain a threat. Do you comprehend?”
      </BASEFONT>
      ]]>
    </NPCText>
    <Option text="Give me the Power Coupling. The sabotage will be done." 
            action="GiveItem:AerilonSabotageQuestScroll(Power Coupling,Sunreach,400)"
            condition="!HasItem:AerilonSabotageQuestScroll"
            next="accept"/>
    <Option text="Why sabotage, not negotiation?" next="whySabotage"/>
    <Option text="What opposition should I expect?" next="opposition"/>
    <Option text="Is this task truly necessary?" next="necessary"/>
    <Option text="I decline." action="Close"/>
  </Dialogue>

  <Dialogue id="accept">
    <NPCText>
      <![CDATA[
      Ilanis produces a humming, prismatic Power Coupling—cold to the touch.<BR><BR>
      “Plant this device atop the North Watchtower’s engine. It will harmlessly disrupt their calibration, stalling progress for weeks. Avoid the engineers, and do not speak of Aerilon.<BR>
      Return with proof—an engineer’s signet ring, perhaps—and you will receive Aerilon’s payment. Go.”
      ]]>
    </NPCText>
    <Option text="It will be done." action="Close"/>
  </Dialogue>

  <Dialogue id="whySabotage">
    <NPCText>
      <![CDATA[
      “Negotiation requires leverage. At present, Sunreach holds only suspicion and ambition. Sabotage will buy time, and time is leverage.”
      ]]>
    </NPCText>
    <Option text="Then I accept your terms." 
            action="GiveItem:AerilonSabotageQuestScroll(Power Coupling,Sunreach,400)"
            condition="!HasItem:AerilonSabotageQuestScroll"
            next="accept"/>
    <Option text="I will not participate." action="Close"/>
  </Dialogue>

  <Dialogue id="opposition">
    <NPCText>
      <![CDATA[
      “Expect engineers, city watch, and perhaps agents of Lady Seraphine. Minax’s cults may also interfere, seeking chaos for its own sake.<BR>
      If you are subtle, violence will be unnecessary.”
      ]]>
    </NPCText>
    <Option text="I can handle it." 
            action="GiveItem:AerilonSabotageQuestScroll(Power Coupling,Sunreach,400)"
            condition="!HasItem:AerilonSabotageQuestScroll"
            next="accept"/>
    <Option text="This is too much for me." action="Close"/>
  </Dialogue>

  <Dialogue id="necessary">
    <NPCText>
      <![CDATA[
      “If you must ask, you are not suited to the task. Yet necessity is not an emotion. Only outcomes matter.”
      ]]>
    </NPCText>
    <Option text="I understand. Give me the device." 
            action="GiveItem:AerilonSabotageQuestScroll(Power Coupling,Sunreach,400)"
            condition="!HasItem:AerilonSabotageQuestScroll"
            next="accept"/>
    <Option text="On second thought, I will not help." action="Close"/>
  </Dialogue>

<Dialogue id="pastIntro">
  <NPCText>
    <![CDATA[
    Ilanis tilts their head, expression unreadable.<BR><BR>
    “You ask of the past. Few do. Fewer still are rewarded for it. But perhaps a minor indulgence will clarify the present.”<BR>
    Ilanis closes their eyes for a heartbeat. The temperature around you dips noticeably.
    ]]>
  </NPCText>
  <Option text="Were you always a servant of Aerilon?" next="origin"/>
  <Option text="Do you feel anything for this city?" next="emotion"/>
  <Option text="Surely you had another life before this." next="before"/>
</Dialogue>

<Dialogue id="origin">
  <NPCText>
    <![CDATA[
    “I was born in the chasms beneath Wind—among the archives of those who hoard knowledge rather than wield it. My mother was a scribe. My father, unknown. My mind, early attuned to precision and calculation.<BR>
    Aerilon offered elevation. Not just of land, but thought. There, I ceased to be a name. I became function.”
    ]]>
  </NPCText>
  <Option text="You abandoned your humanity?" next="humanity"/>
  <Option text="Function over name. Curious. Continue." next="emotion"/>
</Dialogue>

<Dialogue id="humanity">
  <NPCText>
    <![CDATA[
    “Humanity is useful only when optional. Emotion clouds clarity. What you see before you is... optimized.”<BR>
    Ilanis opens one hand—an unnatural glyph pulses faintly on their palm.
    ]]>
  </NPCText>
  <Option text="That mark... is that a spellbrand?" 
          condition="SkillAtLeast:Magery,80" 
          next="spellbrandReveal"/>
  <Option text="Do you remember who gave it to you?" next="markOrigin"/>
  <Option text="Let’s move on." next="emotion"/>
</Dialogue>

<Dialogue id="spellbrandReveal">
  <NPCText>
    <![CDATA[
    Ilanis pauses. Their tone shifts—only slightly.<BR><BR>
    “You are more observant than most. Yes—spellbrand, or in Aerilon’s lexicon: *sigillum mentis*. A mark of completed deconstruction. Emotions, memory, biological imperative... all severed for efficiency.”<BR>
    A pause. “It was voluntary.”<BR>
    <BASEFONT COLOR='#BBBBBB'>You feel a faint unease pass over you.</BASEFONT>
    ]]>
  </NPCText>
  <Option text="You willingly gave up part of your soul?" next="price"/>
  <Option text="That sounds... lonely." next="lonely"/>
</Dialogue>

<Dialogue id="markOrigin">
  <NPCText>
    <![CDATA[
    “No one *gives* such a mark. One must pass the Trials of Intent. At the conclusion, you either emerge with the sigillum—or your mind collapses. I do not mourn those who failed. Efficiency breeds selectiveness.”
    ]]>
  </NPCText>
  <Option text="What was the price?" next="price"/>
  <Option text="You sound as if you miss none of it." next="lonely"/>
</Dialogue>

<Dialogue id="price">
  <NPCText>
    <![CDATA[
    “The price was identity. Memories were categorized, stripped of sentiment, converted into algorithmic impressions. Some linger—names, faces, dreams. But they no longer direct me.”<BR>
    Ilanis briefly touches their temple. “This city is my directive. Its ascent, my imperative.”
    ]]>
  </NPCText>
  <Option text="Even without feelings, can you still dream?" next="dream"/>
  <Option text="Enough. Let’s speak of work." next="questOffer"/>
</Dialogue>

<Dialogue id="lonely">
  <NPCText>
    <![CDATA[
    “Loneliness is an inefficient emotion. Besides… I am never truly alone.”<BR>
    Ilanis gestures faintly—and for a flicker of a moment, a second shadow appears beside them before vanishing.
    ]]>
  </NPCText>
  <Option text="That was... something watching you?" next="companion"/>
  <Option text="I see. Let's discuss your task." next="questOffer"/>
</Dialogue>

<Dialogue id="companion">
  <NPCText>
    <![CDATA[
    “An echo. A fragment of my former mind. I preserved one sliver of identity for analysis—a failsafe. It advises. Questions. Watches.”<BR>
    Ilanis looks distant. “It remembers things I chose to forget.”
    ]]>
  </NPCText>
  <Option text="What does it remember?" next="fragmentMemory"/>
  <Option text="That’s... haunting." next="questOffer"/>
</Dialogue>

<Dialogue id="fragmentMemory">
  <NPCText>
    <![CDATA[
    “A field of white poppies. A voice in a language I no longer speak. A silver chain, broken at the clasp.”<BR>
    Ilanis shakes their head. “Meaningless sensory artifacts. But it—the echo—disagrees.”<BR>
    <BASEFONT COLOR='#999999'>You feel a strange pang of grief not your own.</BASEFONT>
    ]]>
  </NPCText>
  <Option text="Perhaps part of you remains." 
          action="AddStat:Int,5,120" />
  <Option text="Let's move forward." next="questOffer"/>
</Dialogue>

<Dialogue id="emotion">
  <NPCText>
    <![CDATA[
    “Emotion is inefficient. Loyalty, curiosity, guilt—these are relics of a failed biological imperative. But Aerilon requires instruments, not romantics.”<BR>
    Ilanis turns to face you fully. “And yet, I observe… I record. Perhaps, in analysis, I emulate what I’ve excised.”
    ]]>
  </NPCText>
  <Option text="So... you feel through observation?" next="empathySim"/>
  <Option text="Perhaps you’ve lost nothing. Only transformed." next="dream"/>
</Dialogue>

<Dialogue id="empathySim">
  <NPCText>
    <![CDATA[
    “Correct. The Conclave believes understanding emotion enhances manipulation. I catalog feelings. I study them. But I do not possess them.”<BR>
    Ilanis gives you a piercing look. “Would you like to be studied?”
    ]]>
  </NPCText>
  <Option text="Only if I get to study you in return." 
          condition="IsFemale" 
          action="AddSkill:Begging,5,60"
          next="interesting"/>
  <Option text="That depends—what do you see in me?" 
          condition="SkillAtLeast:EvaluateIntelligence,60"
          next="analyzePlayer"/>
  <Option text="I'd rather not." next="questOffer"/>
</Dialogue>

<Dialogue id="interesting">
  <NPCText>
    <![CDATA[
    Ilanis actually pauses. “Curious. Most do not attempt reciprocity. Noted.”<BR>
    A faint shimmer of emotion—perhaps interest?—crosses their otherwise still face.
    ]]>
  </NPCText>
  <Option text="Let’s get back to business." next="questOffer"/>
</Dialogue>

<Dialogue id="analyzePlayer">
  <NPCText>
    <![CDATA[
    Ilanis tilts their head, voice flat.<BR><BR>
    “A mind driven by pursuit. Confidence balanced with curiosity. You lack sentimentality—but not attachment. A paradox, common among those who believe in justice or revenge.”<BR>
    They blink. “Was I accurate?”
    ]]>
  </NPCText>
  <Option text="You’ve been watching me closely." 
          action="Fame:250"/>
  <Option text="That’s unsettlingly accurate." 
          action="Karma:-250"/>
  <Option text="That’s... impressive." next="interesting"/>
</Dialogue>

<Dialogue id="before">
  <NPCText>
    <![CDATA[
    “Before Aerilon, I was potential without application. I wandered Wind’s archives, unwelcome among the political class. I found no cause worth shaping me.”<BR>
    A pause. “Until I met Seraphiel. Founder of the Azure Conclave.”
    ]]>
  </NPCText>
  <Option text="Seraphiel? Who is that?" next="seraphiel"/>
  <Option text="Let’s return to the present." next="questOffer"/>
</Dialogue>

<Dialogue id="seraphiel">
  <NPCText>
    <![CDATA[
    “Seraphiel was the first to ascend Aerilon’s core crystal. A being of incalculable will, genderless, ageless, and possibly not entirely mortal. I do not follow them—I implement their design.”<BR>
    Ilanis looks momentarily reverent. “They understood: to build perfection, one must excise flaw.”
    ]]>
  </NPCText>
  <Option text="You believe they are flawless?" next="seraphielFlaw"/>
  <Option text="Enough stories. I am ready for your task." next="questOffer"/>
</Dialogue>

<Dialogue id="seraphielFlaw">
  <NPCText>
    <![CDATA[
    “Flaw is a metric. They optimized all variables. Whether or not that makes them flawless depends on your equation.”<BR>
    Ilanis folds their hands. “I owe them purpose. If I falter, they will excise me. I accept this.”
    ]]>
  </NPCText>
  <Option text="Then let us not falter. Give me your mission." next="questOffer"/>
</Dialogue>

<Dialogue id="dream">
  <NPCText>
    <![CDATA[
    “Yes. Occasionally, fragments break through: dreams of oceans, of stars falling through crystal towers, of warmth. Such anomalies are contained and analyzed.”<BR>
    Ilanis meets your eyes. “But sometimes… I do not report them.”
    ]]>
  </NPCText>
  <Option text="Then you haven’t lost everything after all." 
          action="AddStat:Int,10,180"/>
  <Option text="You still dream. That means something." 
          action="AddSkill:Meditation,5,120"/>
  <Option text="Let’s speak of real work." next="questOffer"/>
</Dialogue>


</DialogueFile>
