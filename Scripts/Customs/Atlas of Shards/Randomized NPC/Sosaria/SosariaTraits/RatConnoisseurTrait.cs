using Server.Mobiles;
using Server;
using Server.Items;

namespace Server.Regions.Sosaria.Traits
{
    public class RatConnoisseurTrait : SosariaSpeechTraitWithItem
    {
        public RatConnoisseurTrait() : base("Rat Connoisseur", 40)
        {
            // Step 1: "job" (entry point, leads to "rat" or "giant rat")
            Add("job",
                new[]{
                    "What do I do? I observe, study, and—regrettably—eradicate giant rats.",
                    "Some call me obsessed, others a rat-catcher. The truth? I am their foremost appreciator and greatest nemesis.",
                    "I track every whisker and tail of those wretched rodents. Ask me about rats, if you dare."
                });

            // Step 2: "rat" or "giant rat" (leads to "infestation")
            Add("rat",
                new[]{
                    "Ah, rats—ordinary ones are clever, but the giant kind? They’re an affront to decency and hygiene.",
                    "Giant rats are miracles of adaptation—and revolting gluttons. Their infestation is an art form.",
                    "No beast is as resilient, as resourceful, or as revolting. The giant variety, especially. Their infestations are legendary."
                });

            Add("giant rat",
                new[]{
                    "Giant rats are nature’s cruel joke. Big as dogs, and twice as hungry.",
                    "You haven’t known true horror until you’ve watched a giant rat gnaw through an iron chest for moldy cheese.",
                    "Some admire wolves or dragons. I study giant rats. Ask me about their infestation, if your stomach is strong."
                });

            // Step 3: "infestation" (leads to "cellar")
            Add("infestation",
                new[]{
                    "Infestations begin in the forgotten places—cellars, sewers, and neglected larders.",
                    "Where there’s shadow and staleness, rats multiply. But my cellar... my poor cellar...",
                    "You want to see an infestation? Visit my cellar. Bring a torch. And a strong will."
                });

            // Step 4: "cellar" (leads to "cheese")
            Add("cellar",
                new[]{
                    "The cellar was my sanctuary—a library of rare cheese. Now? A banquet hall for rats.",
                    "I lost my life’s work to those furry fiends. My wheels of cheese, gnawed to dust.",
                    "If only I’d hidden the cheese better... Perhaps ask about cheese. They always sniff it out."
                });

            // Step 5: "cheese" (leads to "revenge")
            Add("cheese",
                new[]{
                    "They say cheese is the heart of civilization. For rats, it’s a declaration of war.",
                    "No cheddar is safe, no gouda sacred. My cellar was their paradise—and my ruin.",
                    "The scent of cheese haunts me. The loss still stings. Only revenge remains now."
                });

            // Step 6: "revenge" (unlocks quest to "slay", gives out quest scroll)
            Add("revenge",
                new[]{
                    "Revenge is a dish best served on a rat trap. Will you help me? Ask how you might slay them.",
                    "I’ve set traps, I’ve pleaded with cats, I’ve cursed the moon. Only true slaying will sate me.",
                    "Ten giant rats for my peace of mind. Only then can I rest. If you’re ready, say ‘slay’."
                });

            // Quest node: "slay"
            Add("slay",
                new[]{
                    "Bring me proof—ten giant rat tails. Here, take this scroll to track your grim harvest.",
                    "Words won’t rid my cellar of monsters. Slay ten giant rats. This scroll will tally their demise.",
                    "No more talk—hunt, slay, and return. Ten giant rats. The scroll will mark your deeds."
                },
                () => new KillQuestScroll(typeof(GiantRat), 10, 500)
            );

            // 24 Red Herrings / Flavor Keywords

            Add("cat",
                new[]{
                    "Cats are lazy traitors—mine sleeps atop the rat holes and dreams of fish.",
                    "Tried enlisting the neighbor’s tomcat. Came back scratched and humiliated. The rats mocked him, I swear."
                });

            Add("tail",
                new[]{
                    "A rat’s tail is more expressive than its eyes. Flicking means annoyance. Or plotting.",
                    "If you ever see a rat’s tail twitching—move. Something’s about to go wrong."
                });

            Add("disease",
                new[]{
                    "People blame rats for every sickness, but it’s their fleas you should fear most.",
                    "They say the rats spread fever in the village, but I think their filth simply reveals what’s already there."
                });

            Add("gnaw",
                new[]{
                    "Rats can gnaw through anything—wood, stone, hope.",
                    "The sound of gnawing at midnight is enough to turn a grown man’s hair gray."
                });

            Add("night",
                new[]{
                    "Night is when the bravest rats emerge. I hear their claws on the floorboards, always searching.",
                    "Never sleep with crumbs near your bed. That’s when the night visitors come."
                });

            Add("whisker",
                new[]{
                    "Each rat has a unique pattern of whiskers—like a thief’s signature.",
                    "I tried trimming one’s whiskers once. Came back with three fewer fingers."
                });

            Add("flea",
                new[]{
                    "A rat’s fleas are its true army. Some say they can leap the length of a wine barrel.",
                    "If you spot a rat scratching, run. Its fleas are looking for a new home."
                });

            Add("trap",
                new[]{
                    "I’ve built traps from copper, cheese, and desperation. The rats dismantle them for sport.",
                    "A smart rat springs a trap and leaves a calling card—usually droppings on your pillow."
                });

            Add("nibble",
                new[]{
                    "To a rat, everything is food—paper, shoes, dignity.",
                    "You hear nibbling in the walls, and you know: you’re never alone."
                });

            Add("queen",
                new[]{
                    "There’s always a queen, fat and regal, deep in the nest. She rules with a whiskered fist.",
                    "I dream of finding the rat queen. My nightmares end when I do."
                });

            Add("droppings",
                new[]{
                    "Rats leave droppings like signatures. Mine spell out threats. Or poetry. Hard to tell.",
                    "You can measure the size of a nest by the amount of droppings. Mine filled a bucket."
                });

            Add("plague",
                new[]{
                    "Old timers say the plague rode in on a rat’s back. I think it just found good company.",
                    "The word ‘plague’ makes my skin crawl. I wash my hands more than a priest these days."
                });

            Add("fierce",
                new[]{
                    "A cornered giant rat will fight like a demon. I have the scars to prove it.",
                    "Don’t let their size fool you—giant rats bite harder than wolves, and shriek louder, too."
                });

            Add("fur",
                new[]{
                    "Rat fur is slick, greasy, and impossible to wash out. I’ve tried.",
                    "Some tailors claim rat fur makes fine gloves. I say, wear them at your peril."
                });

            Add("squeak",
                new[]{
                    "Their squeaks are a language—a warning, a threat, a song of conquest.",
                    "The high-pitched squeak of a hungry rat will haunt you for weeks."
                });

            Add("sewer",
                new[]{
                    "The sewers are rat kingdoms. Go there if you must, but don’t expect to leave unbitten.",
                    "I mapped every sewer tunnel in town, searching for nests. The rats learned my routes faster than I did."
                });

            Add("pet",
                new[]{
                    "Some keep rats as pets. I call that optimism—dangerous, delusional optimism.",
                    "A pet rat will betray you for a single crumb of cheese."
                });

            Add("friend",
                new[]{
                    "I once thought I could befriend them. They accepted my gift, then chewed my boots for dessert.",
                    "If you make friends with a rat, expect the friendship to be short—and one-sided."
                });

            Add("poison",
                new[]{
                    "I tried poison. The rats used it to flavor my bread.",
                    "Careful with rat poison—it has a way of ending up in your own supper."
                });

            Add("wine",
                new[]{
                    "A rat will gnaw through a wine barrel, drink its fill, and stagger off with the cork.",
                    "I lost three bottles to the rats last winter. They drank better than I did."
                });

            Add("boot",
                new[]{
                    "Leave your boots out overnight, and you’ll find a rat in one and holes in the other.",
                    "They say a boot is good for crushing rats. Mine are better for running from them."
                });

            Add("burrow",
                new[]{
                    "A rat’s burrow is a maze—tight, dark, and filled with unpleasant surprises.",
                    "Follow a burrow, you find a nest. Find a nest, you find trouble."
                });

            Add("bite",
                new[]{
                    "A rat bite festers quickly. I recommend vinegar and luck.",
                    "Got bit on the ankle once. Still limps in the rain."
                });

            Add("hoard",
                new[]{
                    "Rats hoard what they can’t eat—buttons, coins, even my wedding ring.",
                    "Somewhere beneath this town is a rat hoard to shame any dragon."
                });

            Add("family",
                new[]{
                    "Rats breed like regrets—one becomes ten, ten becomes a hundred, and suddenly you’re outnumbered.",
                    "Every giant rat is part of a family. A very, very large family."
                });

        }
    }
}
