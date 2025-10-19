using Server;
using Server.Items;

public interface IItemSpeechTrait : ISpeechTrait
{
    /// <summary>Return an item to hand to the speaker (or null) *as well as* a text line.</summary>
    bool TryGetResponse(string speech, out string response, out Item item);
}
