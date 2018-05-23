namespace PPG.CharacterSheets.Core.Requests
{
    public class PayloadRequest<TPayload>
    {
        public TPayload Payload { get; set; }
    }
}